   M S B A M L   `   `   `  ����N  JBuggy File Transfer, Version=2.4.4.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FileSharingApp_DesktopFileSharingApp_Desktop  5   	   '    !FileSharingApp_Desktop.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:FileSharingApp_Desktop     5   	   -   5          � Title$  Buggy File Transfer ��5	   	   $	��650��5
   	   $	��800��5   	    � 
ResizeMode$ CanMinimize=�5   	   ���#353536.��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��10* �6   .+�5   
   � $��0��6   ���#1E88FA.+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��/Pages/BC_logo_1.png��6   $
��20,5q�5      $
��Left=�5      �� 5      $��Buggy Company��6   $
��Bold"�60   $��20(�6B   $��Center=�5      $
��Left=�6/   
�������$��Italic$�5   '   5      5       �� 5"   
   $ 
Horizontal=�6   $��Right=�5#      $��10,0,5,0q�5$      .+�5&      �� -   5         ��Name$ Btn_Blogger��5&      $	��100��6+   $��50��67   $	��0,5q�5'      
������ $��0q�5(   .   .��5)      �� 
��� ���$��1q�6.   
��� ��� �� CornerRadius$ 2��6V   ._�5*      �� $ 
Horizontal=�6!   
������ .+�5+      �� $��/Icons/blogger.png��6    $��25��6<   �� 5,      $��Blogger��6    
�������$
��Bold"�6F   5-      5.      50      �� 52      -   5        $ Btn_Patreon��52      $	��100��6*   $��50��66   $	��0,5q�53      
������ $��0q�54   .   .��55      �� 
�������$��1q�61   
�������$ 2��6\   ._�56      �� $ 
Horizontal=�6!   .+�57      �� $��/Icons/patreon.png��6   $��25��68   �� 58      $��Patreon��6    
�������$
��Bold"�6E   59      5:      5<      �� 5>      -   5        $ Btn_Instagram��5>      $	��100��6,   $��50��68   $	��0,5q�5?      
������ $��0q�5@   .   .��5A      �� 
���\\��$��1q�61   
���\\��$ 2��6\   ._�5B      �� $ 
Horizontal=�6!   
���\\��.+�5C      �� $��/Icons/instagram.png��6   $��25��6:   �� 5D      $��	Instagram��6    
�������$
��Bold"�6G   5E      5F      5H      �� 5J      -   5        $ Btn_Youtube��5J      $	��100��6*   $��50��66   $	��0,5q�5K      
������ $��0q�5L   .   .��5M      �� 
����p��$��1q�65   
����p��$ 2��6d   ._�5N      �� $ 
Horizontal=�6!   
����p��.+�5O      �� $��/Icons/youtube.png��6   $��25��68   �� 5P      $��Youtube��6    
�������$
��Bold"�6E   5Q      5R      5T      �� 5U      -   5        $ Btn_PlayStore��5U      $��0,4,0,0q�5V      
������ $��0q�5W   .   .��5X      �� $��/Icons/playstoreGet.png��6    $	��100��6A   $��Center=�5Y       $��Center=�6;   5[      5]       � 5_   
   -   5          �Name$ 	MainFrame��5_      $��1��5`      $��Center=�5a      $��Center=�6)     � NavigationUIVisibility$ Hidden=�5b      $	��800��5c      $	��560��6   5d      5h      