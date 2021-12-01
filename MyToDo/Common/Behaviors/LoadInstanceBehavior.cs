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
            DependencyProperty.RegisterAttached("LoadInstance", typeof(string), typeof(LoadInstanceBehavior), new PropertyMetadata(null, OnLoadInstanceChanged));

        private static void OnLoadInstanceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //获取到触发这个事件的元素
            FrameworkElement element = d as FrameworkElement;
            if (element != null)
            {
                element.Loaded += (s, e2) =>
                {
                    //获取元素的DataContext
                    var viewmodel = element.DataContext;
                    if (viewmodel == null) return;
                    //利用反射来触发方法
                    var methodInfo = viewmodel.GetType().GetMethod(e.NewValue.ToString());
                    if (methodInfo != null) methodInfo.Invoke(viewmodel, null);
                };
            }

        }
    }
}
