using System;

namespace CodeMarkup.WinUI
{
    public class AttachedInterfacesAttribute : Attribute
    {
        public AttachedInterfacesAttribute(Type extensionType,  Type[] attachedInterfaces = null)
        {
        }
    }
}