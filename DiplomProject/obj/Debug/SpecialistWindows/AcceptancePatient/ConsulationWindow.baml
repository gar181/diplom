   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   H DDiplomProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:DiplomProject.RegistrationWindows!DiplomProject.RegistrationWindows 5   	   9   3DiplomProject.RegistrationWindows.ConsulationWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:DiplomProject.RegistrationWindows     5   	     � Icon$  /Images/logo.ico��5   	    � Title$E ?Врач - Направление на консультацию��5
   	   $	��450��64   $	��800��6A    � WindowStartupLocation$ CenterScreen=�6M   .��5      �  � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      �� 5      �� 5      �� 5      $��75 �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��
Назад��5      $	��175��6!   $��50��6-   $��Right=�69   $	��Top=�6U   $��	0,10,20,0q�6m   $��22(�6�   $��3��6�   6�   �� 5   
   $ ��Специализация��6   $��0��6)   $��1��69   $��22(�6F   $��Right=�6T   $��Center=�6p   �� 5   
   -   5        $��specialization_cmb��5      $��1��6-   $��1��6:   $��10,20q�6J   $	��175��6Y   $��30��6e   $��Center=�6q   6�   �� 5   
   $��Специалист��6   $��0��6&   $��2��66   $��22(�6C   $��Right=�6Q   $��Center=�6m   �� 5   
   -   5        $��employees_cmb��5      $��2��6(   $��1��65   $��10,20q�6E   $	��175��6T   $��30��6`   $��Center=�6l   6�   �� 5!   
   $��Кабинет��6   $��0��6#   $��3��63   $��22(�6@   $��Right=�6N   $��Center=�6j   �� 5"   
   -   5        $��room_cmb��5"      $��3��6#   $��1��60   $��10,20q�6@   $	��175��6O   $��30��6[   $��Center=�6g   6�   �� 5$   
   $��Дата��6   $��2��6    $��2��60   $��22(�6=   $��Right=�6K   $��Center=�6g   (  "System.Windows.Controls.DatePicker  5%   
   -   5        $��date_dp��5%      $��2��6$   $��3��61   $��10,20q�6A   $	��175��6P   $��30��6\   $��Center=�6h    �� Today   DisplayDateStart# Z 6�   �� 5'   
   $��
Время��6   $��2��6!   $��3��61   $��22(�6>   $��Right=�6L   $��Center=�6h   �� 5(   
   -   5        $��time_cmb��5(      $��3��6#   $��3��60   $��10,20q�6@   $	��175��6O   $��30��6[   $��Center=�6g   6�   �� 5)   
   $��Пациент��6   $��2��6#   $��1��63   $��22(�6@   $��Right=�6N   $��Center=�6j   $��100,20,10,20q�6�   �� 5*   
   -   5        $��patients_txb��5*      $��1��6&   $��3��63   $��10,20q�6C   $	��175��6R   $��30��6^   $��Center=�6j   |�.  6�   �� 5+   
   -   5        $��Записать��5+      $	��175��6$   $��50��60   $��Center=�6<   $��Bottom=�6Y   $��	0,10,0,15q�6t   $��22(�6�   $��0��6�   $��4��6�   $��5��6�   6�   5,      5-      