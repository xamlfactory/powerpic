   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5      V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PicBro.Shell.Windows.CommonPicBro.Shell.Windows.Common 5      Q-clr-namespace:PicBro.Shell.Windows.PropertiesPicBro.Shell.Windows.Properties 5	          PicBro.Shell.Windows.Shell   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      N
Behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5      JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      n jMicrosoft.Practices.Prism.Interactivity, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \Microsoft.Practices.Prism, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35+prismhttp://www.codeplex.com/prism   5      8common)clr-namespace:PicBro.Shell.Windows.Common   5      @
properties-clr-namespace:PicBro.Shell.Windows.Properties   5	        � Title$  Picbro��5
      $	��560��5      $	��885��5      $	��650��5      $	��450��5      (   "MahApps.Metro.Controls.MetroWindow   ShowTitleBar .     TitlebarHeight$ 40��5      |�.  $��Segoe UI)�5       � Icon$ app.ico��5      $��14(�5         AccentColorBrush#���   5      $��0.6 3q�5       � WindowStartupLocation$ CenterScreen=�5         WindowTransitionsEnabled . ��5      �� . (PicBro.Shell.Windows.Properties.Settings   Default �� Source# Z  �� Path$ MainBackground�	 J� InputBindings	 5      �� 5   
   

 �� Key$
 Escape��6    �� Command 5      �� *EscapeCommand+�� 5   
    �� Gesture$ CTRL+OemPlus��6    �� CommandParameter$ OemPlus��5       5      �� *
OEMCommand+5      �� 5    
   $ CTRL+OemMinus��6   $ OemMinus��5"       5!      �� *
OEMCommand+5"      �� 5#   
   $ F1��6    5$      �� *LaunchTutorialCommand+�� 5%   
   $
 F��6    �� 	Modifiers$ Controlf�5&       5'      �� *FocusSearchCommand+�� 5(   
   $
 F3��6    5)      �� *FocusSearchCommand+.��5+      � ��5,   
   
� 5-      .��5.      �  � Offset$ 0.992Q�5/       � Color 5.      �� # Z $ MainBackground�5/      � 50      $ White��6   51       � RowDefinitions 53   
   �� 54      $
��Auto �6   �� 55      $��* �6   .+�57   
   �  � ColumnDefinitions 58      �� 59      �� 5:      $
��Auto �6#   �� 5;      $
��Auto �6#   �� 5<      $	��100 �6#   .+�5>      �� $��POWERPIC��6   $��18(�5?      $��Black"�5@      $��Center=�5A      $
��15 5q�5B      �� 5C       �� Orientation$ 
Horizontal=�6   $��1��5D      .+�5E      �� $��settings��6   
������  � Cursor$
 Hand��5G      $	��5 0q�5I      $��5q�5J      ��5H      �� *SettingCommand+5J      �� 5K      $��2��6   
���   �$
��0 10q�5M       J� Opacity$	 0.5Q�5N      �� 5O      $��about��6   
������ $
 Hand��5R      $	��5 0q�5S      $��5q�5T      ��5P      �� *AboutCommand+5T      5U      �� 5V      $��38��6   #���   5W      $��2��5X      �� 5Y      $��2��6   $��25��6$   $��Uniform=�5Z      $��app.ico��5[      5\      � 5]   
   $��1��6    5^      �� 5_      $
��Auto �6    �� 5`      �� 5a      $��2 �6    �� 5b      $��80 �6    $	��200��5c       $��80��5d        5f      �� 5g      $	��200��6#   $	��200 �5h   #   �� 5i      $
��Auto �6#   �� 5j      $	��200��6#   �� 5k      $
��Auto �6#   .+�5m      �� $��4��6   $	��Top=�5n      $	��8 0q�5o      -  'PicBro.Shell.Windows.Common.RegionNames   MenuBarRegion5  /Microsoft.Practices.Prism.Regions.RegionManager   
RegionName# Z 5p      �� 5q      $��1��6   $��1��5r      $��2��5s      $��0,5,0,5q�5t       �� ShowsPreview . 
�������$��Center=�5w      $��Stretch=�5x      69   �� 5y      $��2��6   $��1��5z         MainContentRegion# Z 5{      �� 5|      $��1��6      NavigationRegion# Z 5}      �� 5~      $��1��6   $��3��5      $��Right=�5�         RightNavigationRegion# Z 5�      �� 5�      $��2��6   $��4��5�      $��2��5�       . 
�������$��Stretch=�5�      $��Center=�5�      68   �� 5�      $��4��6   $��3��5�         FooterRegion# Z 5�      5�      5�      5�      