   M S B A M L   `   `   `  ����C  ?PWLocker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PWLockerPWLocker  5   	       PWLocker.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:PWLocker     5   	   -   5          �Name$  foOldal��5       � Title$ 
MainWindow��5   	   $	��600��6   $	��910��6)    � 
ResizeMode$ NoResize=�5	   	    � 	Resources 5
      ��%    5      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      �� 5      $��50 �6   .+�5   
   �� ���#0b0c10$��0��6)   �� 5   
   ���#0b0c10$��2��6)   �� 5   
   -   5        $��GridValtoz0��5   ^   $��0��6   $��0��6   $��0,0,0,5q�6.   ���#c5c6c76^   �� 5   
   -   5        $��GridValtoz1��5   ^   $��2��6   $��0��6   $��0,5,0,0q�6.   ���#c5c6c76^   � 5   
   $��1��6   $��2��6    � ColumnDefinitions 5      �� 5      $	��.1* �6#   �� 5      $	��.9* �6#   .+�5       �� ���#1f2833$��1��6-   $��0��6:   �� 5!      ���#1f2833$��1��6-   $��1��6:   �� 5#      $��1��6   $
��Auto=�6(   $��0��6K   .��5$      �� .+�5%         PWLocker.BaseButton     PWLocker.BaseButton   Click$ addButtonClick��6�   $��Add new��6'      PrimaryButtonStyle#��[  69   $��80��6e   $��80��6q   $��0,10,0,0q�6|   $��0q�6�   6�     5&      $��Coming soon...��6'   #��[  6@   $��80��6l   $��80��6x   $��0,10,0,0q�6�   $��0q�6�   5'      5(      �� 5)      $��1��6   $
��Auto=�6(   $��1��6K   .��5*      �� -   5        $��mainStackPanel��5*      5,      5-      �� 5.      -   5        $��GridValtoz2��5.   b   $��1��6   $��1��6"   $��5,0,0,0q�62   ���#c5c6c76b   5/      �� 50   
   -   5        $��
lbUsername��50   W   $��username��6   $
��Left=�6#   $	��Top=�6?   $��50��6i   $	��100��6u   $��
561,23,0,0q�6�   $��20(�6�   ���#45a29e6�     51   
   -   5          Name$ btnLogin��51   +   $ LoginButtonClick��6�   $��Login��6     SecondaryButtonStyle#��[ 6=   $��50��6k   $	��100��6w   $��
786,14,0,0q�6�   $	��Top=�6�   $��20(�6�   $
��Left=�6�     52   
   -   5        $ btnRegister��52   .   $ RegisterButtonClick��6�   $��Register��6   #��[ 6C   $��50��6q   $	��110��6}   $��
666,14,0,0q�6�   $	��Top=�6�   $��20(�6�   $
��Left=�6�   �� 53   
   -	   5        $��50��53      $��50��6   $��10,0,0,0q�6(   $��Center=�6:   $
��Left=�6U   
������ ��6�   Z� .��54      �� $��/PNG/SettingsNeon.png��6   55      58      59      