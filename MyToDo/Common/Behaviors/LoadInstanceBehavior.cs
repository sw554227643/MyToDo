using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MyToDo.Common.Behivors
{
    public static class LoadInstanceBehavior
    {


        public static string GetLoadInstance(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadInstanceProperty);
        }

        public static void SetLoadInstance(DependencyObject obj, string value)
        {
            obj.SetValue(LoadInstanceProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadInstance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadInstanceProperty =
            DependencyProperty.RegisterAttached("LoadInstance", typeof(string), typeof(LoadInstanceBehavior), new PropertyMetadata(null,OnLoadInstanceChanged));

        private static void OnLoadInstanceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            if (element != null)
            {
                element.Loaded += (s, e2) =>
                {
                    var viewmodel = element.DataContext;
                    if (viewmodel == null) return;
                    var methodInfo = viewmodel.GetType().GetMethod(e.NewValue.ToString());
                    if (methodInfo != null) methodInfo.Invoke(viewmodel, null);
                };
            }
            
        }
    }
}
