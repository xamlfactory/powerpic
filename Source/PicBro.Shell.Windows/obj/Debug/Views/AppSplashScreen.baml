   M S B A M L   `   `   `  ����  PicBro.Shell.Windows0    *PicBro.Shell.Windows.Views.AppSplashScreen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  AppSplashScreen��5   	   $	��300��5   	   $	��450��5   	    � WindowStyle$
 None=�5   	    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ -1q�6      CornerRadius$ 0��5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��/Assets/Splash.jpg��6   $��3��5      $��UniformToFill=�5      � 5   
   $��1��6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5!      �� $��
10 10 10 0q�6   $	��Top=�5"      $����Thank you for using our product. We hope you find this software as useful as we do. Are there any features missing? Is there anything else you would like to see?  ��5#      $
��Wrap=�5$      �� 5%      $��10q�6   $��1��5&      .+�5'      �� $��Please let us know at:��6    � 5(      ��5)      �� 5*      �� 6%   $%��mailto://feedback@symposity.com?�6/   .�6]   feedback@symposity.com6u   6�   5,      5-      �� 5.      $��2��6   $��Center=�5/      $<��6Copyright © 2013,2014 Symposity. All Rights reserved.��50      $��10q�51      52      �� 54   
   $��2��6   .+�55      �� $��Bottom=�6   $��10 0 0 0q�56      �� 57      �6   �� *	Message+	 �� FallbackValue$
	 Test�� �� 58      �6   �� *
Progress+$	 0�� �� 59      $�%��6   5:      � 5;      $��2��6   $��2��5=      $��0 5 0 20q�5>      
 � Value
 5<      �� *
Progress+$	 50��5>      5?      5@      5A      