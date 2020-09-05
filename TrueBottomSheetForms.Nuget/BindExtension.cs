using System;
using Xamarin.Forms;

namespace TrueBottomSheetForms.Nuget
{
    internal  static class BindExtension
    {
        internal static TView Bind<TView>(this TView view, BindableProperty targetProperty,
            string sourcePropertyName = null, BindingMode mode = BindingMode.Default,
            IValueConverter converter = null, object converterParameter = null, string stringFormat = null,
            object source = null) where TView : Element
        {
            if (source != null || converterParameter != null)
                view.SetBinding(
                    targetProperty, new Binding(
                        sourcePropertyName,
                        mode,
                        converter,
                        converterParameter,
                        stringFormat,
                        source
                    ));
            else
                view.SetBinding(targetProperty, sourcePropertyName, mode, converter, stringFormat);

            return view;
        }
    }
}
