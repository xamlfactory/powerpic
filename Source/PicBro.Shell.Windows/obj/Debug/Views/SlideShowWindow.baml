   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PicBro.Shell.Windows.CommonPicBro.Shell.Windows.Common 5   	   0   *PicBro.Shell.Windows.Views.SlideShowWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   :cmds)clr-namespace:PicBro.Shell.Windows.Common     5   	     � ShowInTaskbar  .   � WindowStyle$
 None=�5   	    � WindowState$ 	Maximized=�5   	   .   (System.Windows.Interactivity.Interaction   Triggers 5	      /   )System.Windows.Interactivity.EventTrigger  5
   
      	EventName$ Closing��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      .  (PicBro.Shell.Windows.Common.EventCommand     Command 6    �� *SlideShowCloseCommand+5       � 	Resources 5         SlideShowFadeOutStoryBoard �� TargetProperty	 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value��%�   &	        �� 5   
   .��5      U� $ (UIElement.Opacity)�6,   $	 SlideShowImage��5   ,   .\�5        $
 0��6'   $ 0Q�5   '     5      $
 0:0:0.6��6'   $ 1Q�5   '   5      5      5       J� InputBindings 5      �� 5   
   
 �� Key$ Escape��6    �� Command 5      �� *EscapeSlideShowCommand+�� 5   
   $
 Left��6    5      �� *PreviousCommand+�� 5   
   $ Right��6    5      �� *NextCommand+.��5!      � 
���   �.+�5"   
   �� -   5        $��SlideShowImage��5"      ��5#      �� *CurrentImage+5$      5%      