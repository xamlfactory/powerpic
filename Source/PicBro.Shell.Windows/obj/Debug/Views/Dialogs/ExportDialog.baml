   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      T PPicBro.Foundation.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulltPclr-namespace:PicBro.Foundation.Windows.Utils;assembly=PicBro.Foundation.WindowsPicBro.Foundation.Windows.Utils 5      O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PicBro.Shell.Windows.PropertiesPicBro.Shell.Windows.Properties 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      4   .PicBro.Shell.Windows.Views.Export.ExportDialog   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      butilsPclr-namespace:PicBro.Foundation.Windows.Utils;assembly=PicBro.Foundation.Windows     5      D
properties-clr-namespace:PicBro.Shell.Windows.Properties     5      6sys&clr-namespace:System;assembly=mscorlib     5        � Title$  EXPORT��5       � SizeToContent$ Height=�5       � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=�5	       � 
ResizeMode$ NoResize=�5
      $	��350��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   �� $��Location��6   $
��5,10q�6$   � 5   
   $��1��6   $��0,10,0,5q�6    5      �� 5      $��* �6#   �� 5      $��40 �6#   .+�5      ��  �� 
IsReadOnly . ��6(   �� . (PicBro.Shell.Windows.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 LastExportedDirectoryPath� �� Mode$ TwoWay=��� 5       -   5         ��Name$ FolderBrowserButton��5    %   $��1��6   $	��...��6d   $��5,0,5,0q�6r   6�   5!      �� 5"   
   $
��Name��6   $��1��6    $
��5,10q�6-   �� 5#   
   $��1��6   $��1��6�   $��0,5,5,5q�6�   ��6   �� #	 Z $ 
 LastExportedCollectionName�$ TwoWay=�6�   �� 5$   
   $��2��6   $��1��6    $��0,5,5,5q�60   $��Preserve Order��5&       d� 	IsChecked 5%      �� #	 Z $
 IsPreserveOrderOnExport�$ TwoWay=�5&      � 5'   
   $��3��6   $��1��6   $��	0,10,5,10q�6,    5(      �� 5)      $��* �6#   �� 5*      $��* �6#   .+�5,      �� -   5        $ ExportButton��5,   7   $��Export��6   $��0,0,5,0q�6&   6M   �� 5-      -   5        $ CancelButton��5-   7   $��Cancel��6   $��5,0,0,0q�6&   $��1��6M   6^   5.      5/      50      