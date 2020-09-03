using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        internal interface IPropertyListener<T>
        {
            void UpdateValue(string propertyName, T value);
        }

        internal class Property<T>
        {
            private T _underlying;
            private readonly string _Name;
            private readonly IPropertyListener<T> _listener;

            public Property(string name, IPropertyListener<T> listener, T initialValue)
            {
                _Name = name;
                _listener = listener;
                _underlying = initialValue;
            }

            public T Value
            {
                get => _underlying;
                set
                {
                    if(!Equals(_underlying, value))
                    {
                        _underlying = value;
                        _listener?.UpdateValue(_Name, _underlying);
                    }
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void UpdateAllPropertiesChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        internal Property<T> RegisterProperty<T>(IPropertyListener<T> listener, string propertyName, Func<T> initialValue)
        {
            return new Property<T>(propertyName, listener, initialValue());
        }

        internal Property<T> RegisterProperty<T>(IPropertyListener<T> listener, string propertyName)
        {
            return new Property<T>(propertyName, listener, default);
        }

        
    }
}
