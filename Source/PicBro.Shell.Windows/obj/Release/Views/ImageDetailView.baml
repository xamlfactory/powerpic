   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PicBro.Shell.Windows.CommonPicBro.Shell.Windows.Common O,clr-namespace:PicBro.Shell.Windows.ConverterPicBro.Shell.Windows.Converter G(clr-namespace:PicBro.Shell.Windows.ViewsPicBro.Shell.Windows.Views 0   *PicBro.Shell.Windows.Views.ImageDetailView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     :cmds)clr-namespace:PicBro.Shell.Windows.Common     B	converter,clr-namespace:PicBro.Shell.Windows.Converter     :local(clr-namespace:PicBro.Shell.Windows.Views       J� 	AllowDrop  . 
������  � 	Resources <  6PicBro.Shell.Windows.Converter.SizeToFileSizeConverter   SizeToFileSizeConverter  VisibilityConverter��%   &	        &	        �� .   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$
 Drop��.   (System.Windows.Interactivity.TriggerBase   Actions. .  (PicBro.Shell.Windows.Common.EventCommand     Command �� *DropCommand+   CommandParameter ��  �� RelativeSource �� *Self+ �� Path$ InvokeParameter�.���� $
��15 0q�$��0 0 0 0q�
�������._�� 	 � RowDefinitions	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�� 
 � ColumnDefinitions
 �� �� $
��Auto �.+��� $��NoWrap=�$��CharacterEllipsis=�$��SemiBold"�$��15(�$��5q����� *
Image.Name+ �� FallbackValue$ Untitled�� � ToolTip �� *
Image.Name+d� $��1��$ Add to Favorites�� d� 	IsChecked �� *Image.IsFavorite+ �� Mode$ TwoWay=����� *FavoriteCommand+����  �� 
TargetType" d�.���  �� Property � �� �� Value
 �������  � �� ��  �� 
TargetType" d�.R�� 
������ .+�F� ����p`��[q=
�#D�@Qp�4\��(\�m�@Q��]��(\�m�@�pt\`0~р��\�2UQ`��[�G����@�@�Z�2U�P�'[`0~Q0�Z��(\�m�@QP3g[��(\�m�@Q`��[q=
�#D�@	$��20��$��20�� �� Stretch$ Uniform=�$��5q����� *
Background+ �� *TemplatedParent+ �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 �����P�  �@d�	IsChecked$
 TrueY�. ���  � �� �#F4981F�� $��2�� J� Opacity$	 0.8Q�.+�� 
 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $	��5 0q�$
��Left=�$��10(����� *Image.LastModifiedDate+$ October,16 1987���� $��1��$��1��
��������� $��2��$��10(�$
��Left=�$	��5 0q����� *
Image.Size+ �� 	Converter# [  $ 555 KB���� $��10(�$
��Left=�$	��5 0q����� *Image.Popularity+ �� StringFormat$ {0} times used��$ 0x used��� $��3��$��0 10 0 0q�
 �� �� $
��Auto ��� $
��Auto �.+��� $��5,0,0,0q�$��50�� �� AcceptsReturn . ���� *Image.Description+$ TwoWay=�y��� *IsDescriptionEdit+  BoolToVisibilityConverter# [ �� $��5,0,0,0q�$��Center=�$
��Wrap=����� *Image.Description+$ TwoWay=� �� TargetNullValue$ -NO DESCRIPTION-��$ -NO DESCRIPTION-��y��� *IsDescriptionDisplay+# [ �� -    ��Name$ DescriptionEditButton��$��1��$��30��$��30��$	��Top=�$ Edit Description.��  MetroCircleButtonStyle#��[ y��� *IsDescriptionDisplay+# [ ���� *EditDescriptionCommand+.��(� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    $��14��$��14��.��� .+�F� �����    �����!�@���$���?
@��=�	%�� ѥ�3��g�fO�&�э>�/�Ѯ�� �/�� �� �j���Ʀ��!@�\��`���,�@�gD�+�G�@AKpe �      P?SXV���J����Z�)1|0��?ԏ��U_\5�?Q4��]�e>֢ @S+����X�"@!����� ����� ��UwD�� QGtG�  �<Z@Q�`7e�@�l�mo^ �$�����?ȡ?e �      P?	$ Uniform=����	#FF757575$��16��$��16��$��0,0,0,0q� J� RenderTransformOrigin$ 0.5,0.5&�z�V� ~���  �� Angle$ 0Q���  �� ScaleX$ 1Q�  �� ScaleY$  1Q��� -   $ DescriptionClearButton��$��û��$��2��$��30��$��30��$��	Wingdings)�$	��Top=�$��18(�$ Clear Description.��#��[ y��� *IsDescriptionEdit+# [ ���� *ClearDescriptionCommand+�� -   $ DescriptionSaveButton��$��ü��$��1��$��30��$��	Wingdings)�$	��Top=�$��30��$ Save Description.��#��[ ���� *SaveDescriptionCommand+y��� *IsDescriptionEdit+# [ (  "PicBro.Shell.Windows.Views.TagView  $��5��$	��NaN��$��0q�y��� *ShowTagsOnLeft+# [ 