using System;

namespace CodeOnly.WinUI.Core
{
    public class AttachedInterfacesAttribute : Attribute
    {
        public AttachedInterfacesAttribute(Type extensionType,  Type[] attachedInterfaces = null)
        {
        }
    }
}