   M S B A M L   `   `   `  ����Q  MWPF_EmployeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_EmployeeManagementWPF_EmployeeManagement  5   	   '    !WPF_EmployeeManagement.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WPF_EmployeeManagement     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5       � Title$ Product Management��5	   	   $	��750��6$   $	��950��61   .��5
      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��0��6   .+�5      �� $��Employee Management��6   $��Center=�62   $��36(�6O   �� 5       �� Orientation$ 
Horizontal=�6   $��0,20,0,0q�62   .+�5      �� $��Employee ID��6   �� 5      -   5         ��Name$ tbEmployeeID��5       �� 
IsReadOnly$
 True��60    �� TextWrapping$
 Wrap=�6B   $	��781��6W   $��70,0,0,0q�6c   ��6v   ��  �� Path$ 
EmployeeId� � DataContext 6�   �� 	 �� ElementName$	 lvEmployeeManagement��$ SelectedItem�5      �� 5      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5      �� $��	FirstName��6   �� 5      -   5        $ tbsFirstName��5      $
 Wrap=�60   $	��781��6E   $��83,0,0,0q�6Q   ��6c   �� $ 	FirstName� 6�   �� $	 lvEmployeeManagement��$ SelectedItem�5      �� 5      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5      �� $��LastName��6   �� 5      -   5        $ 
tbLastName��5      $
 Wrap=�6.   $	��781��6C   $��83,0,0,0q�6O   ��6a   �� $ LastName� 6�   �� $	 lvEmployeeManagement��$ SelectedItem�5      �� 5      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5       �� $��Email��6   �� 5!      -   5        $ tbEmail��5!      $
 Wrap=�6+   $	��781��6?   $��	108,0,0,0q�6K   ��6_   �� $ Email� 6{   �� $	 lvEmployeeManagement��$ SelectedItem�5"      �� 5#      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5$      �� $��Phone��6   �� 5%      -   5        $ tbPhone��5%      $
 Wrap=�6+   $	��781��6@   $��	103,0,0,0q�6L   ��6`   �� $ Phone� 6|   �� $	 lvEmployeeManagement��$ SelectedItem�5&      �� 5'      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5(      �� $��Hiredate��6   (  "System.Windows.Controls.DatePicker  5)      -   5        
  Name$
 
dpHireDate��5)      $��90,0,0,0q�61   $	��777��6C      Text 6O   �� $ HireDate� 6n   �� $	 lvEmployeeManagement��$ SelectedItem�5*      �� 5+      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5,      �� $��Job Name��6   �� 5-      -   5         ��Name$ 	cbJobName��5-      $	��781��6.   $��83,0,0,0q�6:    �� Text 6L   �� $ Job.JobTitle� 6o   �� $	 lvEmployeeManagement��$ SelectedItem�5.      �� 53      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�54      �� $��
Departmant��6   �� 55      -	   5        $ cbDepartment��55      $	��781��61   $��73,0,0,0q�6=    6P   �� $ Department.DepartmentName� 6�   �� $	 lvEmployeeManagement��$ SelectedItem�56      57      �� 58   
   $��1��6   .+�59      �� $ 
Horizontal=�6   .+�5:      �� .+�5;      �� $
��Name��6   �� 5<      -
   5        $ tbSearchEmpID��5<      $
 Wrap=�65   $	��127��6I   $
��Left=�6U   $��5,0,0,0q�6p   $��25��6�   6�   �� 5=      $��
Department��6   �� 5>      -   5        $ cbDepartmentSearch��5>      $	��126��6;   $
��Left=�6G   $��5,0,0,0q�6b   $��26��6s   6   �� 5?      $��Search HireDate��6     5@      -   5        $
 dpSearchHireDate��5@   !   $	��134��6;   6G   �� 5A      -   5         ��Name$ lblItemCount��5A      $��Count: 0��62   $��25��6E   $��10(�6Q   $y�	Collapsed=�6_   �� 5B      -   5         ��Name$ btnRegionandCountry��5B      $��Region and Country��6:   $��0,30,0,0q�6W   ���	#FF2067D7���	#FFF1E1E16�   �� 5C      -   5        $ btnDepartment��5C      $��
Department��64   ���	#FF2067D7���	#FFF1E1E1$��0,3,0,0q�6w   6�   �� 5D      -   5        $ btnJobs��5D      $
��Jobs��6.   ���	#FF2067D7���	#FFF1E1E1$��0,3,0,0q�6�   �� 5E      -   5        $ btnLocation��5E      $��Location��62   ���	#FF2067D7���	#FFF1E1E1$��0,3,0,0q�6s   6�   5G      �� 5H      -   5         ��Name$ lvEmployeeManagement��5H      $	��243��69   $	��780��6F   $��	15,10,0,0q�6R    �� View 5I      �� 5J      .P�5K      �� $��Employee ID��6-    �� DisplayMemberBinding 6B   �� $ 
EmployeeId��� 5L      $��FullName��6-    6?   �� $ FullName��� 5M      $��Email��6-    6<   �� $ Email��� 5N      $��Phone��6-    6<   �� $ Phone��� 5O      $��Hiredate��6-    6?   �� $ HireDate��� 5P      $��JobName��6-    6>   �� $ Job.JobTitle��� 5Q      $��Manager��6-    6>   �� $ Manager.FullName��� 5R      $��
Department��6-    �� Width$ 80��6A    6L   �� $ Department.DepartmentName�5S      5U      5V      �� 5W      $ 
Horizontal=�6   $��	0,20,25,0q�63   $��Right=�6F   .+�5X      �� -   5        $ 
btnRefresh��5X      $��Refresh��6-   $��36��6?   $	��113��6K   ���	#FF1894E6���	#FFFAF9F9$��50,0,0,0q�6�   �� 5Y      -   5        $ btnAdd��5Y      $	��Add��6)   $��36��67   $	��113��6C   $��20,0,0,0q�6O   ���	#FF00B217
�������6�   �� 5Z      -   5        $ 	btnUpdate��5Z      $��Update��6,   $��36��6=   $	��113��6I   $��20,0,0,0q�6U   ���	#FFF3E509���	#FF6F4E4E6�   �� 5[      -   5        $ 	btnDelete��5[      $��Delete��6,   $��36��6=   $	��113��6I   $��20,0,0,0q�6U   ���	#FFE20101
�������6�   �� 5\      -   5        $ btnExportJSON��5\      $��Export Txt and JSON��60   $��36��6N   $	��113��6Z   $��20,0,0,0q�6f   ���	#FFE20173
�������6�   �� 5]      -   5        $ btnClose��5]      $��Close��6+   $��36��6;   $	��113��6G   $��20,0,0,0q�6S   ���	#FF9E01E2
�������6�   5^      5_      5a      5b      