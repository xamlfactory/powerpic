   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  T PPicBro.Foundation.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulltPclr-namespace:PicBro.Foundation.Windows.Utils;assembly=PicBro.Foundation.WindowsPicBro.Foundation.Windows.Utils  PicBro.Shell.Windows/   )PicBro.Shell.Windows.Views.SettingsWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     butilsPclr-namespace:PicBro.Foundation.Windows.Utils;assembly=PicBro.Foundation.Windows       � Title$  Settings�� � SizeToContent$ Height=� � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=�$	��380��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $	��115 ��� .+��� $��User Interface��   GroupHeaderTextBlockStyle#��[  �� $��Select theme��$��1��$��
10,0,10,10q�  LabelTextBlockStyle#��[ �� -    ��Name$ 
accentlist��$��1��$��1��
����  �$��
10,0,10,10q� �� DisplayMemberPath$
 Name��
����  �$��14(�$��Center=����� *	Accents+�� $��
Background��$��2��$��
10,1,10,10q�#��[ �� -   $ BackgroundList��$��1��$��2��$��
10,1,10,10q�
����  �
����  �$��14(�$��Center=��� $��Align Tag Pane��$��3��$��
10,1,10,10q�#��[ �� -   $ TagPaneList��$��1��$��3��$��
10,1,10,10q�
����  �
����  �$��14(�$��Center=��� $��4��$��File Settings��#��[  $��
10,18,0,10q��� $��Image types��$��5��$
��10,0q�$	��Top=�#��[ �� -   	 ��Name$
	 list��$��1��$��5��$
��10,0q�
 �� SelectionMode$
 Multiple=�$��Disabled=�$��Center=�����  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R��� ���� .R��� $��5q�����  d� 	IsChecked �� *
IsSelected+ �� Mode$ TwoWay=� �� RelativeSource ��  �� AncestorType" ������ .R��  � Orientation$ 
Horizontal=��� $��6��$��2��$
��10,6q�#��[ $
��Wrap=�$R��LRescan the directories in the local database and remove all orphaned thumbs:���� -    ��Name$ CleanupDatabase��$��7��$��2��$
��10,6q�$��CLEANUP DATABASE���� $��Advanced Settings��$��8��$��2��$��
10,16,10,0q�#��[  �� $��Local Database��$��9��#��[ � $��9��$��2��$��10q� �� $��* ��� $��35 �.+��� -    ��Name$ DBLocationPath��
����  �$��14(��� -   $ DBLocationBrowse��$	��...��$��1��$��29��$��Bottom=�$��5,0,0,0q��� -   $��10��$
��10,5q�$��2��.����  �� Orientation$ 
Horizontal=�.+��� $��/Assets/warning.png��$	��5 1q�$��Uniform=�$��16���� $��CLEAR ALL DATA�� �� TextAlignment$ Center=�$	��130�����#BFBFBF�� -	   $��11��$��10,20,10,10q�$��2��$
��Save��$
��15 2q�$��Right=��� -
   $��11��$��10 20 80 10q�$��2��$��Reset Settings��$
��15 2q�$��Right=�