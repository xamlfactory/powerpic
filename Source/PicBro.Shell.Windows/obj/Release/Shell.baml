   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PicBro.Shell.Windows.CommonPicBro.Shell.Windows.Common Q-clr-namespace:PicBro.Shell.Windows.PropertiesPicBro.Shell.Windows.Properties     PicBro.Shell.Windows.Shell   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
Behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  n jMicrosoft.Practices.Prism.Interactivity, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \Microsoft.Practices.Prism, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35+prismhttp://www.codeplex.com/prism   8common)clr-namespace:PicBro.Shell.Windows.Common   @
properties-clr-namespace:PicBro.Shell.Windows.Properties     � Title$  Picbro��$	��560��$	��885��$	��650��$	��450��(   "MahApps.Metro.Controls.MetroWindow   ShowTitleBar .     TitlebarHeight$ 40��|�.  $��Segoe UI)� � Icon$ app.ico��$��14(�   AccentColorBrush#���   $��0.6 3q� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=�   WindowTransitionsEnabled . ���� . (PicBro.Shell.Windows.Properties.Settings   Default �� Source# Z 	 �� Path$	 MainBackground�
 J� InputBindings
 �� 
 �� Key$ Escape�� �� Command �� *EscapeCommand+��  �� Gesture$ CTRL+OemPlus�� �� CommandParameter$ OemPlus�� �� *
OEMCommand+�� $ CTRL+OemMinus��$ OemMinus�� �� *
OEMCommand+�� $ F1�� �� *LaunchTutorialCommand+�� $ F�� �� 	Modifiers$ Controlf� �� *FocusSearchCommand+�� $ F3�� �� *FocusSearchCommand+�� $ CTRL+E�� �� * FolderExplorerSelectionCommand+.��� ��
� .���  � Offset$ 0.992Q� � Color �� # Z $	 MainBackground�� $ White�� � RowDefinitions �� $
��Auto ��� $��* �.+��  � ColumnDefinitions �� �� $
��Auto ��� $
��Auto ��� $	��100 �.+��� $��POWERPIC��$��18(�$��Black"�$��Center=�$
��15 5q���  �� Orientation$ 
Horizontal=�$��1��.+��� $��settings��
������  � Cursor$
 Hand��$	��5 0q�$��5q����� *SettingCommand+�� $��2��
���   �$
��0 10q� J� Opacity$	 0.5Q��� $��about��
������ $
 Hand��$	��5 0q�$��5q����� *AboutCommand+�� $��38��#���   $��2���� $��2��$��25��$��Uniform=�$��app.ico��� $��1�� �� $
��Auto ��� �� $��2 ��� $��80 �$	��200��$��80�� �� $	��200��$	��200 ��� $
��Auto ��� $	��200���� $
��Auto �.+��� $��4��$	��Top=�$	��8 0q�-  'PicBro.Shell.Windows.Common.RegionNames   MenuBarRegion5  /Microsoft.Practices.Prism.Regions.RegionManager   
RegionName# Z �� $��1��   NavigationRegion# Z �� $��1��$��1��$��2��$��0,5,0,5q� �� ShowsPreview . 
�������$��Center=�$��Stretch=���.  �� $��2��$��1��   MainContentRegion# Z �� $��1��$��3��$��Right=�   RightNavigationRegion# Z �� $��2��$��4��$��2�� . 
�������$��Stretch=�$��Center=���.  �� $��4��$��3��   FooterRegion# Z 