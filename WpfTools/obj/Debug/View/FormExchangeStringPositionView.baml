   M S B A M L   `   `   `  ����  WpfTools2    ,WpfTools.View.FormExchangeStringPositionView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0ignorehttp://www.galasoft.ch/ignore     5   	     � Title$  字符串调换位置��5   	    � DataContext 5	   	   �� *FormExchangeStringPosition+   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6    $��中间字符��6-   �� 5   
   $��1��6   $��0��6"    �� 	MaxLength$ 1��6J   ��6/   �� *	MiddleStr+6J   �� 5   
   $��2��6   $��0��6    $��结束字符��6-   �� 5   
   $��3��6   $��0��6"   $ 1��6G   ��6/   �� *EndStr+6G   �� 5   
   $��0��6   $��2��6#   $��1��67   $��	转换前��6D   .��5      ��  �� TextWrapping$
 Wrap=�60    �� AcceptsReturn . ��6   �� *
OlderStr+6D   5      �� 5    
   $��2��6   $��2��6#   $��1��67   $��	转换后��6D   .��5!      �� $
 Wrap=�60    . ��6   �� *
NewerStr+6D   5"      �� 5$   
   $��0��6   $��2��6"   ��6/   �� *
ExtraStr+	� 5%   
   $��1��6   $��2��6&    	� 	GroupName$ group1��63   $��加上��6F   	 d� 	IsChecked	 6S   �� *Add+	� 5&   
   $��2��6   $��2��6&   $ group1��63   $��去掉��6F   	 6S   �� *Minus+�� 5'   
   $��4��6   $��2��6!   $��转换��6.   ��6;   �� *StartCommand+5(      5)      