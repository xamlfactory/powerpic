   M S B A M L   `   `   `  ���� T  PPicBro.Foundation.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullhJclr-namespace:PicBro.Foundation.Windows;assembly=PicBro.Foundation.WindowsPicBro.Foundation.Windows  �^clr-namespace:PicBro.Foundation.Windows.Utils.DragDropUtils;assembly=PicBro.Foundation.Windows-PicBro.Foundation.Windows.Utils.DragDropUtils  U QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:PicBro.Shell.Windows.BehaviorsPicBro.Shell.Windows.Behaviors I)clr-namespace:PicBro.Shell.Windows.CommonPicBro.Shell.Windows.Common .   (PicBro.Shell.Windows.Views.ImageListView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     a
foundationJclr-namespace:PicBro.Foundation.Windows;assembly=PicBro.Foundation.Windows     xdragdroputils^clr-namespace:PicBro.Foundation.Windows.Utils.DragDropUtils;assembly=PicBro.Foundation.Windows     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     B	behaviors,clr-namespace:PicBro.Shell.Windows.Behaviors     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  4cmds)clr-namespace:PicBro.Shell.Windows.Common    J� 	AllowDrop  .  J� IsManipulationEnabled . |�. .  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$
 Drop��.  (System.Windows.Interactivity.TriggerBase   Actions. .  (PicBro.Shell.Windows.Common.EventCommand     Command �� *DropCommand+   CommandParameter ��  �� RelativeSource �� *Self+ �� Path$ InvokeParameter�  $ Loaded��.    �� *LoadedCommand+ ��  �� 	 �� Mode$	 FindAncestor=�
 �� AncestorType$
 UserControlL�.��� $��	0 20 8 20q� � 	Resources    ImageModelDragTemplate � RowDefinitions J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity   
BlurRadius �� Orientation��%�   &	        �� .R�� 
������ $��10q� �� .+��    $ 0Q�$	 0.7Q�$ 2Q�.+��� ���� ���� .R��� $ 
Horizontal=����� .R��� $��55��$��55��$��Center=�$��Center=�$��UniformToFill=����� *ThumbDataSmall+.+��� -    ��Name$
 list��
������ B   <PicBro.Foundation.Windows.Utils.DragDropUtils.DragDropHelper   IsDragSource .    DragDropTemplate# [   �� SelectionMode$ Extended=�$��Disabled=����� *Images+ �� SelectedIndex �� *SelectedIndex+ �� Mode$ TwoWay=� �� SelectedItem �� *SelectedImage+$ TwoWay=�   $ MouseDoubleClick��. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *OpenCommand+   CommandParameter ��  �� ElementName$
 list��$ SelectedItem�   	Behaviors =  7PicBro.Shell.Windows.Behaviors.ListBoxSelectAllBehavior     IsSelectAll �� $
 list��$ DataContext.IsSelectAll�$ TwoWay=�2	  ,PicBro.Shell.Windows.Behaviors.FocusBehavior	   	  IsFocus �� $
 list��$ DataContext.IsFocusList�$ TwoWay=� J� InputBindings �� 
  �� Key$  Enter��! �� 	Modifiers$! Controlf�" �� Command" �� *AddToFlimStripCommand+# �� CommandParameter# �� $ SelectedItems�$
 list���� $  Enter��" �� *OpenCommand+# �� $ SelectedItem�$
 list���� $  Space��" �� *OpenCommand+# �� $ SelectedItem�$
 list������ $ �� 
TargetType"$ ��% �� BasedOn#% [B��.��� & �� Property& � ��' �� Value' �� ( �� 
TargetType"( ��.R�� -   .+��� $��Center=�$��Center=��� ) ��Name$
) rect��* J� Opacity$* 0Q���
� .��� + � Color$+ 	#38000000��, � Offset$, 1Q�� $+ 	#42FFFFFF��- �� Triggers- P� . P� Property. �@��
IsSelected/ P� Value/ . . ��� ' Z� & �@J�Effect���� .R�5
   /PicBro.Foundation.Windows.VirtualizingWrapPanel
  0 
  Orientation$0 
Horizontal=����� .R�� 
������ $��10q�$��Center=�$��Center=�1 �� BitmapScalingMode$1 HighQuality=�.+�� .+��� 2 ��Name$2 border��$��4q�
������ 3 �� Padding$3 0q�$��Center=�$��Center=�._�� .+��� 4 ��Name$4 
SmallThumb��$��Center=�$��Center=�$
��None=����� *ThumbDataSmall+   $ 0Q�$ 1Q�$ 5Q��� $4 MediumThumb��$��Center=�$��Center=�$y�	Collapsed=�$
��None=����� *ThumbDataMedium+   $ 0Q�$ 1Q�$ 5Q��� $4 
LargeThumb��$��Center=�$y�	Collapsed=�$��Center=�$
��None=����� *ThumbDataLarge+   $ 0Q�$ 1Q�$ 5Q��� $4 ExtraLargeThumb��$��Center=�$y�	Collapsed=�$��Center=�$
��None=����� *ThumbDataExtraLarge+   $ 0Q�$ 1Q�$ 5Q�5 �� Triggers5 �� 6 �� Value$
6 True��7 �� Binding7 �� *
IsSelected+ �� *TemplatedParent+.a��� 8 �� 
TargetName$8 border��& � ��' �#3DADDD�� $6 Small��7 �� *ImageThumbSize+.a��� $8 
SmallThumb��& � y�$' Visible=��� $8 MediumThumb��& � y�$' 	Collapsed=��� $8 
LargeThumb��& � y�$' 	Collapsed=��� $8 ExtraLargeThumb��& � y�$' 	Collapsed=��� $6 Medium��7 �� *ImageThumbSize+.a��� $8 
SmallThumb��& � y�$' 	Collapsed=��� $8 MediumThumb��& � y�$' Visible=��� $8 
LargeThumb��& � y�$' 	Collapsed=��� $8 ExtraLargeThumb��& � y�$' 	Collapsed=��� $6 Large��7 �� *ImageThumbSize+.a��� $8 
SmallThumb��& � y�$' 	Collapsed=��� $8 MediumThumb��& � y�$' 	Collapsed=��� $8 
LargeThumb��& � y�$' Visible=��� $8 ExtraLargeThumb��& � y�$' 	Collapsed=��� $6 
ExtraLarge��7 �� *ImageThumbSize+.a��� $8 
SmallThumb��& � y�$' 	Collapsed=��� $8 MediumThumb��& � y�$' 	Collapsed=��� $8 
LargeThumb��& � y�$' 	Collapsed=��� $8 ExtraLargeThumb��& � y�$' Visible=�