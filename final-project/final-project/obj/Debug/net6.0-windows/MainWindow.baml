   M S B A M L   `   `   `  ����H  Dfinal-project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:final_projectfinal_project  5   	       final_project.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:final_project     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   
����2��.��5	      � .+�5
   
   �� $��50,50,50,50q�6    �� CornerRadius$ 20��6&   
�������._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��10q�6C   .+�5      �� -   5        $��	hello_msg��5       $��18(�61   5      �� 5      -   5         ��Name$ Add_Exam_Button��5   '   $��0��6   $��5q�6^   $��Add Exam��6j   $��70��6}   $
��Left=�6�   $��594,10,0,10q�6�   �� 5      $��1��6   $ 
Horizontal=�6*   $��Center=�6C   .+�5      �� $��Search Exam:��6    $��18(�64   $��10q�6B   $��Center=�6N   �� 5      -   5        $��
Search_bar��5      $	��300��60   $��10q�6<   $��30��6H   $��Center=�6T   6v   5      �� 5      $��2��6   $��20q�6*   .+�5      �  � ColumnDefinitions 5      �� 5      61   �� 5       61   .+�5"      �� -   5        $��	ExamsList��5"   2   $��0��6"   $	��150��6C   $	��300��6P   $
��Left=�6\   
�������5#      �� 5$      $��1��6%   $	��300��65   
�������.+�5%      �� -   5        $��examDateLbl��5%   $   $��Date:��67   $
��Bold"�6G   6[   �� 5&      -   5        $��
examDateTB��5&   (   $��10, 0, 0, 0q�6:   6Q   �� 5'      -   5        $��examTeacherLbl��5'   $   $��Teacher:��6:   $
��Bold"�6M   6a   �� 5(      -   5        $��examTeacherTB��5(   (   $��10, 0, 0, 0q�6=   6T   �� 5)      -	   5        $��examDurationLbl��5)   $   $��	Duration:��6;   $
��Bold"�6O   6c   �� 5*      -
   5        $��examDurationTB��5*   (   $��10, 0, 0, 0q�6>   6U   5+      5,      5-      �� 5.      -   5        $��Start_Exam_Button��5.      $��2��62   $��70��6?   $��Right=�6J   $��
0,182,36,3q�6f   $��2��6z   ${�False��6�   .��6�   
Start Exam6�   �� 5/      -   5        $��View_Exam_Button��5/      $��2��61   $��70��6>   $��Right=�6I   $��
0,182,36,3q�6e   $��2��6y   ${�False��6�   .��6�   	View Exam6�   �� 50      -   5        $��Edit_Exam_Button��50      $��2��61   $��70��6>   $��Right=�6I   $��0,182,120,3q�6e   $��2��6z   ${�False��6�   $y�Hidden=�6�   .��6�   	Edit Exam6�   52      54      55      56      