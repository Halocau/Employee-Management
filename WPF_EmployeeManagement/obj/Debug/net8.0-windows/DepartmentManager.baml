   M S B A M L   `   `   `  ����Q  MWPF_EmployeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_EmployeeManagementWPF_EmployeeManagement  5   	   .    (WPF_EmployeeManagement.DepartmentManager   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WPF_EmployeeManagement     5   	   -   5          � Title$  
MainWindow��5   	   $	��400��63   $	��920��6@   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      $��4* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �� -   5         ��Name$ dt��5      $��0��6!   .+�5      �� $��
Department��6   $��Center=�6)   $
��Bold"�6F   $��24(�6X   ���	#FFF714146f   �� 5      $��Department ID��6   $��10,0,0,0q�6,   �� 5      -   5         ��Name$ tbDepartmentID��5       �� 
IsReadOnly$
 True��6.    �� TextWrapping$
 Wrap=�6A   $	��355��6U    J� RenderTransformOrigin$ 0.051,0.566&�6a   $
��Left=�6�   $��13,0,0,0q�6�   $��26��6�   ��6�   ��  �� Path$ DepartmentId� � DataContext 6�   �� 	 �� ElementName$	 lvDeparment��$ SelectedItem��� 5      -   5        
 ��Name$
 	FirstName��5      $��Department Name��6'   $��10,0,0,0q�6A   �� 5      -   5        $ tbDepartmentName��5      $
 Wrap=�61   $	��355��6E   $ 0.051,0.566&�6Q   $��26��6u   $
��Left=�6�   $��15,0,0,0q�6�   ��6�   �� *DepartmentName+ 6�   �� *SelectedItem+$	 lvDeparment��6�   �� 5      $��Manager Name��6   $��10,0,0,0q�6+   �� 5      -   5         ��Name$ 	cbManager��5      $	��352��6*   $
��Left=�66   $��15,0,0,0q�6Q   �� 5      $��StreetAddress��6   $��10,0,0,0q�6,   �� 5      -   5        $ tbStreetAddress��5      $
 True��6/   $
 Wrap=�6B   $	��357��6V   $ 0.051,0.566&�6b   $��26��6�   $��	13,0,13,0q�6�   $
��Left=�6�   ��6�   �� $ Location.StreetAddress� 6�   �� $	 lvDeparment��$ SelectedItem��� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 
btnRefresh��5      $��Refresh��6-   $��28��6?   $��67��6K   $��	10,10,0,0q�6V   ���	#FF11C0E66�   �� 5      -	   5        $ 	btnInsert��5      $��Insert��6,   $��28��6=   $��67��6I   $��	10,10,0,0q�6T   ���	#FF39F0176~   �� 5      -
   5        $ 	btnUpdate��5      $��Update��6,   $��28��6=   $��67��6I   $��	10,10,0,0q�6T   ���	#FFDBF6156~   �� 5      -   5        $ 	btnDelete��5      $��Delete��6,   $��28��6=   $��67��6I   $��	10,10,0,0q�6T   ���	#FFE230086~   �� 5      -   5        $ btnClose��5      $��Close��6+   $��28��6;   $��67��6G   ���	#FFFF2FFA$��	10,10,0,0q�6j   6}   5      5#      �� 5$   
   $��1��6   .+�5%      �� -   5         ��Name$ lvDeparment��5%      $	��281��6,   $	��509��69   $��10,0,0,0q�6�    �� View 5&      �� 5'      .P�5(      �� $��DepartmentID��6)    �� Width$ 90��6?    �� DisplayMemberBinding 6J   �� $ DepartmentId��� 5)      $��DepartmentName��6)   $	 130��6A    6M   �� $ DepartmentName��� 5*      $��Manager��6)   $	 110��6:    6F   �� $ Manager.FullName��� 5+      $��StreetAddress��6)   $	 150��6@    6L   �� $ Location.StreetAddress�5,      5.      50      51      52      