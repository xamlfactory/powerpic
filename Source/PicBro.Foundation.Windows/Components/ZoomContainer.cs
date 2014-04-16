using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PicBro.Foundation.Windows.Components
{
    public class ZoomContainer : ContentControl
    {
        public ZoomContainer()
        {
            this.Loaded += ZoomContainer_Loaded;
            this.RenderTransformOrigin = new Point(0, 0);
            this.SizeChanged += ZoomContainer_SizeChanged;
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                if (e.Key == Key.OemPlus)
                {
                    var element = e.OriginalSource as UIElement;
                    var transformation = element.RenderTransform
                                                 as MatrixTransform;
                    var matrix = transformation == null ? Matrix.Identity :
                                                   transformation.Matrix;
                    matrix.ScaleAt(1.3, 1.3, this.ActualWidth / 2, this.ActualHeight / 2); 

                    element.RenderTransform = new MatrixTransform(matrix);
                    e.Handled = true;
                }
                if (e.Key == Key.OemMinus)
                {
                    var element = e.OriginalSource as UIElement;
                    var transformation = element.RenderTransform
                                                 as MatrixTransform;
                    var matrix = transformation == null ? Matrix.Identity :
                                                   transformation.Matrix;
                    matrix.ScaleAt(0.7, 0.7, this.ActualWidth / 2, this.ActualHeight / 2);

                    element.RenderTransform = new MatrixTransform(matrix);
                    e.Handled = true;
                }
            }
        }

        void ZoomContainer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ((FrameworkElement)this.Parent).Clip = new RectangleGeometry(new Rect(0, 0, this.ActualWidth, this.ActualHeight));
        }

        private void ZoomContainer_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
            ((FrameworkElement)this.Parent).Clip = new RectangleGeometry(new Rect(0, 0, this.ActualWidth, this.ActualHeight));
        }

        protected override void OnManipulationDelta(System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            var element = e.OriginalSource as UIElement;

            var transformation = element.RenderTransform
                                                 as MatrixTransform;
            var matrix = transformation == null ? Matrix.Identity :
                                           transformation.Matrix;

            matrix.ScaleAt(e.DeltaManipulation.Scale.X,
                   e.DeltaManipulation.Scale.Y,
                   e.ManipulationOrigin.X,
                   e.ManipulationOrigin.Y);

            matrix.Translate(e.DeltaManipulation.Translation.X,
                             e.DeltaManipulation.Translation.Y);

            if (matrix.M11 < 1.0)
            {
                matrix.M11 = 1.0;
            }

            if (matrix.M22 < 1.0)
            {
                matrix.M22 = 1.0;
            }

            if (matrix.OffsetX > 0.0)
            {
                matrix.OffsetX = 0.0;
            }

            if (matrix.OffsetY > 0.0)
            {
                matrix.OffsetY = 0.0;
            }

            var xlimit = this.ActualWidth - (matrix.M11 * this.ActualWidth);

            if (matrix.OffsetX < xlimit)
            {
                matrix.OffsetX = xlimit;
            }

            var ylimit = this.ActualHeight - (matrix.M22 * this.ActualHeight);

            if (matrix.OffsetY < ylimit)
            {
                matrix.OffsetY = ylimit;
            }

            element.RenderTransform = new MatrixTransform(matrix);
            e.Handled = true;

            base.OnManipulationDelta(e);
        }

        protected override void OnManipulationStarting(System.Windows.Input.ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = (IInputElement)this.Parent;
            e.Handled = true;
            base.OnManipulationStarting(e);
        }
    }
}
