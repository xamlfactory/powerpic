using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace PicBro.Shell.Windows.Behaviors
{
    public class FocusBehavior : Behavior<UIElement>
    {


        public bool IsFocus
        {
            get { return (bool)GetValue(IsFocusProperty); }
            set { SetValue(IsFocusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsFocusSearch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFocusProperty =
            DependencyProperty.Register("IsFocus", typeof(bool), typeof(FocusBehavior), new PropertyMetadata(false, OnIsFocusChanged));

        private static void OnIsFocusChanged(DependencyObject sender,DependencyPropertyChangedEventArgs args)
        {     
          (sender as FocusBehavior).FocusSearch();
        }



        public IInputElement FocusFrom
        {
            get;
            set;
        }      
        

        private void FocusSearch()
        {
            if (Keyboard.FocusedElement != AssociatedObject)
                FocusFrom = Keyboard.FocusedElement;
            if(this.IsFocus)
            {
                (AssociatedObject as UIElement).Focus();
                Keyboard.Focus(AssociatedObject as UIElement);
                SetValue(IsFocusProperty, false);
            }
        }

        protected override void OnAttached()
        {
            (AssociatedObject as UIElement).PreviewKeyDown += FocusSearchBoxBehavior_PreviewKeyDown;
        }

        void FocusSearchBoxBehavior_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                if(FocusFrom != null)
                {
                    FocusFrom.Focus();
                    Keyboard.Focus(FocusFrom);
                }
            }
        }
    }
}
