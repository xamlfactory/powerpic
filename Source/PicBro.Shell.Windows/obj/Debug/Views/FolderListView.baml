   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PicBro.Shell.Windows.CommonPicBro.Shell.Windows.Common 5      Q-clr-namespace:PicBro.Shell.Windows.PropertiesPicBro.Shell.Windows.Properties 5      /   )PicBro.Shell.Windows.Views.FolderListView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      :cmds)clr-namespace:PicBro.Shell.Windows.Common     5      D
properties-clr-namespace:PicBro.Shell.Windows.Properties     5        J� 	AllowDrop  . 
������ .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$
 Drop��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      .  (PicBro.Shell.Windows.Common.EventCommand     Command 6    �� *DropCommand+   CommandParameter 5       ��  �� RelativeSource �� *Self+ �� Path$ InvokeParameter�5       J� InputBindings 5      �� 5   
   
	 �� Key$	 Delete��6   
 �� Command
 5      �� *DeleteCommand+.��5      � .+�5   
   �� -   5         ��Name$ FolderListBox��5      $
��Auto=�5      $��Disabled=�5      $��15 20q�5      $��0 0 0 0q�5      
�������
������ ��5      �� *	Folders+ �� SelectedItem 5!      �� *SelectedFolder+ �� Mode$ TwoWay=� 5"      �� 5#       �� Gesture$ Up��6    �� 	Modifiers$ Shiftf�5$      
 5%      �� *MoveUpCommand+�� 5&      $
 Down��6   $ Shiftf�5'      
 5(      �� *MoveDownCommand+��5*      �� 5+      .R�5,      �  �Name$ 
FolderGrid��5.        . 
 � Tag 5,      �� *DataContext+ �� ElementName$ FolderListBox�� � ContextMenu 5/      �� *DataContext.ContextMenuItems+$ FolderListBox�� 50        51      $ PreviewMouseUp��6-   . 52   "      64   �� $ Tag.FolderSelectedCommand�$ 
FolderGrid��53        54      $
 Drop��6-   . 55   "      64   �� $ Tag.DropFavoriteCommand�$ 
FolderGrid�� 56   4   ��  �� *Self+$ InvokeParameter�57        58      $ PreviewDrop��6-   . 59   "      64   �� $$ Tag.PreviewDropFavoriteCommand�$ 
FolderGrid�� 5:   4   �� $ 
FolderGrid��$ DataContext�5;        5<      $ ContextMenuOpening��6-   . 5=   "      64   �� $  Tag.ContextMenuOpenCommand�$ 
FolderGrid�� 5>   4   �� 5?       � ColumnDefinitions 5A      �� 5B      $��26 �6/   �� 5C      $��* �6/   .+�5E      ��  ��Name$	 img��5F       $��/Assets/Folder-Normal.png��5E       $��5q�5G       $��Uniform=�5H       $��Center=�5I       $��16��5J       F� 5K       F�Name$
 path��5O      ����p`��[q=
�#D�@Qp�4\��(\�m�@Q��]��(\�m�@�pt\`0~р��\�2UQ`��[�G����@�@�Z�2U�P�'[`0~Q0�Z��(\�m�@QP3g[��(\�m�@Q`��[q=
�#D�@	$��20��5L      $��20��5M       J� Opacity$ 0Q�5N       �� Stretch$ Uniform=�5P      ���#F4981F$��3q�5R      �� 5S      $��1��5T   $   $��NoWrap=�5U   $   $��CharacterEllipsis=�5V   $   $��5q�5W   $   $��Center=�5Y   $   ��5S   $   �� *Name+ � ToolTip 5X   $   �� *Name+5Y   $   5Z       �� Triggers 5[      �� 5\       �� Value$
 True��5a   &    �� Binding 5\   &   ��  ��  �� Mode$ FindAncestor=� �� AncestorType" ��$ 
IsSelected�.a�5b      ��  �� 
TargetName$	 img��5c   %     �� Property  � ��! �� Value$! /Assets/Folder.png��5d   %   5e      �� 5f      $ -1��5g   &    5f   &   �� *ID+.a�5h      �� $
 path��5j   %     �@J�Opacity$! 1Q�5i   %   5j   %   �� 5k      $	 img��5m   %     �@J�Opacity$! 0Q�5l   %   5m   %   5n      5p      5r      5s      5t      