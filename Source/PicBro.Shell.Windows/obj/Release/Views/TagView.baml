   M S B A M L   `   `   `  ����   PicBro.Shell.Windows(    "PicBro.Shell.Windows.Views.TagView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     >�Name$
  root��$	��200��$��2 0 0 0q�.���� 
�����������  �� ElementName$
 root�� �� Path$ BorderThickness�._��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�� $��0�� � ColumnDefinitions �� $��* ��� $��40 �.+��� $
��TAGS��$
��5 10q�$	��Top=�$��SemiBold"�� $��1��$	��Top=� �� $��* ��� $��60 �.+��� $��5,0,0,0q�$��Center=����� *NewTag+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.�� J� InputBindings �� 
 �� Key$ Return��	 �� Command	 �� *AddTagCommand+.���� $	��Add��$��Center=�$��Center=�$��10,0,0,0q�$��1������ *AddTagCommand+�� $��2��$��0q�$��Disabled=�
������ $��	5,10,0,10q����� *
Image.Tags+���� .R�� 
 �Name$
 TagGrid��.+���  ��Name$ 	TagBorder��
������� J� Opacity$ 0Q�._��� $��30��$��Center=�$��Center=�$��10(�$��30��   MetroCircleButtonStyle#��[  $��X��$��Right=����� ���� $" DataContext.RemoveTagCommand� �� RelativeSource �� *FindAncestor+ �� AncestorType$ ListBoxL���  ��Name$ TagText�� J� IsHitTestVisible .  $��Center=�$��NoWrap=�$
��Left=�����  � ToolTip ��  �� Triggers ��  �� Value$
 True�� �� Binding �� $ TagGrid��$ IsMouseOver�.a���  �� 
TargetName$ 	TagBorder�� �� Property �@J�Opacity �� Value$	 0.9Q�����  �� 
TargetType" �����  � ��$ 0q���  � �� ��  �� 
TargetType" ��.R��� �� $��Clear all tags��$��10q�$��1��$��3��$��Right=�{��� *IsTagsAvailable+���� *ClearTagsCommand+