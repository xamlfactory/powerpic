   M S B A M L   `   `   `  ���� T  PPicBro.Foundation.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�^clr-namespace:PicBro.Foundation.Windows.Utils.DragDropUtils;assembly=PicBro.Foundation.Windows-PicBro.Foundation.Windows.Utils.DragDropUtils  O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PicBro.Shell.Windows.PropertiesPicBro.Shell.Windows.Properties +   %PicBro.Shell.Windows.Views.FooterView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  rdragdroputils^clr-namespace:PicBro.Foundation.Windows.Utils.DragDropUtils;assembly=PicBro.Foundation.Windows  >
properties-clr-namespace:PicBro.Shell.Windows.Properties    � 	Resources     VisibilityConverter��%   &	        �� .���  J� SnapsToDevicePixels .  � ColumnDefinitions �� $��* ��� $��1 ��� $
��Auto � � RowDefinitions �� $
��Auto ��� .+��� $��1������ . (PicBro.Shell.Windows.Properties.Settings   Default �� Source# Z  �� Path$ FooterBackground�._��     ImageModelDragTemplate J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth	   Opacity
   
BlurRadius �� Orientation��%�   &	       �� .R�� 
������ $��10q� �� .+��    $ 0Q�$		 0.7Q�$
 2Q�.+��� ���� ���� .R��� $ 
Horizontal=����� .R��� $��55��$��55��$��Center=�$��Center=�$��UniformToFill=����� *ThumbDataSmall+.+��� -    ��Name$ FooterImageListBox�� J� 	AllowDrop . $��Disabled=�B   <PicBro.Foundation.Windows.Utils.DragDropUtils.DragDropHelper   DragDropTemplate# [     IsInsertionAdornerVisible .    DefaultDragDropEffect$
 Move=�   IsSingleSelection .    IsDragSource .    IsDropTarget . ���� *Images+���� # Z $ FooterBackground� �� SelectedItem �� *SelectedImage+ �� Mode$ TwoWay=�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseDoubleClick��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *OpenCommand+   CommandParameter ��  �� ElementName$
 list��$ SelectedItem�����  �� 
TargetType" �� �� BasedOn# [B��.���  �� Property � �� �� Value ��   �� 
TargetType"  ��.R��� ���� .R�� ! � Orientation$! 
Horizontal=�" � 	ItemWidth$	" 100��# � 
ItemHeight$	# 100������ .R�� $ �Name$$ TopGrid��
������ $��5q�
% � Tag% �� *DataContext+$ FooterImageListBox��& � ContextMenu& �� .@�m� $��Delete��' m� Command' �� $' !PlacementTarget.Tag.DeleteCommand�( �� RelativeSource( �� ) �� AncestorType$) ContextMenuL�* m� CommandParameter* �� $ DataContext�( �� $) ContextMenuL� �� �� $
��Auto �.+��    $ 0Q�$	 1Q�$
 2Q�.+��� $��5q�$��Center=�$��Center=�$��UniformToFill=����� *ThumbDataSmall+�� + ��Name$+ DeleteButton��$	��Top=�$��20��, J� Opacity$	, 0.6Q�$��50��$��Center=�$��0q�$y�	Collapsed=�$��X������ $ DataContext.DeleteCommand�( �� *FindAncestor+$) ListBoxL����� $ DataContext�( �� *Self+- �� Triggers- �� . �� Value$
. True��/ �� Binding/ �� $ TopGrid��$ IsMouseOver�.a��� 0 �� 
TargetName$0 DeleteButton�� � y�$ Visible=��� $��DROP YOUR IMAGES HERE��$��Center=�$��Center=�$	, 0.7Q����� # Z $ BackgroundTextColor�y��� *IsDropListEmpty+  BoolToVisibilityConverter1 �� 	Converter#1 [ � $��2��$��1������ # Z $ FooterBackground� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��8 0 3 0q�$��Center=�.+��� $��45��$��45��  MetroButtonStyleCircle#���  $��Center=�$
��Left=�$	��3 0q����� *ExportCommand+.���� $��/Assets/Export.png��$��Uniform=�$��16���� $��EXPORT��$��11(�$��Center=��� $��1��$	��3 0q�$��Center=�.+��� $��45��$��45��#���  $��Center=�$
��Left=�$	��3 0q����� *EmailCommand+.���� $��/Assets/Mail-01.png��$��Uniform=�$��16���� $��EMAIL��$��11(�$��Center=��� $��2��$��Center=�$��3 0 8 0q�.+��� $��45��$��45��#���  $��Center=�$	��3 0q����� *SlideShowCommand+.���� $��/Assets/slideshow.png��$��Uniform=�$��16���� $��
SLIDE SHOW��$��11(�$��Center=�� $��3��$��1��$��0q�$	��Top=�$��4��  AccentColorBrush#���  
������ ��Z� 2 � Value2 �� *
Progress+�� $��3��$	��150��$��0 -150 20 0q�$��Right=�$��2��#���  $��50��y��� *ShowProgress+#1 [     $ 0Q�$
 5Q�._��  �� $
��Auto ���  �� �� .+��� $��2��$��5q�$��40��$��40������ *Data+�� $��1��
�������$��Center=�$��3q����� *ProgressText+�� $��1��$��1��
�������$��Center=�$��3q����� *ProgressValue+3 �� StringFormat$
3 {0}%��