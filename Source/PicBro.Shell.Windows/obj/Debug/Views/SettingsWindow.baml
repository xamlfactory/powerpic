   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      T PPicBro.Foundation.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulltPclr-namespace:PicBro.Foundation.Windows.Utils;assembly=PicBro.Foundation.WindowsPicBro.Foundation.Windows.Utils 5       PicBro.Shell.Windows/   )PicBro.Shell.Windows.Views.SettingsWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      butilsPclr-namespace:PicBro.Foundation.Windows.Utils;assembly=PicBro.Foundation.Windows     5        � Title$  Settings��5       � SizeToContent$ Height=�5       � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=�5	       � 
ResizeMode$ NoResize=�5
      $	��380��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      .+�5   
   �� $��Select theme��6   $��Center=�5      $��10q�5       �� 5!   
   -   5         ��Name$ 
accentlist��5#      $��1��5!      $��10q�5"       �� DisplayMemberPath$
 Name��5$      $��Center=�5&      ��5%      �� *	Accents+5'      �� 5)   
   $��
Background��6   $��Center=�5*      $��10q�5+      $��1��5,      �� 5-   
   -   5        $ BackgroundList��50      $��1��5-      $��10q�5.      $��1��5/      $��Center=�51      52      �� 54   
   $��Image types��6   $��2��55      $	��Top=�56      $��10q�57      �� 58   
   -   5        	 ��Name$
	 list��5:      $��1��58      $��10q�59      
 �� SelectionMode$
 Multiple=�5;      $��Disabled=�5<      $��2��5=      $��Center=�5>      ��5?      �� 5@       �� 
TargetType" ��6   .�5A      ��  �� Property � �� �� Value 5B      �� 5C       �� 
TargetType" ��6.   .R�5D   "   �� 5E      5G      5H      ��5J      �� 5K      .R�5L      �� $��5q�5M      ��5L      ��  d� 	IsChecked 5N      �� *
IsSelected+ �� Mode$ TwoWay=� �� RelativeSource ��  �� AncestorType" ��5O      ��5Q      �� 5R      .R�5S      �  � Orientation$ 
Horizontal=�6    5T      5V      �� 5X   
   $��Database Location��6   $��3��5Y      $��2��5Z      $��10q�5[      � 5\   
   $��3��6   $��2��5]      $��10q�5^       5_      �� 5`      $��* �6#   �� 5a      $��35 �6#   .+�5c      �� -   5         ��Name$ DBLocationPath��5c      �� 5d      -   5         ��Name$ DBLocationBrowse��5f      $	��...��5d      $��1��5e      $��29��5g      $��Bottom=�5i      $��5,0,0,0q�5j      5k      �� 5m   
   -   5         ��Name$ tagsettings��5r      $��4��5m      $��Show Tags on Left Side��5n      $��10q�5o      $��2��5p      5r      �� 5t   
   -   5        $ CleanupDatabase��5v      $��5��5t      $��10q�5u      $��2��5w      $��CLEANUP DATABASE��5x      5y      �� 5{   
   $��6��6   $��2��5|      $��10q�5}      $
��Wrap=�5~      $r��lScan all the system directories for images and delete it from application, if it is not available in system.��5      �� 5�   
   -   5        $��7��5�      $��10q�5�      $��2��5�      .��5�      ��  �� Orientation$ 
Horizontal=�6   .+�5�      �� $��/Assets/warning.png��6   $	��5 1q�5�      $��Uniform=�5�      $��16��5�      �� 5�      $��RESET POWERPIC��6   $
��15 1q�5�      5�      5�      �� 5�   
   $��8��6   $��2��5�      $��10q�5�      $<��6Reset will clear all data and restart the application.��5�      �� 5�   
   -	   5        $��9��5�      $��10q�5�      $��2��5�      $
��Save��5�      $
��15 2q�5�      $��Right=�5�      �� 5�   
   -
   5        $��9��5�      $��10 10 80 10q�5�      $��2��5�      $��Reset Settings��5�      $
��15 2q�5�      $��Right=�5�      5�      5�      