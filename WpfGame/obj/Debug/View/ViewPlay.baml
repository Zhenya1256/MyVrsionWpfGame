   M S B A M L   `   `   `  ����B  >WpfGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfGame.ViewWpfGame.View  5          WpfGame.View.ViewPlay   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WpfGame.View     5      -   5        $
��auto��5      $
��auto��6     � 	Resources  5         Button.MouseOver.Background �� Color �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value  ButtonTemplate �� 
TargetType	 �� CornerRadius  ButtonsStyleOne
 �� Triggers��%q  &	        '��      &	 �     �� 5   
   $
 #000��6>   �� 5   
   " ��6    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��$ 14(�61   �� 5       � ��
 �  ��63   5      5      �� 5   
   " ��61   .R�5      �� $��border��6   $	 15��6$   
�������$��54(�5   2   #���  6J   ._�5      �� ��. #��z��6>   $��Center=�6a   $��Center=�6~   6�   5      
 5       P� 5!       �@J�IsMouseOver . . �5"      ��  � ��
 �  ��6B   5#      P� 5$       � �� . . �5%      ��  � ��
 � ���6F   5&      5(      5)      .��5+      � -   5        $��
PlayWindow��5+   /     	GridStyle#���  6   .+�5;   
   ]� ��.  .+�5<      � $	��Top=�6   $	��460��6)   .+�5=      �� -   5         ��Name$ textQuation��5=   (   $��80��6   $��28(�6=    �� Padding$ 0,14,0,0q�6K    �� TextAlignment$ Center=�6^   
�������$	��Top=�6�   $
��Bold"�6�    �� LineStackingStrategy$ BlockLineHeight=�6�   $
��Wrap=�6�   $��Oblique$�6�   $��UltraExpanded&�6  6  �� 5>      -   5         ��Name$ Quation��5>      $��/Resourse/music.jpg��6*   $��
0,70,0,-60q�6H   �� 5?      -   5         ��Name$ listBox��5?   *   $��20(�6   $	��400��6;   $	��400��6H   $��10q�6U   $y�Hidden=�6a   ��6u   ��  �� Path$ 
ListGroups� �� View 5@      �� 5A      .P�5B      ��  �� Width$ 50��6�    �� DisplayMemberBinding 6-   �� $ Position� �� UpdateSourceTrigger$ PropertyChanged=�.��6�   №6�   �� 5C      $	 150��6}    6-   �� $
 Name�$ PropertyChanged=�.��6�   Назва команди6�   �� 5D      $	 200��6~    6-   �� $ Point�$ PropertyChanged=�.��6�   
Бали6�   5E        5G      ��%    5I      5J      5K      � 5N      $	��Top=�6   $	��242��6(    � ColumnDefinitions 5O      �� 5P      $
��583* �6'   .+�5U      � $��2��6   .+�5V      �� $��Center=�6   $	 30��6=   
���   �$��2q�6c   $��500,0,500,0q�6w   $	��350��6�   $	��175��6�   $��Bottom=�6�   ._�5W      �� -   5         ��Name$ 
labelTimer��5W   !   $	��116(�6T   $��	8,0,-2,10q�6c   $��Center=�6w   $��Center=�6�   ��65   �� *
TimerValue+6�   5X      5Z      5]      5s      r� 5t   
   -   5         r�Name$ mediaElement��5t      $
��Left=�6-   $	��100��6H   $��-112,271,0,0q�6U   $	��Top=�6k   $	��100��6�   5u      5v      