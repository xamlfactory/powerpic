using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections;
using System.Windows.Documents;
using System.Reflection;

namespace PicBro.Foundation.Windows.Utils.DragDropUtils
{
    public class DragDropHelper
    {
        // source and target
        private DataFormat format = DataFormats.GetDataFormat("DragDropItemsControl");
        private Point initialMousePosition;
        private Vector initialMouseOffset;
        private object draggedData;
        private DraggedAdorner draggedAdorner;
        private InsertionAdorner insertionAdorner;
        private Window topWindow;
        // source
        private ItemsControl sourceItemsControl;
        private FrameworkElement sourceItemContainer;

        private FrameworkElement sourceElement;
        // target
        private ItemsControl targetItemsControl;
        private FrameworkElement targetItemContainer;
        private bool hasVerticalOrientation;
        private int insertionIndex;
        private bool isInFirstHalf;
        private ScrollViewer parentScrollViewer;
        IScrollInfo _scrollInfo;
        // singleton
        private static DragDropHelper instance;
        private static DragDropHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DragDropHelper();
                }
                return instance;
            }
        }

        public static bool GetIsDragSource(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragSourceProperty);
        }

        public static void SetIsDragSource(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragSourceProperty, value);
        }

        public static readonly DependencyProperty IsDragSourceProperty =
            DependencyProperty.RegisterAttached("IsDragSource", typeof(bool), typeof(DragDropHelper), new UIPropertyMetadata(false, IsDragSourceChanged));


        public static bool GetIsDropTarget(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDropTargetProperty);
        }

        public static void SetIsDropTarget(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDropTargetProperty, value);
        }

        public static readonly DependencyProperty IsDropTargetProperty =
            DependencyProperty.RegisterAttached("IsDropTarget", typeof(bool), typeof(DragDropHelper), new UIPropertyMetadata(false, IsDropTargetChanged));

        public static DataTemplate GetDragDropTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(DragDropTemplateProperty);
        }

        public static void SetDragDropTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(DragDropTemplateProperty, value);
        }

        public static readonly DependencyProperty DragDropTemplateProperty =
            DependencyProperty.RegisterAttached("DragDropTemplate", typeof(DataTemplate), typeof(DragDropHelper), new UIPropertyMetadata(null));



        public static bool GetIsInsertionAdornerVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsInsertionAdornerVisibleProperty);
        }

        public static void SetIsInsertionAdornerVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsInsertionAdornerVisibleProperty, value);
        }


        public static readonly DependencyProperty IsInsertionAdornerVisibleProperty =
            DependencyProperty.RegisterAttached("IsInsertionAdornerVisible", typeof(bool), typeof(DragDropHelper), new UIPropertyMetadata(false));

        public static readonly DependencyProperty DefaultDragDropEffectProperty = DependencyProperty.RegisterAttached(
            "DefaultDragDropEffect", typeof(DragDropEffects), typeof(DragDropHelper), new PropertyMetadata(DragDropEffects.Copy));



        public static void SetDefaultDragDropEffect(UIElement element, DragDropEffects value)
        {
            element.SetValue(DefaultDragDropEffectProperty, value);
        }

        public static DragDropEffects GetDefaultDragDropEffect(UIElement element)
        {
            return (DragDropEffects)element.GetValue(DefaultDragDropEffectProperty);
        }

        public static readonly DependencyProperty IsSingleSelectionProperty = DependencyProperty.RegisterAttached(
            "IsSingleSelection", typeof(bool), typeof(DragDropHelper), new PropertyMetadata(default(bool)));

        public static void SetIsSingleSelection(UIElement element, bool value)
        {
            element.SetValue(IsSingleSelectionProperty, value);
        }

        public static bool GetIsSingleSelection(UIElement element)
        {
            return (bool)element.GetValue(IsSingleSelectionProperty);
        }


        public static readonly DependencyProperty IsDragSourceItemsControlProperty = DependencyProperty.RegisterAttached(
            "IsDragSourceItemsControl", typeof(bool), typeof(DragDropHelper), new PropertyMetadata(true));

        public static void SetIsDragSourceItemsControl(UIElement element, bool value)
        {
            element.SetValue(IsDragSourceItemsControlProperty, value);
        }

        public static bool GetIsDragSourceItemsControl(UIElement element)
        {
            return (bool)element.GetValue(IsDragSourceItemsControlProperty);
        }

        public static readonly DependencyProperty DragSourceDataContextProperty = DependencyProperty.RegisterAttached(
            "DragSourceDataContext", typeof(object), typeof(DragDropHelper), new PropertyMetadata(default(object)));

        public static void SetDragSourceDataContext(UIElement element, object value)
        {
            element.SetValue(DragSourceDataContextProperty, value);
        }

        public static object GetDragSourceDataContext(UIElement element)
        {
            return (object)element.GetValue(DragSourceDataContextProperty);
        }



        public static bool GetEnableAutomaticScrolling(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableAutomaticScrollingProperty);
        }

        public static void SetEnableAutomaticScrolling(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableAutomaticScrollingProperty, value);
        }

        public static readonly DependencyProperty EnableAutomaticScrollingProperty =
            DependencyProperty.RegisterAttached("EnableAutomaticScrolling", typeof(bool), typeof(DragDropHelper), new PropertyMetadata(false));


       



        #region EnableAutoScrollCode

        private T GetParent<T>(DependencyObject obj) where T : UIElement
        {
            var parent = obj;
            while (parent != null)
            {
                var parentElement = parent as T;
                if (parentElement != null)
                {
                    break;
                }
                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return parent as T;
        }

        #endregion


        private static void IsDragSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var dragSource = obj as FrameworkElement;
            if (dragSource != null)
            {
                if (Object.Equals(e.NewValue, true))
                {
                    dragSource.PreviewMouseLeftButtonDown += Instance.DragSource_PreviewMouseLeftButtonDown;
                    dragSource.PreviewMouseLeftButtonUp += Instance.DragSource_PreviewMouseLeftButtonUp;
                    dragSource.PreviewMouseMove += Instance.DragSource_PreviewMouseMove;
                }
                else
                {
                    dragSource.PreviewMouseLeftButtonDown -= Instance.DragSource_PreviewMouseLeftButtonDown;
                    dragSource.PreviewMouseLeftButtonUp -= Instance.DragSource_PreviewMouseLeftButtonUp;
                    dragSource.PreviewMouseMove -= Instance.DragSource_PreviewMouseMove;
                }
            }
        }

        private static void IsDropTargetChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var dropTarget = obj as ItemsControl;
            if (dropTarget != null)
            {
                if (Object.Equals(e.NewValue, true))
                {
                    dropTarget.AllowDrop = true;
                    dropTarget.PreviewDrop += Instance.DropTarget_PreviewDrop;
                    dropTarget.PreviewDragEnter += Instance.DropTarget_PreviewDragEnter;
                    dropTarget.PreviewDragOver += Instance.DropTarget_PreviewDragOver;
                    dropTarget.PreviewDragLeave += Instance.DropTarget_PreviewDragLeave;
                }
                else
                {
                    dropTarget.AllowDrop = false;
                    dropTarget.PreviewDrop -= Instance.DropTarget_PreviewDrop;
                    dropTarget.PreviewDragEnter -= Instance.DropTarget_PreviewDragEnter;
                    dropTarget.PreviewDragOver -= Instance.DropTarget_PreviewDragOver;
                    dropTarget.PreviewDragLeave -= Instance.DropTarget_PreviewDragLeave;
                }
            }
        }

        // DragSource

        private void DragSource_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (GetIsDragSourceItemsControl(sender as UIElement))
            {
                this.sourceItemsControl = (ItemsControl)sender;
                Visual visual = e.OriginalSource as Visual;

                this.topWindow = Window.GetWindow(this.sourceItemsControl);
                this.initialMousePosition = e.GetPosition(this.topWindow);

                this.sourceItemContainer = sourceItemsControl.ContainerFromElement(visual) as FrameworkElement;
                if (this.sourceItemContainer != null)
                {
                    if (!GetIsSingleSelection(sourceItemsControl)) this.draggedData = (sourceItemsControl as ListBox).SelectedItems;
                    else
                    {
                        this.draggedData = this.sourceItemContainer.DataContext;
                    }
                }
            }
            else
            {
                this.sourceItemContainer = null;
                this.sourceItemsControl = null;
                this.sourceElement = sender as FrameworkElement;
                this.topWindow = Window.GetWindow(sender as DependencyObject);
                this.initialMousePosition = e.GetPosition(this.topWindow);
                this.draggedData = GetDragSourceDataContext(sender as UIElement);
            }
        }

        // Drag = mouse down + move by a certain amount
        private void DragSource_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (this.draggedData != null)
            {
                // Only drag when user moved the mouse by a reasonable amount.
                if (Utilities.IsMovementBigEnough(this.initialMousePosition, e.GetPosition(this.topWindow)))
                {
                    if (sourceItemContainer != null)
                    {
                        this.initialMouseOffset = this.initialMousePosition
                                                  - this.sourceItemContainer.TranslatePoint(new Point(0, 0), this.topWindow);
                    }
                    else
                    {
                        this.initialMouseOffset = this.initialMousePosition
                                                - this.sourceElement.TranslatePoint(new Point(0, 0), this.topWindow);
                    }
                    DataObject data = new DataObject(this.format.Name, this.draggedData);

                    // Adding events to the window to make sure dragged adorner comes up when mouse is not over a drop target.
                    bool previousAllowDrop = this.topWindow.AllowDrop;
                    this.topWindow.AllowDrop = true;
                    this.topWindow.DragEnter += TopWindow_DragEnter;
                    this.topWindow.DragOver += TopWindow_DragOver;
                    this.topWindow.DragLeave += TopWindow_DragLeave;

                    DragDropEffects effects = DragDrop.DoDragDrop((DependencyObject)sender, data, GetDefaultDragDropEffect(sender as UIElement));

                    // Without this call, there would be a bug in the following scenario: Click on a data item, and drag
                    // the mouse very fast outside of the window. When doing this really fast, for some reason I don't get 
                    // the Window leave event, and the dragged adorner is left behind.
                    // With this call, the dragged adorner will disappear when we release the mouse outside of the window,
                    // which is when the DoDragDrop synchronous method returns.
                    RemoveDraggedAdorner();

                    this.topWindow.AllowDrop = previousAllowDrop;
                    this.topWindow.DragEnter -= TopWindow_DragEnter;
                    this.topWindow.DragOver -= TopWindow_DragOver;
                    this.topWindow.DragLeave -= TopWindow_DragLeave;

                    this.draggedData = null;
                }
            }
        }

        private void DragSource_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.draggedData = null;
        }

        // DropTarget

        private void DropTarget_PreviewDragEnter(object sender, DragEventArgs e)
        {
            this.targetItemsControl = (ItemsControl)sender;
            object draggedItem = e.Data.GetData(this.format.Name);

            DecideDropTarget(e);
            if (draggedItem != null)
            {
                // Dragged Adorner is created on the first enter only.
                ShowDraggedAdorner(e.GetPosition(this.topWindow));
                if (DragDropHelper.GetIsInsertionAdornerVisible(sender as DependencyObject))
                    CreateInsertionAdorner();
            }
            e.Handled = true;
        }

        private void DropTarget_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (_scrollInfo == null)
            {
                if (this.targetItemsControl != null)
                {
                    var isAutoScroolEnabled = GetEnableAutomaticScrolling(this.targetItemsControl);
                    if (isAutoScroolEnabled && this.targetItemsControl != null)
                    {
                        if (this.parentScrollViewer == null)
                            this.parentScrollViewer = GetParent<ScrollViewer>(targetItemsControl);
                        if (this.parentScrollViewer != null)
                        {
                            if (parentScrollViewer != null)
                            {
                                var parent = targetItemsControl as DependencyObject;
                                while (parent != null)
                                {
                                    _scrollInfo = parent as IScrollInfo;
                                    if (_scrollInfo != null && _scrollInfo.ScrollOwner == parentScrollViewer)
                                    {
                                        break;
                                    }
                                    _scrollInfo = null;
                                    parent = VisualTreeHelper.GetParent(parent);
                                }
                            }
                        }
                    }
                }
            }

            UIElement scrollable = _scrollInfo as UIElement;
            if (scrollable != null)
            {
                var mousePos = e.GetPosition(scrollable);
                if (_scrollInfo.CanHorizontallyScroll)
                {
                    if (mousePos.X < 20)
                    {

                        _scrollInfo.LineLeft();

                    }
                    else if (mousePos.X >= (scrollable.RenderSize.Width -20))
                    {
                        _scrollInfo.LineRight();
                    }
                }
            }

            object draggedItem = e.Data.GetData(this.format.Name);

            DecideDropTarget(e);
            if (draggedItem != null)
            {
                // Dragged Adorner is only updated here - it has already been created in DragEnter.
                ShowDraggedAdorner(e.GetPosition(this.topWindow));
                UpdateInsertionAdornerPosition();
            }
            e.Handled = true;
        }

        private void DropTarget_PreviewDrop(object sender, DragEventArgs e)
        {
            object draggedItem = e.Data.GetData(this.format.Name);
            int indexRemoved = -1;

            if (draggedItem != null)
            {
                if ((e.Effects & DragDropEffects.Move) != 0)
                {
                    if (draggedItem is IEnumerable)
                    {
                        IEnumerable draggedItems = draggedItem as IEnumerable;
                        foreach (var item in draggedItems)
                            indexRemoved = Utilities.RemoveItemFromItemsControl(this.sourceItemsControl, item);
                    }
                    else
                        indexRemoved = Utilities.RemoveItemFromItemsControl(this.sourceItemsControl, draggedItem);
                }
                // This happens when we drag an item to a later position within the same ItemsControl.
                if (indexRemoved != -1 && this.sourceItemsControl == this.targetItemsControl && indexRemoved < this.insertionIndex)
                {
                    this.insertionIndex--;
                }
                if (draggedItem is IEnumerable)
                {
                    IEnumerable draggedItems = draggedItem as IEnumerable;
                    foreach (var item in draggedItems)
                    {
                        Utilities.InsertItemInItemsControl(this.targetItemsControl, item, this.insertionIndex++);
                        ((ListBox)targetItemsControl).ScrollIntoView(item);
                    }
                }
                else
                {
                    Utilities.InsertItemInItemsControl(this.targetItemsControl, draggedItem, this.insertionIndex);
                    ((ListBox)targetItemsControl).ScrollIntoView(draggedItem);
                }

                RemoveDraggedAdorner();
                RemoveInsertionAdorner();
            }
           
            e.Handled = true;
        }

        private void DropTarget_PreviewDragLeave(object sender, DragEventArgs e)
        {
            // Dragged Adorner is only created once on DragEnter + every time we enter the window. 
            // It's only removed once on the DragDrop, and every time we leave the window. (so no need to remove it here)
            object draggedItem = e.Data.GetData(this.format.Name);
            if (draggedItem != null)
            {
                RemoveInsertionAdorner();
            }
            e.Handled = true;
        }

        // If the types of the dragged data and ItemsControl's source are compatible, 
        // there are 3 situations to have into account when deciding the drop target:
        // 1. mouse is over an items container
        // 2. mouse is over the empty part of an ItemsControl, but ItemsControl is not empty
        // 3. mouse is over an empty ItemsControl.
        // The goal of this method is to decide on the values of the following properties: 
        // targetItemContainer, insertionIndex and isInFirstHalf.
        private void DecideDropTarget(DragEventArgs e)
        {
            int targetItemsControlCount = this.targetItemsControl.Items.Count;
            object draggedItem = e.Data.GetData(this.format.Name);

            if (IsDropDataTypeAllowed(draggedItem))
            {
                if (targetItemsControlCount > 0)
                {
                    this.hasVerticalOrientation = Utilities.HasVerticalOrientation(this.targetItemsControl.ItemContainerGenerator.ContainerFromIndex(0) as FrameworkElement);
                    this.targetItemContainer = targetItemsControl.ContainerFromElement((DependencyObject)e.OriginalSource) as FrameworkElement;

                    if (this.targetItemContainer != null)
                    {
                        Point positionRelativeToItemContainer = e.GetPosition(this.targetItemContainer);
                        this.isInFirstHalf = Utilities.IsInFirstHalf(this.targetItemContainer, positionRelativeToItemContainer, this.hasVerticalOrientation);
                        this.insertionIndex = this.targetItemsControl.ItemContainerGenerator.IndexFromContainer(this.targetItemContainer);

                        if (!this.isInFirstHalf)
                        {
                            this.insertionIndex++;
                        }
                    }
                    else
                    {
                        this.targetItemContainer = this.targetItemsControl.ItemContainerGenerator.ContainerFromIndex(targetItemsControlCount - 1) as FrameworkElement;
                        this.isInFirstHalf = false;
                        this.insertionIndex = targetItemsControlCount;
                    }
                }
                else
                {
                    this.targetItemContainer = null;
                    this.insertionIndex = 0;
                }
            }
            else
            {
                this.targetItemContainer = null;
                this.insertionIndex = -1;
                e.Effects = DragDropEffects.All;
            }
        }

        // Can the dragged data be added to the destination collection?
        // It can if destination is bound to IList<allowed type>, IList or not data bound.
        private bool IsDropDataTypeAllowed(object draggedItem)
        {
            bool isDropDataTypeAllowed;
            IEnumerable collectionSource = this.targetItemsControl.ItemsSource;
            if (draggedItem != null)
            {
                if (collectionSource != null)
                {
                    object model = null;
                    if (draggedItem is IEnumerable)
                    {
                        IEnumerable draggedItems = draggedItem as IEnumerable;

                        foreach (var item in draggedItems)
                        {
                            model = item;
                            break;
                        }
                    }
                    else
                    {
                        model = draggedItem;
                    }
                    Type draggedType = model.GetType();
                    Type collectionType = collectionSource.GetType();

                    Type genericIListType = collectionType.GetInterface("IList`1");
                    if (genericIListType != null)
                    {
                        Type[] genericArguments = genericIListType.GetGenericArguments();
                        isDropDataTypeAllowed = genericArguments[0].IsAssignableFrom(draggedType);
                    }
                    else if (typeof(IList).IsAssignableFrom(collectionType))
                    {
                        isDropDataTypeAllowed = true;
                    }
                    else
                    {
                        isDropDataTypeAllowed = false;
                    }
                }
                else // the ItemsControl's ItemsSource is not data bound.
                {
                    isDropDataTypeAllowed = true;
                }
            }
            else
            {
                isDropDataTypeAllowed = false;
            }
            return isDropDataTypeAllowed;
        }

        // Window

        private void TopWindow_DragEnter(object sender, DragEventArgs e)
        {
            ShowDraggedAdorner(e.GetPosition(this.topWindow));
            e.Effects = DragDropEffects.All;
            e.Handled = true;
        }

        private void TopWindow_DragOver(object sender, DragEventArgs e)
        {
            ShowDraggedAdorner(e.GetPosition(this.topWindow));
            e.Effects = DragDropEffects.All;
            e.Handled = true;
        }

        private void TopWindow_DragLeave(object sender, DragEventArgs e)
        {
            RemoveDraggedAdorner();
            e.Handled = true;
        }

        // Adorners

        // Creates or updates the dragged Adorner. 
        private void ShowDraggedAdorner(Point currentPosition)
        {
            if (this.draggedAdorner == null)
            {
                AdornerLayer adornerLayer;
                if (sourceItemsControl != null)
                {
                    adornerLayer = AdornerLayer.GetAdornerLayer(this.sourceItemsControl);
                    if (adornerLayer != null)
                        this.draggedAdorner = new DraggedAdorner(
                            this.draggedData,
                            GetDragDropTemplate(this.sourceItemsControl),
                            this.sourceItemContainer,
                            adornerLayer);
                }
                else
                {
                    adornerLayer = AdornerLayer.GetAdornerLayer(this.sourceElement);
                    if (adornerLayer != null)
                        this.draggedAdorner = new DraggedAdorner(
                            this.draggedData, GetDragDropTemplate(this.sourceElement), this.sourceElement, adornerLayer);
                }
            }
            if (draggedAdorner != null)
                this.draggedAdorner.SetPosition(currentPosition.X - this.initialMousePosition.X + this.initialMouseOffset.X, currentPosition.Y - this.initialMousePosition.Y + this.initialMouseOffset.Y);
        }

        private void RemoveDraggedAdorner()
        {
            if (this.draggedAdorner != null)
            {
                this.draggedAdorner.Detach();
                this.draggedAdorner = null;
            }
        }

        private void CreateInsertionAdorner()
        {
            if (this.targetItemContainer != null)
            {
                // Here, I need to get adorner layer from targetItemContainer and not targetItemsControl. 
                // This way I get the AdornerLayer within ScrollContentPresenter, and not the one under AdornerDecorator (Snoop is awesome).
                // If I used targetItemsControl, the adorner would hang out of ItemsControl when there's a horizontal scroll bar.
                var adornerLayer = AdornerLayer.GetAdornerLayer(this.targetItemContainer);
                this.insertionAdorner = new InsertionAdorner(this.hasVerticalOrientation, this.isInFirstHalf, this.targetItemContainer, adornerLayer);
            }
        }

        private void UpdateInsertionAdornerPosition()
        {
            if (this.insertionAdorner != null)
            {
                this.insertionAdorner.IsInFirstHalf = this.isInFirstHalf;
                this.insertionAdorner.InvalidateVisual();
            }
        }

        private void RemoveInsertionAdorner()
        {
            if (this.insertionAdorner != null)
            {
                this.insertionAdorner.Detach();
                this.insertionAdorner = null;
            }
        }
    }
}
