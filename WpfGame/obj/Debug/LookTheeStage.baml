   M S B A M L   `   `   `  ����B  >WpfGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfGameWpfGame  5   	       WpfGame.LookTheeStage   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfGame     5   	     � Title$:  4Команди які не пройшли отбір��5   	   $	��600��6/   $	��520��6?   .��5
      � -   5         �Name$ Modal��5
         	GridStyle#���   6   $y�Visible=�6?   $��Center=�6U   $
��1208��6r   $
��2668��6�   $��0,-878,0,-211q�6�   .+�5   
   ��  �� Orientation$ Vertical=�6   $	��500��6,   $��Center=�68   $��Center=�6U   $	��473��6p   $��1082,914,1082,271q�6}   .+�5      �� -   5         ��Name$ listBox��5   &   $��20(�6   $	��375��67   $��10q�6E   $y�Visible=�6Q   ��6f   ��  �� Path$ 
ListGroups� �� View 5      �� 5      .P�5      ��  �� Width$ 50��6~    �� DisplayMemberBinding 6)   �� $ Position� �� UpdateSourceTrigger$ PropertyChanged=�.��6�   №6�   �� 5      $	 150��6y    6)   �� $
 Name�$ PropertyChanged=�.��6�   Назва команди6�   �� 5      $	 200��6z    6)   �� $ Point�$ PropertyChanged=�.��6�   
Бали6�   5      	 � 	Resources	 5      ��%    5      5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5        
 ��Name$
 Right��5       � Cursor$
 Hand��6(   $��10q�66   ���	#FF38A817$	��230��6Y   $y�Hidden=�6e   $��34(�6z   $��7q�6�   $��
Вірно��6�   $	��Top=�6�   �� 5      -   5        $

 Next��5      $
 Hand��6(   $y�Visible=�66   $��10q�6L   $	��230��6Y   $��34(�6e   $��7q�6s   $	��Top=�6�   $��Далі��6�   ���	#FF38A8176�   5      5      5       5#      