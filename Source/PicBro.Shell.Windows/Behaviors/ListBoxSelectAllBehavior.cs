using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace PicBro.Shell.Windows.Behaviors
{
    public class ListBoxSelectAllBehavior: Behavior<UIElement>
    {
        public bool IsSelectAll
        {
            get { return (bool)GetValue(IsSelectAllProperty); }
            set { SetValue(IsSelectAllProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelectAll.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectAllProperty =
            DependencyProperty.Register("IsSelectAll", typeof(bool), typeof(ListBoxSelectAllBehavior), new PropertyMetadata(false, OnIsSelectAllChanged));

        private static void OnIsSelectAllChanged(DependencyObject sender,DependencyPropertyChangedEventArgs args)
        {
            (sender as ListBoxSelectAllBehavior).SelectAllExecuted();
        }
        
        private void SelectAllExecuted()
        {
            if(this.IsSelectAll)
            {
                (AssociatedObject as ListBox).SelectAll();
                SetValue(IsSelectAllProperty, false);
            }
        }

        protected override void OnAttached()
        {
           
        }
    }
}
