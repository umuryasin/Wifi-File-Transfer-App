   M S B A M L   `   `   `  ����N  JBuggy File Transfer, Version=2.4.4.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:FileSharingApp_Desktop.PagesFileSharingApp_Desktop.Pages  5      U/clr-namespace:FileSharingApp_Desktop.Properties!FileSharingApp_Desktop.Properties  5      .    (FileSharingApp_Desktop.Pages.OptionsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:FileSharingApp_Desktop.Pages     5      =p/clr-namespace:FileSharingApp_Desktop.Properties     5      -   5          N� Title$  OptionsPage��5
      .��5      � ���#353536$��5,5,5,5q�6     � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $��BC_logo_1.png��6   $��10��6'   $��10��69    J� Opacity$	 0.1Q�6O   �� 5   
   $��0��6   $��0,0,0,2q�6   $
��10,0q�5      
����ح�6   �� 5   
   $��2��6   $��0,0,0,2q�6   $
��10,0q�5      
����ح�6   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�5       $��Center=�60   .+�5!      �� 1   +FileSharingApp_Desktop.Properties.Resources   Options_Title#��Z 6   $��40(�6C   $
��Bold"�6Q   
����İ�$��0��5"   -   5#      � 5&   
   $��1��6    � ColumnDefinitions 5'      �� 5(      $��* �6#   �� 5)      $��3* �6#   .+�5,      ��    Setting_DeviceName#��Z 6   $��0��6H   $��25(�5-      $
��Left=�6"   $��10,0,0,0q�6>   $��center=�5.      
�������6/   �� 50      -   5         ��Name$ txt_DeviceName��50      $��Device Name��6.   $��1��6A   $��0,0,0,2q�51      $��25(�52      $��10q�6$   $��Stretch=�53      $��center=�64   
������� �� 
IsReadOnly .  
������ 54   )   55      � 56   
   $��2��6    57      �� 58      $��* �6#   �� 59      $��3* �6#   .+�5<      �� 	   Setting_Language#��Z	 6   $��0��6F   $��25(�5=      $
��Left=�6"   $��10,0,0,0q�6=   $��center=�5>      
�������6/   �� 5?      -   5        $��Combo_Languages��5?      $	��200��6.   $��1��6:   $��50��6J   
 �� Text$
 English��5@      $
��Left=�6&   $��Center=�6A   
������ 
���  ��$��25(�5B      5C      � 5E   
   $��3��6    5F      �� 5G      $��3* �6#   �� 5H      $��8* �6#   �� 5I      $��* �6#   .+�5L      ��    Setting_OutputFolder#��Z 6   $��0��6J   $��25(�5M      $��10,0,0,0q�6#   $
��Left=�5N      $��center=�5O      
�������6/   �� 5Q      -   5        $ txt_OutputFolder��5Q      $��	bişeyler��60   $��1��5R      $��25(�6&   $��0,0,0,2q�5S      $
��Left=�5T      $��center=�61   
�������$��5q�5U   )    .  
������ $	��500��5V   B   �� 5X      -   5         ��Name$ btn_SelectFolder��5X      $�� ... ��6/      Blue#��[  5Y      $��28(�5Z      $��2��6#   $��Center=�63   $��Center=�5[      62   5\      � 5]   
   $��4��6    5^      �� 5_      $��* �6#   �� 5`      $��* �6#   �� 5a      $��* �6#   .+�5d      �� -   5        $ btn_MainMenu��5d      #��[  5e      $��30q�63   $��25(�5f      $��0��6#   $��Center=�63   $��Stretch=�5g      $��Stretch=�5h      $��Stretch=�6:   .��5j      �� $ 
Horizontal=�6   $	��200��66   .+�5k      �� $��/Icons/Home.png��6   $	��5,0q�66   $	�� 35��5l       $��50��6-   $
��Left=�5m       �� 5n         Done_btnHome#��Z 6    $��WrapWithOverflow=�6K   $	��5,0q�5o   !   $��Center=�5p   !   $��Right=�6<   5q      5r      �� 5t      -   5        $ btn_Save��5t      $��25(�6'    	 Green#��[ 5u      $��30q�64   $��2��5v      $��Center=�6%   $��Stretch=�5w      $��Center=�5x      .��5z      �� $ 
Horizontal=�6   $	��150��66   .+�5{      �� $��/Icons/save.png��6   $	�� 35��5|       $��50��6-   $
��Left=�5}       $	��5,0q�5~   ,   �� 5�         Setting_btnSave#��Z 6    $	��5,0q�6O   $��Center=�5�   !   $��Right=�6<   5�      5�      5�      5�      5�      