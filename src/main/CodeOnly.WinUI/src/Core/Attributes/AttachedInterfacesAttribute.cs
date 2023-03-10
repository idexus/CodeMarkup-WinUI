using System;

namespace CodeOnly.WinUI
{
    public class AttachedInterfacesAttribute : Attribute
    {
        public AttachedInterfacesAttribute(Type extensionType,  Type[] attachedInterfaces = null)
        {
        }
    }
}