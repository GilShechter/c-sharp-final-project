   M S B A M L   `   `   `  ����H  Dfinal-project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:final_projectfinal_project  5   	       final_project.ExamWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:final_project     5   	   -   5          � Title$  
ExamWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��3* �6   .+�5   
   � -   5        $��	InnerGrid��5       � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    .+�5      �� -   5        $��QuestionsNumberBox��5      $��Center=�62   
������$��50��6l   �� 5      -   5        $��ListBoxQuestions��5      
�������$��3��6F   $��0q�6T   $��Stretch=�6_   6{   5      � 5   
   $��1��6   $��0��6    5      �� 5      $��* �6#    5      �� 5      $��50 �6    �� 5      $
��auto �6!   �� 5      $
��auto �6    �� 5       $
��auto �6    �� 5!      $
��auto �6    �� 5"      $
��auto �6    �� 5#      $
��auto �6    .+�5&      �� -   5        $��tbTime��5&      $��15(�6&   $��Center=�64   $	��Top=�6Q   $��0��6i   �� 5'      -   5        $��exitExamBtn��5'      $��10(�6(   $��Right=�66   $	��Top=�6R   $��Submit��6j   $��0��6{   $��10q�6�   $��20��6�   $��50��6�   6�   �� 5(      $��1��6   $��Hidden=�6(   $��Hidden=�6M   $	��150��6t   .��5)      �� -   5        $��QuestionContent��5)      $��1��64   $��10,10,10,10q�6A   5*      �� 5+      $��2��6   $��Visible=�6(   $��Disabled=�6N   $	��150��6w   .��5,      �� -   5        $��OptionalAnswers��5,      $��2��64   $��10q�6A   5-      5.      �� 5/   
    �� Orientation$ 
Horizontal=�6   $��1��6/   $��Bottom=�6?   $��Right=�6Z   .+�50      �� -	   5        $��PrevBtn��50   [   $��15(�6   $��10q�6$   $��30��60   $��Previous��6<   $	��100��6O   6j   �� 51      -
   5        $��NextBtn��51   W   $��15(�6   $��10q�6$   $��30��60   $
��Next��6<   $	��100��6K   6f   52      53      54      