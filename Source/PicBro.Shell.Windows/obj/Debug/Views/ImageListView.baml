   M S B A M L   `   `   `  ����T  PPicBro.Foundation.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullhJclr-namespace:PicBro.Foundation.Windows;assembly=PicBro.Foundation.WindowsPicBro.Foundation.Windows  5      �^clr-namespace:PicBro.Foundation.Windows.Utils.DragDropUtils;assembly=PicBro.Foundation.Windows-PicBro.Foundation.Windows.Utils.DragDropUtils  5	      U QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
      O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:PicBro.Shell.Windows.BehaviorsPicBro.Shell.Windows.Behaviors 5      I)clr-namespace:PicBro.Shell.Windows.CommonPicBro.Shell.Windows.Common 5      .   (PicBro.Shell.Windows.Views.ImageListView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a
foundationJclr-namespace:PicBro.Foundation.Windows;assembly=PicBro.Foundation.Windows     5      xdragdroputils^clr-namespace:PicBro.Foundation.Windows.Utils.DragDropUtils;assembly=PicBro.Foundation.Windows     5	      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5
      B	behaviors,clr-namespace:PicBro.Shell.Windows.Behaviors     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      4cmds)clr-namespace:PicBro.Shell.Windows.Common  5        J� 	AllowDrop  .  J� IsManipulationEnabled . |�. .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$
 Drop��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      .  (PicBro.Shell.Windows.Common.EventCommand     Command 6    �� *DropCommand+   CommandParameter 5       ��  �� RelativeSource �� *Self+ �� Path$ InvokeParameter�5      .��5      � $��	0 20 8 20q�6   	 � 	Resources	 5   
      ImageModelDragTemplate
 � RowDefinitions J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity   
BlurRadius �� Orientation��%  &	        �� 5      .R�5      � 
������ $��10q�5      
 5      �� 5      .+�5!      �  5"        5#      $ 0Q�6/   $	 0.7Q�5$   /   $ 2Q�5%   /   .+�5'      �� ��6'   �� ��5(      �� 5)   "   .R�5*   &   �� $ 
Horizontal=�61   5+   #   ��5-      �� 5.   "   .R�5/   &   �� $��55��50   ,   $��55��51   ,   $��Center=�52   ,   $��Center=�53   ,   $��UniformToFill=�54   ,   ��5/   ,   �� *ThumbDataSmall+54   ,   55   #   57      59      5:      5;      5<      .+�5=   
   �� -   5         ��Name$
 list��5>      
������ B   <PicBro.Foundation.Windows.Utils.DragDropUtils.DragDropHelper   IsDragSource .    DragDropTemplate# [  5A       �� SelectionMode$ Extended=�5B      $��Disabled=�5E      ��5=      �� *Images+ �� SelectedIndex 5C      �� *SelectedIndex+ �� Mode$ TwoWay=� �� SelectedItem 5D      �� *SelectedImage+$ TwoWay=� 5F        5G      $ MouseDoubleClick��6!   . 5H      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *OpenCommand+   CommandParameter 5I   ,   ��  �� ElementName$
 list��$ SelectedItem�5J         	Behaviors 5L      =  7PicBro.Shell.Windows.Behaviors.ListBoxSelectAllBehavior  5M         IsSelectAll 65   �� $
 list��$ DataContext.IsSelectAll�$ TwoWay=�2	  ,PicBro.Shell.Windows.Behaviors.FocusBehavior	  5N       	  IsFocus 6*   �� $
 list��$ DataContext.IsFocusList�$ TwoWay=� J� InputBindings 5P      �� 5Q      
 �� Key$ Enter��6    �� 	Modifiers$ Controlf�5R        �� Command  5S      �� *AddToFlimStripCommand+! �� CommandParameter! 5T      �� $ SelectedItems�$
 list���� 5U      $ Enter��6     5V      �� *OpenCommand+! 5W      �� $ SelectedItem�$
 list���� 5X      $ Space��6     5Y      �� *OpenCommand+! 5Z      �� $ SelectedItem�$
 list����5\      �� 5]      " �� 
TargetType"" ��6   # �� BasedOn## [B��5^      .�5_      �� $ �� Property$ � ��% �� Value% 5`      �� 5a      & �� 
TargetType"& ��6.   .R�5b   "   � -   5        .+�5d   &   �� $��Center=�67   $��Center=�5e   7   �� 5f   &   ' ��Name$
' rect��5g   0   ( J� Opacity$( 0Q�5f   0   ��5h   *   
� 5i   .   .��5j   2   � ) � Color$) 	#38000000��6?   * � Offset$* 1Q�5k   ?   � 5l   2   $) 	#42FFFFFF��6?   5m   /   5o   '   5p   #   + �� Triggers+ 5q   "   P� 5r   &   , P� Property, �@��
IsSelected- P� Value- . . �5t   *   �� % 5u   1   Z� $ �@J�Effect5v   '   5x      5z      5{      ��5}      �� 5~      .R�5      5
   /PicBro.Foundation.Windows.VirtualizingWrapPanel
  . 
  Orientation$. 
Horizontal=�67   5�      ��5�      �� 5�      .R�5�      � 
������ $��10q�5�      $��Center=�5�      $��Center=�5�      / �� BitmapScalingMode$/ HighQuality=�5�      .+�5�      � .+�5�      �� 0 ��Name$0 border��5�   %   $��4q�5�   %   
������ 1 �� Padding$1 0q�5�   %   $��Center=�5�   %   $��Center=�5�   %   ._�5�   "   � .+�5�   &   �� 2 ��Name$2 
SmallThumb��5�   ,   $��Center=�5�   ,   $��Center=�5�   ,   $
��None=�5�   ,   ��5�   ,   �� *ThumbDataSmall+ 5�   *     5�   .   $ 0Q�6?   $ 1Q�5�   ?   $ 5Q�5�   ?   5�   '   �� 5�   &   $2 MediumThumb��5�   ,   $��Center=�5�   ,   $��Center=�5�   ,   $y�	Collapsed=�5�   ,   $
��None=�5�   ,   ��5�   ,   �� *ThumbDataMedium+ 5�   *     5�   .   $ 0Q�6?   $ 1Q�5�   ?   $ 5Q�5�   ?   5�   '   �� 5�   &   $2 
LargeThumb��5�   ,   $��Center=�5�   ,   $y�	Collapsed=�5�   ,   $��Center=�5�   ,   $
��None=�5�   ,   ��5�   ,   �� *ThumbDataLarge+ 5�   *     5�   .   $ 0Q�6?   $ 1Q�5�   ?   $ 5Q�5�   ?   5�   '   5�   #   5�      5�      5�      3 �� Triggers3 5�      �� 5�      4 �� Value$
4 True��5�   &   5 �� Binding5 5�   &   �� *
IsSelected+ �� *TemplatedParent+.a�5�      �� 6 �� 
TargetName$6 border��5�   %   $ � ��% �#3DADDD5�      �� 5�      $4 Small��5�   &   5 5�   &   �� *ImageThumbSize+.a�5�      �� $6 
SmallThumb��6%   $ � y�$% Visible=�5�   %   �� 5�      $6 MediumThumb��6%   $ � y�$% 	Collapsed=�5�   %   �� 5�      $6 
LargeThumb��6%   $ � y�$% 	Collapsed=�5�   %   5�      �� 5�      $4 Medium��5�   &   5 5�   &   �� *ImageThumbSize+.a�5�      �� $6 
SmallThumb��6%   $ � y�$% 	Collapsed=�5�   %   �� 5�      $6 MediumThumb��6%   $ � y�$% Visible=�5�   %   �� 5�      $6 
LargeThumb��6%   $ � y�$% 	Collapsed=�5�   %   5�      �� 5�      $4 Large��5�   &   5 5�   &   �� *ImageThumbSize+.a�5�      �� $6 
SmallThumb��6%   $ � y�$% 	Collapsed=�5�   %   �� 5�      $6 MediumThumb��6%   $ � y�$% 	Collapsed=�5�   %   �� 5�      $6 
LargeThumb��6%   $ � y�$% Visible=�5�   %   5�      5�      5�      5�      5�      