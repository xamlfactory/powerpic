using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PicBro.DataModel.Windows;

namespace PicBro.Shell.Windows.Behaviors
{
    public class DragDropBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            AssociatedObject.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(StartDrag);
            if(IsDragTarget)
            DragDrop.AddDropHandler(AssociatedObject,new DragEventHandler(OnDropImage));
            base.OnAttached();
        }

        private void OnDropImage(object sender, DragEventArgs args)
        {
            ListBox targetList = AssociatedObject as ListBox;
            ImageModel imageModel = args.Data.GetData("myFormat") as ImageModel;
            (targetList.ItemsSource as ICollection<ImageModel>).Add(imageModel);
            args.Effects = DragDropEffects.None;
         
        }

        public bool IsDragSource
        {
            get { return (bool)GetValue(IsDragSourceProperty); }
            set { SetValue(IsDragSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDragSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDragSourceProperty =
            DependencyProperty.Register("IsDragSource", typeof(bool), typeof(DragDropBehavior), new PropertyMetadata(false));
        
        public bool IsDragTarget
        {
            get { return (bool)GetValue(IsDragTargetProperty); }
            set { SetValue(IsDragTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDragTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDragTargetProperty =
            DependencyProperty.Register("IsDragTarget", typeof(bool), typeof(DragDropBehavior), new PropertyMetadata(false));
             
        private bool canstartdrag;
        private Point startPoint;
       
        private void StartDrag(object sender, MouseButtonEventArgs e)
        {
         FrameworkElement element = e.OriginalSource as FrameworkElement;
         if (element != null && element.DataContext is ImageModel)
         {
             canstartdrag = true;
             startPoint = e.GetPosition(null);
             ((Shell)App.Current.MainWindow).PreviewMouseMove -= new MouseEventHandler(MoveDrag);
             ((Shell)App.Current.MainWindow).PreviewMouseUp -= new MouseButtonEventHandler(ExitDrag);
             ((Shell)App.Current.MainWindow).PreviewMouseMove += new MouseEventHandler(MoveDrag);
             ((Shell)App.Current.MainWindow).PreviewMouseUp += new MouseButtonEventHandler(ExitDrag);
         }
        }

        private void MoveDrag(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed && canstartdrag &&
               ( Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                
                ListBox listBox = AssociatedObject as ListBox;
                ImageModel imageModel = listBox.SelectedItem as ImageModel;
                ListBoxItem listBoxItem = listBox.ItemContainerGenerator.ContainerFromItem(imageModel) as ListBoxItem;                

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", imageModel);
                DragDrop.DoDragDrop(listBox, dragData, DragDropEffects.Copy);
                canstartdrag = false;
            } 
        }

        private void ExitDrag(object sender, MouseButtonEventArgs e)
        {
            canstartdrag = false;
        }


    }
}
