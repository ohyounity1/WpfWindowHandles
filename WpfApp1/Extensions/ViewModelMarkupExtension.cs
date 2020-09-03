using CommonServiceLocator;
using System;
using System.Windows.Markup;

namespace WpfApp1.Extensions
{
    public class ViewModelMarkupExtension : MarkupExtension
    {
        private readonly Type _viewModelType;

        public ViewModelMarkupExtension(Type viewModelType)
        {
            _viewModelType = viewModelType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) =>
            ServiceLocator.Current.GetInstance(_viewModelType);
    }
}
