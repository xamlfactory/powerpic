   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5       PicBro.Shell.Windows.   (PicBro.Shell.Windows.Views.AddFolderView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Rforms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5      $	��350��5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $
��Name��6   $
��10 5q�5      �� 5   
   $
��10 5q�6   $��Center=�5      $��25��5      $��1��5      ��5      �� *Name+ �� Mode$ TwoWay=�5      �� 5   
   $��Folder path��6   $��2��5      $
��10 5q�5      � 5   
   $��3��6    � ColumnDefinitions 5      �� 5      �� 5      $
��Auto �6#   .+�5!      �� -   5         ��Name$
 path��5"      $��10 5 5 5q�5!      $��Center=�5$      $��25��5%      ��5#      �� *Path+$ TwoWay=�5%      �� 5&      $	��...��6   $��5q�5'      $��1��5(      $��30��5)      ��5*      �� *FolderBrowseCommand+5+      � 5,   
   $��4��6    5-      �� 5.      �� 5/      $
��Auto �6#   .+�51      � $��4��6   $��10q�52      $��10��54       � Value 53      �� *
Progress+54      �� 55      $��5��6   $��OK��56      $��1��57      $
��10 5q�58      $��Right=�5:      $
��20 3q�5;      ��59      �� *	OKCommand+5;      5<      5>      5?      