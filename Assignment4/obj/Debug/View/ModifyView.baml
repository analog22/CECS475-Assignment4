   M S B A M L   `   `   `  ����F  BAssignment4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Assignment4.ViewAssignment4.View  5   	   !    Assignment4.View.ModifyView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Assignment4.View     5   	   -   5          �Name$  ModifyCustomerView��5   	    � Title$ Modify Customer��5   	   $	��270��6!   $	��600��6.   .��5	      �  � DataContext 6   �� *
ModifyView+   Locator �� Source# [  .+�5
   
   �� $
��Name��6   $
��Left=�6   $��	38,22,0,0q�6:   $	��Top=�6M   �� 5   
   $��Address��6   $
��Left=�6"   $��	38,62,0,0q�6=   $	��Top=�6P   �� 5   
   $
��City��6   $
��Left=�6   $��
38,102,0,0q�6:   $	��Top=�6N   �� 5   
   $��State��6   $
��Left=�6    $��
38,142,0,0q�6;   $	��Top=�6O   �� 5   
   $��Zip Code��6   $
��Left=�6#   $��372,142,0,0q�6>   $	��Top=�6S   �� 5   
   -   5         ��Name$ 
AddNameBox��5      $
��Left=�6&   $��26��6A   $��	96,22,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��459��6�   ��5      �� *	NameBox+�� 5   
   -   5        $ AddAddressBox��5      $
��Left=�6)   $��26��6D   $��	96,62,0,0q�6P   $
 Wrap=�6c   $	��Top=�6w   $	��459��6�   ��5      �� *
AddressBox+�� 5   
   -   5        $ 
AddCityBox��5      $
��Left=�6&   $��26��6A   $��
96,102,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��459��6�   ��5      �� *	CityBox+�� 5   
   -   5        $ AddZipCodeBox��5      $
��Left=�6)   $��26��6D   $��435,142,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   ��5      �� *
ZipCodeBox+�� 5   
   -   5         ��Name$ StatesComboBox��5      $
��Left=�6+   $��
96,142,0,0q�6F   $	��Top=�6Z   $	��271��6r   $��26��6~    �� DisplayMemberPath$ 	StateName��5   Y   ��6   �� *States+ �� SelectedItem 62   �� *SelectedState+6Y   �� 5   
   -   5        	 ��Name$	 AcceptButton��5      $��Accept��6'   $
��Left=�68   $��
96,194,0,0q�6S   $	��Top=�6g   $��75��6   ��5      �� *AcceptCommand+
 �� Mode$
 OneWay=���5      ��  �� ElementName$ ModifyCustomerView���� 5   
   -   5        $	 CancelButton��5      $��Cancel��6'   $
��Left=�68   $��480,194,0,0q�6S   $	��Top=�6h   $��75��6�   ��5      �� *CloseWindowCommand+$
 OneWay=���5      �� $ ModifyCustomerView��5      5       