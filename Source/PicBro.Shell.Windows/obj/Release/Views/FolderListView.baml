   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PicBro.Shell.Windows.CommonPicBro.Shell.Windows.Common Q-clr-namespace:PicBro.Shell.Windows.PropertiesPicBro.Shell.Windows.Properties /   )PicBro.Shell.Windows.Views.FolderListView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     :cmds)clr-namespace:PicBro.Shell.Windows.Common     D
properties-clr-namespace:PicBro.Shell.Windows.Properties       J� 	AllowDrop  . 
������ .   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$
 Drop��.   (System.Windows.Interactivity.TriggerBase   Actions. .  (PicBro.Shell.Windows.Common.EventCommand     Command �� *DropCommand+   CommandParameter ��  �� RelativeSource �� *Self+ �� Path$ InvokeParameter� J� InputBindings �� 
	 �� Key$	 Delete��
 �� Command
 �� *DeleteCommand+.��� .+��� -    ��Name$ FolderListBox��$
��Auto=�$��Disabled=�$��15 20q�$��0 0 0 0q�
�������
������ ���� *	Folders+ �� SelectedItem �� *SelectedFolder+ �� Mode$ TwoWay=� ��  �� Gesture$ Shift+Up��
 �� *MoveFolderUpCommand+ �� CommandParameter ��  �� ElementName$ FolderListBox��$ SelectedItem��� $ 
Shift+Down��
 �� *MoveFolderDownCommand+ �� $ FolderListBox��$ SelectedItem����� .R��  �Name$ 
FolderGrid��  . 
 � Tag �� *DataContext+$ FolderListBox�� � ContextMenu �� *DataContext.ContextMenuItems+$ FolderListBox��   $ PreviewMouseUp��.    �� $ Tag.FolderSelectedCommand�$ 
FolderGrid��  $
 Drop��.    �� $ Tag.DropFavoriteCommand�$ 
FolderGrid�� ��  �� *Self+$ InvokeParameter�  $ PreviewDrop��.    �� $$ Tag.PreviewDropFavoriteCommand�$ 
FolderGrid�� �� $ 
FolderGrid��$ DataContext�  $ ContextMenuOpening��.    �� $  Tag.ContextMenuOpenCommand�$ 
FolderGrid�� ��  � ColumnDefinitions �� $��26 ��� $��* �.+���  ��Name$	 img��$��/Assets/Folder-Normal.png��$��5q�$��Uniform=�$��Center=�$��16��F�  F�Name$
 path������p`��[q=
�#D�@Qp�4\��(\�m�@Q��]��(\�m�@�pt\`0~р��\�2UQ`��[�G����@�@�Z�2U�P�'[`0~Q0�Z��(\�m�@QP3g[��(\�m�@Q`��[q=
�#D�@	$��20��$��20�� J� Opacity$ 0Q� �� Stretch$ Uniform=����#F4981F$��3q��� $��1��$��NoWrap=�$��CharacterEllipsis=�$��5q�$��Center=����� *Name+ � ToolTip �� *Name+ �� Triggers ��  �� Value$
 True�� �� Binding ��  ��  �� Mode$ FindAncestor=� �� AncestorType" ��$ 
IsSelected�.a���  �� 
TargetName$	 img��  �� Property  � ��! �� Value$! /Assets/Folder.png���� $ -1�� �� *ID+.a��� $
 path��  �@J�Opacity$! 1Q��� $	 img��  �@J�Opacity$! 0Q�