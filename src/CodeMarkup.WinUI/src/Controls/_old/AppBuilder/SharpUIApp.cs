﻿using System;
using System.Net;


namespace Sharp.UI
{/*
    public static partial class SharpUIAppExtension
	{
        public static MauiAppBuilder SharpUIApplication<T>(this MauiAppBuilder builder, 
            //HotReloadType HotReloadType = HotReloadType.None,
            IPAddress[] IdeIPs = null)
            where T : Application
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IMauiInitializeService, SharpUIApplicationBuilder<T>>(_ => new SharpUIApplicationBuilder<T> { HotReloadType = HotReloadType.HotReloadKit, IdeIPs = IdeIPs }));
            return builder;
        }

        class SharpUIApplicationBuilder<T> : IMauiInitializeService
            where T : Application
        {
            public HotReloadType HotReloadType;
            public IPAddress[] IdeIPs;
            
            public void Initialize(IServiceProvider services)
            {
                Application.Services = services;
                switch (HotReloadType)
                {
                    case HotReloadType.HotReloadKit:
                        if (IdeIPs.Count() > 0)
                        {
                            HotReload.InitHotReload();
                            HotReload.InitHotReloadKit<T>(IdeIPs);
                        }
                        break;
                    case HotReloadType.UserDefined:
                        HotReload.InitHotReload();
                        break;
                }                
            }
        }
    }
    */
}