   M S B A M L   `   `   `  ����  PicBro.Shell.Windows(    "PicBro.Shell.Windows.Views.TagView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$
  root��5      $	��200��5      $��2 0 0 0q�5	      .��5      �� 
���������6   ��  �� ElementName$
 root�� �� Path$ BorderThickness�._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��40 �6'   .+�5      �� $
��TAGS��6   $
��5 10q�5       $	��Top=�5!      $��SemiBold"�5"      5#      � 5$      $��1��6   $	��Top=�5%       5&      �� 5'      $��* �6'   �� 5(      $��60 �6'   .+�5*      �� $��5,0,0,0q�6   $��Center=�5,      ��5+      �� *NewTag+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5,   =    J� InputBindings 5-      �� 5.      
 �� Key$ Return��6%   	 �� Command	 5/   %   �� *AddTagCommand+.��50   -   51      �� 52      $	��Add��6   $��Center=�53      $��Center=�54      $��10,0,0,0q�56      $��1��57      ��55      �� *AddTagCommand+57      58      �� 59      $��2��6   $��0q�5:      $��Disabled=�5<      
������ $��	5,10,0,10q�5>      ��5;      �� *
Image.Tags+��5?      �� 5@      .R�5A      � 
 �Name$
 TagGrid��6   .+�5B      ��  ��Name$ 	TagBorder��6%   
������� J� Opacity$ 0Q�5D   %   ._�5E   "   �� $��30��6)   $��Center=�5F   )   $��Center=�5G   )   $��10(�5H   )   $��30��5K   )      MetroCircleButtonStyle#��[  5L   )   $��X��5M   )   $��Right=�5N   )   ��5I   )   �� ��5J   )   �� $" DataContext.RemoveTagCommand� �� RelativeSource �� *FindAncestor+ �� AncestorType$ ListBoxL�5N   )   5O      �� 5P       ��Name$ TagText��5S   (    J� IsHitTestVisible .  $��Center=�5R   (   $��NoWrap=�5T   (   $
��Left=�5V   (   ��5P   (   ��  � ToolTip 5U   (   �� 5V   (   5W       �� Triggers 5X      �� 5Y       �� Value$
 True��5Z   *    �� Binding 5Y   *   �� $ TagGrid��$ IsMouseOver�.a�5[   "   ��  �� 
TargetName$ 	TagBorder��6)    �� Property �@J�Opacity �� Value$	 0.9Q�5]   )   5^      5`      ��5g      �� 5h       �� 
TargetType" ��6   �5i      �� 5j       � ��$ 0q�5k   %   �� 5l       � �� 5m   "   �� 5n   &    �� 
TargetType" ��66   .R�5o   *   �� 5p   '   5r      5t      5v      �� 5w      $��Clear all tags��6   $��10q�5x      $��1��5y      $��3��5z      $��Right=�5}      {�5{      �� *IsTagsAvailable+��5|      �� *ClearTagsCommand+5}      5~      5      5�      