   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      W SPicBro.Globalization.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqPclr-namespace:PicBro.Globalization.Windows;assembly=PicBro.Globalization.WindowsPicBro.Globalization.Windows 5      O KPicBro.Shell.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:PicBro.Shell.Windows.ConverterPicBro.Shell.Windows.Converter 5      Q-clr-namespace:PicBro.Shell.Windows.PropertiesPicBro.Shell.Windows.Properties 5	      0   *PicBro.Shell.Windows.Views.ImageHeaderView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      f	resourcesPclr-namespace:PicBro.Globalization.Windows;assembly=PicBro.Globalization.Windows     5      B	converter,clr-namespace:PicBro.Shell.Windows.Converter     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      D
properties-clr-namespace:PicBro.Shell.Windows.Properties     5	        � 	Resources  5      <  6PicBro.Shell.Windows.Converter.SortBySelectonConverter   SortBySelectionConverter  RadioButtonResource J� IsHitTestVisible 	� 	GroupName
 � Tag �� 
TargetType �� BasedOn �� Property �� Value `� 	Converter	 �� Path
 �� RelativeSource �� Mode �� AncestorType��%�  &	        &	     7	�7     5   
   6,   	� 5   
   $��Center=�5      $��3q�5       .  $
 sort��5       5      �� *SortBy+��5      �� 5      " 	�6   8   .�5      ��  �@d�	IsChecked 5      `� 5      8  .1�5   "   �� $	 Header�6*   
 5   *   �� $ FindAncestor=�$ MenuItemL��� 5   "   $		 Tag�6*   
 5   *   �� *Self+5      5       5!      5#      5$      .��5%      �  � RowDefinitions 5&   
   �� 5'      $
��Auto �6   �� 5(      $��* �6    � ColumnDefinitions 5*   
   �� 5+      $
��Auto �6    �� 5,      $��* �6   �� 5-      $
��Auto �6    �� 5.      $
��Auto �6    �� 5/      $
��Auto �6    .+�51   
   o� $��14(�6   $��2��52      
������ .@�54      m� $
��FILE��6   .@�55      m� $��_Add directory��6    m� Command 56      �� *AddFolderCommand+�� 58      m� 59      $��E_xit��6    5:      �� *ExitCommand+5;      m� 5=      $
��HELP��6   .@�5>      m� -   5        $��About��5>      5?      m� 5@      $��Tutorial��6    5A      �� *LaunchTutorialCommand+5B      5C      �� 5D   
   $��1��6   $
��BACK��5E      $��5q�5F      $��12(�5H      $��1q�5I        MetroFlatButton#���  5J      $
��Left=�5K      $��Center=�5L      ��5G      �� *BackCommand+5L      �� 5M   
   $��1��6   $��1��5N      $��Center=�5P      $��16(�5Q      $��30��5R      *   $MahApps.Metro.Controls.TextboxHelper   	Watermark$ Search��5T         ClearTextButton . $��5q�5V      {�5O      �� *EnableSearchSort+��5S      �� *
SearchText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5V       J� InputBindings 5W      �� 5X      
 �� Key$ Enter��6    �� Command 5Y      �� *SearchCommand+.��5Z   %   5[      �� 5]   
   $��80��5_      $��Center=�5`       �� Interval$ 25��5b       � SmallChange$ 25Q�5c       � LargeChange$ 25Q�5d       �� IsSnapToTickEnabled . $��1��5g      $��2��5h      $��	10,0,10,0q�5j       � Maximum 5]      �� *MaximumSliderValue+ � Minimum 5^      �� *MinimumSliderValue+ � Value 5a      �� *	ThumbSize+$ TwoWay=� �� TickFrequency 5f      �� *SliderIncrement+{�5i      �� *EnableSearchSort+5k      �� 5m   
   $��1��6   $��3��5n      $��Center=�5p      {�5o      �� *EnableSearchSort+��5q      �� . (PicBro.Shell.Windows.Properties.Settings   Default  �� Source#  Z $	 MenuBackground���5r      �� *SearchSettingsCommand+.��5s      F� �����d���� ���\��� H6� n:]H6� ���H6� ��j��\�A��d��A���Aj�A�ӑ���jӑ����ӑ�n:]�Aj��� �d���� �q"�    Q�7�t���zT @Q��t�p��S @S���v��m�E @Ϊ���0�R @���N| @Q&��'���� @Qo�cK�����?Q+u����_B@Ѱ���<� љ��O�� ӡ���� ���Cu� ����� ���ʧ����`�� �ퟧ� P@��~�(L]X��J.Lj��S�L	�?�J@@�	L���6�J
�H�J1C�M����fр���z��~����������ө	�!P����Pz���O�������x������pZ �����ZC��@@5bMѯ���Mө��1�N5%��N���X�M�����Mќ�`���яC� �̑ѹ�� q��Ѵ�� ����I� 3��8�� �j�]~� ����y�� p���7 ���ӯ� �b�?��X��U?�V. @��r
<A� @VW@�@@�L*�I�@����X��� @}U�Tڇa,< @����~�d��< @����    ��c�bȠ��@�P� ��� ��� ѧ7� A�� Ӓe� 	�� �&�0@c�� �M@�� ш�"]� Q�� �����@	$��16��5t      $��16��5u      ! �� Stretch$! Uniform=�5v      $��Center=�5w      $��Center=�5x      
�������5y      5z      o� 5{   
   $��1��6   
������ $��4��5~      {�5|      �� *EnableSearchSort+.@�5      m� $��5q�6   $
��5 10q�5�      ��5�      �� #  Z $	 MenuBackground�" m� Icon" 5�      F� 5�      -   5        # F�Name$# path1��5�      �����`�����@����6����6���V���e@�=������}c!@�=����� �=�� ����� )U��3!� ���
� ʙN�� �e�ӎ�� �c ɢnȥa*[�(�1%�i��I���� -��?I���� -��?z�ѫ� �j��-�� �j���ݿ�^"@�j�y�΀j @����S�@	��R����@�l�\'���Q@����� "#@����?��@�9�J)@ 0c5W_{	@L����/��?�p��� �h)�@��0��� @�)� �ҕ� �)� 0ف���!@Q���S�?Q�
� Q���S�?���5'� /;Ś��?��"�D=&ӇAH(:):�O�*x[ۓ*�x[�X�E_� �X�E_� ۓ*Ѷ�� �V*�=t� �V*��� 0)I�� O�&�tr� 9�$2� X�!2� Ή�2� ��P�� ��~�� '���� �!� ���S~�@�!� ���K��@Md��q ��@?w�o{�Ď@~�o{�Ď@�L��o{�Ď@�� <DH��@�#�VE@"%��ӐU�@g3'� -�@��(2lނ��@ߩ)�)a�J@�B*���:@ۓ*J�@� @ۓ*�J�@� @�X�    �X�    ۓ*��~����?ۓ*������?�)8������?�x(�������?c
'�V��S�?��$UTXZ��?H"�1�
��?A�b  ���V�O�@nB�YDI    ���    ���_�Vѡ�����W5=C�"�Hq����� qI��ѷ�p����_֤C�"ў�����YDI��V	$��16��5�      $��16��5�      $! Uniform=�5�      
�������5�      ��5�      F� 5�      -   5        $# path2��5�      +�������
��)���rA���
����
	$��10��5�      $��10��5�      $��0q�5�      $! Uniform=�5�      
�������5�      ��5�      �� 5�      " m�6   # [Bm�5�      .�5�      ��  �@m�Icon# [ 5�   !   5�      .@�5�      m� -   5        $ m�Name$$ NameMenuItem��5�      $
��Name��5�      $��Center=�5�      $��Center=�5�       5�      �� *SortCommand+% m� CommandParameter% 5�      �� 
 �� *Self+5�      m� 5�      -   5        $��DateMenuItem��5�      $��Date Modified��5�      $��Center=�5�       5�      �� *SortCommand+% 5�      �� 
 �� *Self+5�      m� 5�      -   5        $��SizeMenuItem��5�      $
��Size��5�      $��Center=�5�       5�      �� *SortCommand+% 5�      �� 
 �� *Self+5�      m� 5�      -   5        $��TypeMenuItem��5�      $
��Type��5�      $��Center=�5�       5�      �� *SortCommand+% 5�      �� 
 �� *Self+5�      m� 5�      -   5        $��PopularityMenuItem��5�      $��
Popularity��5�      $��Center=�5�       5�      �� *SortCommand+% 5�      �� 
 �� *Self+5�      5�      5�      5�      5�      