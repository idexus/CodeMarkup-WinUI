namespace CodeOnly.WinUI
{
    
    public class VisualStates
    {
        public const string CommonStates = "CommonStates";

        //------ const -------

        public class Control
        {
            public const string Normal = "Normal";
            public const string Disabled = "Disabled";
            public const string Focused = "Focused";
            public const string PointerOver = "PointerOver";
        }

        public class Button : Control
        {
            public const string Pressed = "Pressed";
        }        
    }
    
}

