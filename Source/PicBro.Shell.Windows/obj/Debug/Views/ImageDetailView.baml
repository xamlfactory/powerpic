   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PicBro.Shell.Windows.CommonPicBro.Shell.Windows.Common 5      O,clr-namespace:PicBro.Shell.Windows.ConverterPicBro.Shell.Windows.Converter 5      G(clr-namespace:PicBro.Shell.Windows.ViewsPicBro.Shell.Windows.Views 5
      0   *PicBro.Shell.Windows.Views.ImageDetailView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      :cmds)clr-namespace:PicBro.Shell.Windows.Common     5      B	converter,clr-namespace:PicBro.Shell.Windows.Converter     5      :local(clr-namespace:PicBro.Shell.Windows.Views     5
        J� 	AllowDrop  . 
������  � 	Resources 5      <  6PicBro.Shell.Windows.Converter.SizeToFileSizeConverter   SizeToFileSizeConverter  VisibilityConverter��%:   &	        &	        5   
   6,   �� 5   
   6'   5      .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$
 Drop��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      .  (PicBro.Shell.Windows.Common.EventCommand     Command 6    �� *DropCommand+   CommandParameter 5       ��  �� RelativeSource �� *Self+ �� Path$ InvokeParameter�5      .��5      �� $
��15 0q�6   $��0 0 0 0q�5      
�������._�5   
   � 	 � RowDefinitions	 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $��* �6    �� 5&      $
��Auto �6    .+�5(      � 
 � ColumnDefinitions
 5)      �� 5*      �� 5+      $
��Auto �6'   .+�5-      �� $��NoWrap=�5.      $��CharacterEllipsis=�5/      $��SemiBold"�50      $��15(�52      $��5q�53      ��5-      �� *
Image.Name+ �� FallbackValue$ Untitled�� � ToolTip 51      �� *
Image.Name+53      d� 54      $��1��6   $ Add to Favorites��55       d� 	IsChecked 56      �� *Image.IsFavorite+ �� Mode$ TwoWay=���57      �� *FavoriteCommand+��58      �� 59       �� 
TargetType" d�6    .�5:      ��  �� Property � �� �� Value
 �����5;   %   �� 5<       � �� 5=   "   �� 5>   &    �� 
TargetType" d�66   .R�5?   *   � 
������ .+�5@   .   F� ����p`��[q=
�#D�@Qp�4\��(\�m�@Q��]��(\�m�@�pt\`0~р��\�2UQ`��[�G����@�@�Z�2U�P�'[`0~Q0�Z��(\�m�@QP3g[��(\�m�@Q`��[q=
�#D�@	$��20��5A   3   $��20��5B   3    �� Stretch$ Uniform=�5C   3   $��5q�5E   3   ��5D   3   �� *
Background+ �� *TemplatedParent+5E   3   5F   +    �� Triggers 5G   *   P� 5H   .    P� Property �@J�IsMouseOver P� Value . . �5J   2   ��  � ��
 �����5K   9   5L   /   P� 5M   .    �@d�	IsChecked$
 TrueY�5N   6   . �5O   2   ��  � �� �#F4981F5P   9   5Q   /   5S   '   5U      5V      5X      5Y      �� 5Z      $��2��6    J� Opacity$	 0.8Q�5[      .+�5\      � 
 5]      �� 5^      $
��Auto �6'   �� 5_      $
��Auto �6'   �� 5`      $
��Auto �6'   �� 5a      $
��Auto �6'   �� 5b      $
��Auto �6'   .+�5d      �� $	��5 0q�5e      $
��Left=�5f      $��10(�5g      ��5d      �� *Image.LastModifiedDate+$ October,16 1987��5g      �� 5h      $��1��6   $��1��5i      
�������5j      �� 5k      $��2��5l      $��10(�5m      $
��Left=�5n      $	��5 0q�5o      ��5k      �� *
Image.Size+ �� 	Converter# [  $ 555 KB��5o      5p      �� 5q      $��10(�5r      $
��Left=�5s      $	��5 0q�5t      ��5q      �� *Image.Popularity+ �� StringFormat$ {0} times used��$ 0x used��5t      5u      � 5v      $��3��6   $��0 10 0 0q�5w      
 5x      �� 5y      �� 5z      $
��Auto �6'   �� 5{      $
��Auto �6'   .+�5}      �� $��5,0,0,0q�5~      $��50��5       �� AcceptsReturn . ��5}      �� *Image.Description+$ TwoWay=�y�5�      �� *IsDescriptionEdit+  BoolToVisibilityConverter# [ 5�      �� 5�      $��5,0,0,0q�5�      $��Center=�5�      $
��Wrap=�5�      ��5�      �� *Image.Description+$ TwoWay=� �� TargetNullValue$ -NO DESCRIPTION-��$ -NO DESCRIPTION-��y�5�      �� *IsDescriptionDisplay+# [ 5�      �� 5�      -   5         ��Name$ DescriptionEditButton��5�      $��1��5�      $��30��5�      $��30��5�      $	��Top=�5�      $ Edit Description.��5�        MetroCircleButtonStyle#��[ 5�      y�5�      �� *IsDescriptionDisplay+# [ ��5�      �� *EditDescriptionCommand+.��5�      (� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5�      $��14��5�      $��14��5�      .��5�      � .+�5�      F� �����    �����!�@���$���?
@��=�	%�� ѥ�3��g�fO�&�э>�/�Ѯ�� �/�� �� �j���Ʀ��!@�\��`���,�@�gD�+�G�@AKpe �      P?SXV���J����Z�)1|0��?ԏ��U_\5�?Q4��]�e>֢ @S+����X�"@!����� ����� ��UwD�� QGtG�  �<Z@Q�`7e�@�l�mo^ �$�����?ȡ?e �      P?	$ Uniform=�5�   #   ���	#FF757575$��16��5�   #   $��16��5�   #   $��0,0,0,0q�5�   #    J� RenderTransformOrigin$ 0.5,0.5&�5�   #   z�5�   "   V� 5�   &   ~�5�   .   ��  �� Angle$ 0Q�6>   �� 5�   .    �� ScaleX$ 1Q�6=     �� ScaleY$  1Q�5�   =   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ DescriptionClearButton��5�      $��û��5�      $��2��5�      $��30��5�      $��30��5�      $��	Wingdings)�5�      $	��Top=�5�      $��18(�5�      $ Clear Description.��5�      #��[ 5�      y�5�      �� *IsDescriptionEdit+# [ ��5�      �� *ClearDescriptionCommand+5�      �� 5�      -   5        $ DescriptionSaveButton��5�      $��ü��5�      $��1��5�      $��30��5�      $��	Wingdings)�5�      $	��Top=�5�      $��30��5�      $ Save Description.��5�      #��[ 5�      ��5�      �� *SaveDescriptionCommand+y�5�      �� *IsDescriptionEdit+# [ 5�      5�      (  "PicBro.Shell.Windows.Views.TagView  5�      $��5��6   $	��NaN��5�      $��0q�5�      y�5�      �� *ShowTagsOnLeft+# [ 5�      5�      5�      