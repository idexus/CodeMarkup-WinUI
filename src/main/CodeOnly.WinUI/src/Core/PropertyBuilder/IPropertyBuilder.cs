

namespace CodeOnly.WinUI
{
    public interface IPropertyBuilder<T>
    {
        public PropertyContext<T> Context { get; set; }
        public virtual bool Build() => false;
    }
}
