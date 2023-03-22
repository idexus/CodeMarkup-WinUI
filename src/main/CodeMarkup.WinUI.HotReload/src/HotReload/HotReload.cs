
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml;
using System.Threading;
using System.Threading.Tasks;
using HotReloadKit;
using System.Linq;
using System.Diagnostics;

namespace CodeMarkup.WinUI.HotReload
{
    public static partial class HotReload
    {
        class HotReloadToken
        {
            public string Token { get; set; }
        }

        class HotReloadRequest
        {
            public string[] TypeNames { get; set; }
        }

        class HotReloadData
        {
            public string[] TypeNames { get; set; }
            public byte[] AssemblyData { get; set; }
            public byte[] PdbData { get; set; }
        }

        // --------- public -----------

        public static List<IHotReloadHandler> ReloadHandlers { get; } = new List<IHotReloadHandler>();

        public static void UpdateApplication(Type[] types)
        {
            if (isEnabled)
            {
                foreach (var type in types)
                    ReplacedTypesDict[type.FullName] = type;
                InvokeHotReload();
            }
        }

        public static void UpdateApplication(HotReloadTypeData[] dataList)
        {
            if (isEnabled)
            {
                foreach (var data in dataList.Where(e => e.IsFromChangedFile))
                    ReplacedTypesDict[data.Type.FullName] = data.Type;
                InvokeHotReload();
            }
        }

        public static void ReplaceWithType(Type type)
        {
            if (isEnabled) ReplacedTypesDict[type.FullName] = type;
        }

        public static void TriggerHotReload()
        {
            if (isEnabled) InvokeHotReload();
        }

        public static Action<FrameworkElement> InitHotReload()
        {
            isEnabled = true;
            ReloadHandlers.Clear();
            ReloadHandlers.Add(new PageInFrameHotReloadHandler());
            return RegisterHandler;
        }

        public static Action<FrameworkElement> InitHotReloadKit<T>(IPAddress[] IdeIPs)
        {
            HotReloader.Init<T>(IdeIPs, platformName: "windows");
            HotReloader.RequestAdditionalTypes = () => registeredElements.Select(e => e.GetType().FullName).ToArray();
            HotReloader.UpdateApplication = UpdateApplication;

            return InitHotReload();
        }

        // ------------ private -----------

        static bool isEnabled = false;
        static object DataContext = null;

        readonly static List<FrameworkElement> registeredElements = new();
        readonly static Dictionary<string, Type> ReplacedTypesDict = new();

        static void RegisterHandler(FrameworkElement element)
        {
            if (registeredElements.Contains(element)) return;
            registeredElements.Add(element);
            if (DataContext != null) element.DataContext = DataContext;
        }

        static void InvokeHotReload()
        {
            try
            {
                foreach (FrameworkElement element in registeredElements.ToList())
                    if (element.Parent == null) registeredElements.Remove(element);

                foreach (var toReloadTypeName in ReplacedTypesDict.Keys)
                {
                    var registeredElementsForRequestedName = registeredElements.Where(e => e.GetType().FullName == toReloadTypeName).ToList();
                    foreach (var oldElement in registeredElementsForRequestedName)
                    {
                        // check if visual element type changed
                        var typeToReload = ReplacedTypesDict[toReloadTypeName];
                        if (oldElement.GetType() != typeToReload)
                        {
                            try
                            {
                                var constructor = typeToReload.GetConstructors().FirstOrDefault();
                                var newObject = constructor?.Invoke(null);
                                if (newObject is FrameworkElement newElement)
                                {
                                    DataContext = oldElement.DataContext;

                                    bool replaced = false;
                                    foreach (var handler in ReloadHandlers)
                                    {
                                        replaced = handler.ReplaceVisualElement(oldElement, newElement);
                                        if (replaced) break;
                                    }

                                    if (replaced)
                                        registeredElements.Remove(oldElement);
                                    else
                                        Debug.WriteLine($"HotReload - no handler for element type: {oldElement.GetType()} parent: {oldElement.Parent.GetType()}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex);
                            }
                            finally
                            {
                                DataContext = null;                                
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}
