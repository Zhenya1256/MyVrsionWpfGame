   M S B A M L   `   `   `  ����B  >WpfGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfGameWpfGame  5   	       WpfGame.StartGame   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfGame     5   	     � Title$  	StartGame��5   	    � WindowState$ 	Maximized=�6   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��269* �6   �� 5      $
��242* �6   �� 5      $
��249* �6    � RowDefinitions 5   
   �� 5      $��63 �6   �� 5      .+�5   
   �� -   5         ��Name$ 	textBlock��5      $��Налаштування��6%   $��0��6<   ���#99e$��30(�6]   �� 5   
   -   5        $ Close��5      $��=��6    $��0��6,   $��2��6:   $	��250��6K   ���#99e$��30(�6j   �� 5   
   $��0��6   
�������$��3��69   $��1��6M   .+�5      ]� .+�5      �� -   5         ��Name$ 	menuPanel��5      $��Right=�60   
����� �$	��250��6Z   $��
0,0,0,-559q�6g   .+�5      �� $��Center=�6   $��30(�69   .��6G   	Етап16N   �� 5       $��Center=�6   $��30(�69   .��6G   	Етап26N   �� 5!      $��Center=�6   $��30(�69   .��6G   	Етап36N   �� 5"      $��Center=�6   $��30(�69   $��	Етап4��6G   �� 5#      $��Center=�6   $��30(�69   .��6G   	Етап56N   5%      � 5'      $
��Left=�6   $	��454��6-   $	��542��6:   .+�5)      �� $��Center=�6<   $��20(�6Y   $��Center=�6g   $	��300��6�   $	��300��6�   $��Почати
    Гру��6�   ��6   �� *	StartPlay+6�   5*      5+      5,      5.      51      