   M S B A M L   `   `   `  ����F  BAssignment4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment4Assignment4  5   	       Assignment4.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Assignment4     5   	   -   5          �Name$  MainView��5   	    � Title$ Customer Maintenance��5   	   $	��350��6&   $	��550��63   .��5	      �  � DataContext 6   �� *Main+   Locator �� Source# [  .+�5
   
   �� $
��Left=�6   $��	30,40,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��70��6n   $��20��6y   $��Customer ID��6�   �� 5   
   $
��Left=�6   $��	30,90,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��70��6n   $��20��6y   $
��Name��6�   �� 5   
   $
��Left=�6   $��
30,120,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��70��6o   $��20��6z   $��Address��6�   �� 5   
   $
��Left=�6   $��
30,150,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��70��6o   $��20��6z   $
��City��6�   �� 5   
   $
��Left=�6   $��
30,180,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��70��6o   $��20��6z   $��State��6�   �� 5   
   $
��Left=�6   $��340,180,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��70��6p   $��20��6{   $��Zip Code��6�    J� RenderTransformOrigin$ 3.757,-0.69&�6�   �� 5   
   -   5         ��Name$ CustomerIDBox��5      $
��Left=�6)   $��20��6D   $��
120,40,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��120��6�   ��5      �� *CustomerIDBox+�� 5   
   -   5        $ CustomerNameBox��5      $
��Left=�6+   $��20��6F   $��
120,90,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $	��360��6�    �� 
IsReadOnly . ��5      �� *	NameBox+�� 5   
   -   5        $ CustomerAddressBox��5      $
��Left=�6.   $��20��6I   $��120,120,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��360��6�    . ��5      �� *
AddressBox+�� 5   
   -   5        $ CustomerCityBox��5      $
��Left=�6+   $��20��6F   $��120,150,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��360��6�    . ��5      �� *	CityBox+�� 5   
   -   5        $ CustomerStateBox��5      $
��Left=�6,   $��20��6G   $��120,180,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��200��6�    . ��5      �� *
StateBox+�� 5   
   -   5        $ CustomerZipCodeBox��5      $
��Left=�6.   $��20��6I   $��400,180,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $��80��6�    . ��5       �� *
ZipCodeBox+�� 5!   
   -   5         ��Name$ GetCustomerButton��5!      $��Get Customer��6,   $
��Left=�6C   $��
265,40,0,0q�6^   $	��Top=�6r   $	��120��6�   ��5"      �� *GetCustomerCommand+�� 5#   
   -	   5        $ 	AddButton��5#      $	��Add��6$   $
��Left=�62   $��
50,250,0,0q�6M   $	��Top=�6a   $��75��6y   ��5$      �� *AddCustomerCommand+�� 5%   
   -
   5        $ ModifyButton��5%      $��Modify��6'   $
��Left=�68   $��140,250,0,0q�6S   $	��Top=�6h   $��75��6�   ��5&      �� *ModifyCustomerCommand+{�5'      �� *ButtonIsEnabled+�� 5(   
   -   5        $ DeleteButton��5(      $��Delete��6'   $
��Left=�68   $��230,250,0,0q�6S   $	��Top=�6h   $��75��6�   ��5)      �� *DeleteCustomerCommand+{�5*      �� *ButtonIsEnabled+�� 5+   
   -   5        $ 
ExitButton��5+      $
��Exit��6%   $
��Left=�64   $��400,250,0,0q�6O   $	��Top=�6d   $��75��6|   ��5,      �� *CloseWindowCommand+	 �� Mode$	 OneWay=���5-      �� 
 �� ElementName$
 MainView��5.      5/      