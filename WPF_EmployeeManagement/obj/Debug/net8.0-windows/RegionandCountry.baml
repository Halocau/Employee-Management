   M S B A M L   `   `   `  ����Q  MWPF_EmployeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_EmployeeManagementWPF_EmployeeManagement  5   	   -    'WPF_EmployeeManagement.RegionandCountry   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WPF_EmployeeManagement     5   	     � Title$  
MainWindow��5   	   $	��530��6   $	��800��6)   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      $	��500 �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ CountryDataGrid��5         AutoGenerateColumns$ False��60      CanUserAddRows$ False��6L      
IsReadOnly$
 True��6c   $��10q�6u      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Country ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6[   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   �� *	CountryId+6[     5      $ Country Name��6)   $ * 6_   	 6?   �� *CountryName+6_     5      $ 	Region ID��6)   $ * 6\   	 6<   �� *Region.Name+6\   5        5      -   5        $ RegionDataGrid��5      $��0��6/   $ False��6?   $ False��6[   $
 True��6r   $��10q�6�   $y�	Collapsed=�6�    5        5      $ 	Region ID��6)   $ * 6Y   	 6<   �� *
RegionId+6Y     5      $ Region Name��6)   $ * 6]   	 6>   �� *
RegionName+6]   5      5      � 5   
   $��1��6   $��10q�6   .+�5       �� $��Table��6   $
��Left=�6$   $	��Top=�6?   $��	10,10,0,0q�6W   �� 5!      -   5        
 ��Name$
 Tables��5!      $
��Left=�6'   $	��Top=�6B   $	��168��6Z    �� SelectedIndex$ 0��5"   D   $��
102,10,0,0q�6V   �� 5$      -   5         ��Name$ ID_Label��5$      $��
Country ID��6&   $
��Left=�6;   $	��Top=�6V   $��	10,33,0,0q�6n    J� RenderTransformOrigin$ 0.377,2.005&�6�   �� 5%      -   5         ��Name$ 
ID_TextBox��5%      $
��Left=�6*    �� TextWrapping$
 Wrap=�6E   $	��Top=�6Y   $	��168��6q   $��
102,37,0,0q�6}   �� 5'      -   5        $ 
Name_Label��5'      $��Country Name��6(   $
��Left=�6?   $	��Top=�6Z   $��	10,56,0,0q�6r   �� 5(      -   5        $ Name_TextBox��5(      $
��Left=�6,   $
 Wrap=�6G   $	��Top=�6[   $	��168��6s   $��
102,60,0,0q�6   �� 5*      -   5        $ Label_3��5*      $��	Region ID��6%   $
��Left=�69   $	��Top=�6T   $��	10,79,0,0q�6l   �� 5+      -	   5        $ 	TextBox_3��5+       �� 
IsReadOnly$
 True��6)   $
��Left=�6;   $
 Wrap=�6V   $	��Top=�6j   $	��168��6�   $��
102,83,0,0q�6�   �� 5-      -
   5        $��Create��5-      $��30��6B   $��10,349,140,85q�6N   
������
�������6}   �� 5.      -   5        $��Update��5.      $��30��6B   $��145,349,10,85q�6N   
���"�"�
�������6~   �� 5/      -   5        $��Delete��5/      $��30��6B   $��10,384,140,50q�6N   
��� ���
�������6|   �� 50      -   5        $��Clear��50      $��30��6A   $��145,384,10,50q�6M   
��� ���
�������6x   �� 51      -   5        $��Close��51      $��30��6%   $��10,419,145,15q�61   ���	#FFD700FF
�������6r   52      53      54      