   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:PicBro.Shell.Windows.BehaviorsPicBro.Shell.Windows.Behaviors W SPicBro.Globalization.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqPclr-namespace:PicBro.Globalization.Windows;assembly=PicBro.Globalization.WindowsPicBro.Globalization.Windows O,clr-namespace:PicBro.Shell.Windows.ConverterPicBro.Shell.Windows.Converter Q-clr-namespace:PicBro.Shell.Windows.PropertiesPicBro.Shell.Windows.Properties ,   &PicBro.Shell.Windows.Views.MenuBarView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     B	behaviors,clr-namespace:PicBro.Shell.Windows.Behaviors     f	resourcesPclr-namespace:PicBro.Globalization.Windows;assembly=PicBro.Globalization.Windows     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  <	converter,clr-namespace:PicBro.Shell.Windows.Converter  >
properties-clr-namespace:PicBro.Shell.Windows.Properties    � 	Resources  <  6PicBro.Shell.Windows.Converter.SortBySelectonConverter   SortBySelectionConverter  RadioButtonResource J� IsHitTestVisible 	� 	GroupName
 � Tag �� 
TargetType �� BasedOn �� Property �� Value `� 	Converter	 �� Path
 �� RelativeSource �� Mode �� AncestorType��%�   &	        &	     7	�7     	� $��Center=�$��3q� .  $
 sort�� �� *SortBy+���� " 	�8   .���  �@d�	IsChecked `� 8  .1��� $	 Header�
 �� $ FindAncestor=�$ MenuItemL��� $		 Tag�
 �� *Self+.���  � RowDefinitions �� $
��Auto ��� $��* � � ColumnDefinitions �� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�o� $��14(�$��2��
������ .@�m� $
��FILE��.@�m� $��_Add directory�� m� Command �� *AddFolderCommand+m� $��Remove from Database�� �� *RemoveFolderFromDBCommand+ m� Icon �� $��/Assets/delete.png��$��Uniform=��� m� $��E_xit�� �� *ExitCommand+m� $
��HELP��.@�m� -   $��About��m� $��Tutorial�� �� *LaunchTutorialCommand+ �� $��/Assets/help_16.png��$��Uniform=��� $��1��$��Center=�$��16(�$��30��*   $MahApps.Metro.Controls.TextboxHelper   	Watermark$ Search��   ClearTextButton . $��5q����� *
SearchText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.�� J� InputBindings �� 
 �� Key$ Enter�� �� Command �� *SearchCommand+.��.  (System.Windows.Interactivity.Interaction   	Behaviors 2  ,PicBro.Shell.Windows.Behaviors.FocusBehavior     IsFocus �� *IsFocusSearch+$ TwoWay=�.���� $��80��$��Center=� �� Interval$ 25�� � SmallChange$ 25Q� � LargeChange$ 25Q� �� IsSnapToTickEnabled . $��1��$��1��$��	10,0,10,0q� � Maximum �� *MaximumSliderValue+ � Minimum �� *MinimumSliderValue+  � Value  �� *	ThumbSize+$ TwoWay=�! �� TickFrequency! �� *SliderIncrement+�� $��1��$��2��$��Center=�$��0q����� . (PicBro.Shell.Windows.Properties.Settings"   Default# �� Source## Z" $	 MenuBackground����� *SearchSettingsCommand+.��F� �����d���� ���\��� H6� n:]H6� ���H6� ��j��\�A��d��A���Aj�A�ӑ���jӑ����ӑ�n:]�Aj��� �d���� �q"�    Q�7�t���zT @Q��t�p��S @S���v��m�E @Ϊ���0�R @���N| @Q&��'���� @Qo�cK�����?Q+u����_B@Ѱ���<� љ��O�� ӡ���� ���Cu� ����� ���ʧ����`�� �ퟧ� P@��~�(L]X��J.Lj��S�L	�?�J@@�	L���6�J
�H�J1C�M����fр���z��~����������ө	�!P����Pz���O�������x������pZ �����ZC��@@5bMѯ���Mө��1�N5%��N���X�M�����Mќ�`���яC� �̑ѹ�� q��Ѵ�� ����I� 3��8�� �j�]~� ����y�� p���7 ���ӯ� �b�?��X��U?�V. @��r
<A� @VW@�@@�L*�I�@����X��� @}U�Tڇa,< @����~�d��< @����    ��c�bȠ��@�P� ��� ��� ѧ7� A�� Ӓe� 	�� �&�0@c�� �M@�� ш�"]� Q�� �����@	$��16��$��16��$ �� Stretch$$ Uniform=�$��Center=�$��Center=�
�������o� $��1��
������ $��3��.@�m� $��5q�$
��5 10q����� ## Z" $	 MenuBackground� F� -   % F�Name$% path1�������`�����@����6����6���V���e@�=������}c!@�=����� �=�� ����� )U��3!� ���
� ʙN�� �e�ӎ�� �c ɢnȥa*[�(�1%�i��I���� -��?I���� -��?z�ѫ� �j��-�� �j���ݿ�^"@�j�y�΀j @����S�@	��R����@�l�\'���Q@����� "#@����?��@�9�J)@ 0c5W_{	@L����/��?�p��� �h)�@��0��� @�)� �ҕ� �)� 0ف���!@Q���S�?Q�
� Q���S�?���5'� /;Ś��?��"�D=&ӇAH(:):�O�*x[ۓ*�x[�X�E_� �X�E_� ۓ*Ѷ�� �V*�=t� �V*��� 0)I�� O�&�tr� 9�$2� X�!2� Ή�2� ��P�� ��~�� '���� �!� ���S~�@�!� ���K��@Md��q ��@?w�o{�Ď@~�o{�Ď@�L��o{�Ď@�� <DH��@�#�VE@"%��ӐU�@g3'� -�@��(2lނ��@ߩ)�)a�J@�B*���:@ۓ*J�@� @ۓ*�J�@� @�X�    �X�    ۓ*��~����?ۓ*������?�)8������?�x(�������?c
'�V��S�?��$UTXZ��?H"�1�
��?A�b  ���V�O�@nB�YDI    ���    ���_�Vѡ�����W5=C�"�Hq����� qI��ѷ�p����_֤C�"ў�����YDI��V	$��16��$��16��$$ Uniform=�
���������F� -   $% path2��+�������
��)���rA���
����
	$��10��$��10��$��0q�$$ Uniform=�
����������� " m�# [Bm�.���  �@m�Icon# [ .@�m� -   & m�Name$& NameMenuItem��$
��Name��$��Center=�$��Center=� �� *SortCommand+' m� CommandParameter' �� 
 �� *Self+m� -   $��DateMenuItem��$��Date Modified��$��Center=� �� *SortCommand+' �� 
 �� *Self+m� -   $��SizeMenuItem��$
��Size��$��Center=� �� *SortCommand+' �� 
 �� *Self+m� -   $��TypeMenuItem��$
��Type��$��Center=� �� *SortCommand+' �� 
 �� *Self+m� -   $��PopularityMenuItem��$��
Popularity��$��Center=� �� *SortCommand+' �� 
 �� *Self+