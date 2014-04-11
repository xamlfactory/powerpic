using PicBro.Foundation.Windows.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PicBro.Foundation.Windows.Infrastructure
{
    public class DialogService : IDialogService
    {
        public void LaunchDialog<T>(string title, object viewmodel)
        {
            var view = Activator.CreateInstance<T>() as FrameworkElement;

            if (view != null)
            {
                DialogWindow window = new DialogWindow();
                view.DataContext = viewmodel;
                window.Content = view;
                window.Owner = Application.Current.MainWindow;
                window.ShowDialog();
            }
        }


        public void CloseDialog()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is DialogWindow)
                {
                    window.Close();
                }
            }
        }
    }
}
