   M S B A M L   `   `   `  ���� N  JBuggy File Transfer, Version=2.4.6.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:FileSharingApp_Desktop.PagesFileSharingApp_Desktop.Pages  U/clr-namespace:FileSharingApp_Desktop.Properties!FileSharingApp_Desktop.Properties  /    )FileSharingApp_Desktop.Pages.TransferPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:FileSharingApp_Desktop.Pages     =p/clr-namespace:FileSharingApp_Desktop.Properties     -     N� Title$  TransferPage��.��� ���#353536$��5,5,5,5q� � RowDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��BC_logo_1.png��$��10��$��10�� J� Opacity$	 0.1Q��� $��0��$��0,0,0,2q�$
��10,0q�
����ح��� $��6��$��0,0,0,2q�$
��10,0q�
����ح��� -    ��Name$ lbl_info��1   +FileSharingApp_Desktop.Properties.Resources   Transfer_InfoMessage#��Z $��Center=�$��Center=�
�������$��25(�� $��1�� � ColumnDefinitions �� $��* ��� $��3* �.+���    Transfer_Filename#��Z $
��Left=�$��Center=�$��25(�
�������$��0���� -   $ lbl_FileName��$
��Left=�$��Center=�$��25(�
�������$��1��� $��2�� �� $��* ��� $��3* �.+���    Transfer_FileSize#��Z $
��Left=�$��Center=�$��25(�
�������$��0���� -   $ lbl_FileSize��$
��Left=�$��Center=�$��25(�
�������$��1��� $��3�� �� $��* ��� $��3* �.+���    Transfer_TransferSpeed#��Z $
��Left=�$��Center=�$��25(�
�������$��0���� -   $ lbl_TransferSpeed��$
��Left=�$��Center=�$��25(�
�������$��1��� $��4��$��5q� �� $	��12* ��� $��2* ��� $��1* ��� $��2* �.+��� 	 �� Orientation$	 
Horizontal=�$��0��.+��� -   $ lbl_totalSent��$��	125.56 MB��$��Center=�
�������$��25(��� $��/��
�������$��Center=�$��25(��� -   $ lbl_totalSize��$��	500.56 MB��$��Center=�
�������$��25(��� -   $ lbl_currentFileNumber��$��10��$��1��
�������$��25(�$��Center=�$��Right=��� $��/��$��2��
�������$��25(�$��Center=�$��Center=��� -	   $ lbl_FileCount��$��14��$��3��
�������$��25(�$��Center=�$
��Left=�� -
   
 �Name$
 prg_Transfer��$��10q�   BlueProgress#��[  $��5��$��LeftToRight=�$��Center=�$��Center=�$��50��$	��700�� � Value$ 50Q�
��������� -   $ lbl_progress��$	��%50��$��5��
�������
������ $��Center=�$��Center=�$��25(�� $��6�� �� $��* ��� $��* �.+��� $	 
Horizontal=�$��0��$��5,0,5,0q�.+���    Transfer_Time#��Z 
�������
������ $��Center=�$��Center=�$��25(��� -   $ lbl_PassedTime��
�������
������ $��Center=�$��Center=�$��25(��� $	 
Horizontal=�$��1��$��5,0,5,0q�.+���    Transfer_Remaining#��Z 
�������
������ $��Center=�$��Center=�$��25(��� -   $ lbl_RemainingTime��
�������
������ $��Center=�$��Center=�$��25(�� $��7�� �� $��* ��� $��* ��� $��* ��� $��* �.+��� -    ��Name$ btn_AbortTransfer��$��4��  Red#��[ $��5q�$��25(�$��Center=�$��Stretch=�
�������.���� $	 
Horizontal=�$	��150��.+��� $��/Icons/x-mark.png��$��35��$��40��$
��Left=�$	��5,0q���    Transfer_btnAbort#��Z $	��5,0q�$��Center=�$��Right=�