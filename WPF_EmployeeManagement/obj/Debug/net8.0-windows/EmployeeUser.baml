   M S B A M L   `   `   `  ����Q  MWPF_EmployeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_EmployeeManagementWPF_EmployeeManagement  5   	   )    #WPF_EmployeeManagement.EmployeeUser   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WPF_EmployeeManagement     5   	   -   5          � Title$  EmployeeUser��5   	   $	��770��65   $	��660��6B   .��5	      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #F0F0F0��6    � Offset$ 0Q�6/   � 5      $ #FFFFFF��6   $ 1Q�6/   5      .+�5   
   �� ���#3F51B5 �� CornerRadius$ 5��6&   $��60��67   $	��Top=�6C   $��0,0,0,20q�6[   ._�5      �� $��Employee Profile��6   
�������$��24(�6C   $
��Bold"�6Q   $��Center=�6c   $��Center=�6~   5      �� 5   
   -   5         ��Name$ tbEmployeeId��5      $y�	Collapsed=�6(   �� 5   
   $	��Top=�6   $
��Left=�6-   $��	29,81,0,0q�6H   $	��600��6[   .+�5      �� $��
Full Name:��6   $
��Bold"�6*   $��0,0,0,5q�6<   �� 5      -   5        $ 
tbFullName��5       �� 
IsReadOnly$
 True��6*   $��0,0,0,10q�6<   $��16(�6N   $��5q�6\   �� 5      $��Email:��6   $
��Bold"�6&   $��0,0,0,5q�68   �� 5      -   5        $ tbEmail��5      $
 True��6'   $��0,0,0,10q�69   $��16(�6K   $��5q�6Y   �� 5!      $��Phone:��6   $
��Bold"�6&   $��0,0,0,5q�68   �� 5"      -   5        $ tbPhone��5"      $
 True��6'   $��0,0,0,10q�69   $��16(�6K   $��5q�6Y   �� 5$      $��	HireDate:��6   $
��Bold"�6)   $��0,0,0,5q�6;   �� 5%      -   5        $ 
tbHireDate��5%      $
 True��6*   $��0,0,0,20q�6<   $��16(�6N   $��5q�6\   �� 5&      $	��600��6   .+�5'      �� $��	Job Name:��6   $
��Bold"�6-   $��0,0,0,5q�6?   �� 5(      -   5        $ 	tbJobName��5(      $
 True��6-   $��0,0,0,10q�6?   $��16(�6Q   $��5q�6_   �� 5*      $��Salary��6   $
��Bold"�6*   $��0,0,0,5q�6<   �� 5+      -   5        $ tbSalary��5+      $
 True��6,   $��0,0,0,10q�6>   $��16(�6P   $��5q�6^   �� 5-      $��Commission_pct:��6   $
��Bold"�63   $��0,0,0,5q�6E   �� 5.      -	   5        $ tbCommission_pct��5.      $
 True��64   $��0,0,0,10q�6F   $��16(�6X   $��5q�6f   �� 50      $��Manager Name:��6   $
��Bold"�61   $��0,0,0,5q�6C   �� 51      -
   5        $ 	tbManager��51      $
 True��6-   $��0,0,0,20q�6?   $��16(�6Q   $��5q�6_   �� 53      $��Department:��6   $
��Bold"�6/   $��0,0,0,5q�6A   �� 54      -   5        $ tbDepartment��54      $
 True��60   $��0,0,0,20q�6B   $��16(�6T   $��5q�6b   55      56      �� 59   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Bottom=�6J   $��	0,0,23,17q�6e   .+�5:      �� -   5        	 ��Name$	 btnEdit��5:      $
��Edit��6&   $	��100��65   $��35��6A   $��0,0,10,0q�6M   ���#3F51B5
�������$
��Bold"�6�   6�   �� 5;      -   5        $	 btnSave��5;      $
��Save��6&   $	��100��65   $��35��6A   ���#4CAF50
�������$
��Bold"�6u   6�   5<      5=      5>      