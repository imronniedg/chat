   M S B A M L   `   `   `  ����?  ;Chat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ChatChat  5   	       Chat.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Chat     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � -   5         � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $	��23* �6   .+�5   
   �� -   5         ��Name$ usernameLbl��5      $
��Left=�6)   $��235,131,0,0q�6D   $
��Wrap=�6Y   $��	Username:��6m   $	��Top=�6~   $��63��6�   $��1��6�   �� 5   
   -   5         ��Name$ usernameField��5      $
��Left=�6)    �� TextWrapping$
 Wrap=�6D   $	��Top=�6X   $	��120��6p   $��312,131,0,0q�6|   4  .System.Windows.Automation.AutomationProperties   Name$ userNameField��6�   $��1��6�   �� 5   
   -   5        $ passwordLbl��5      $
��Left=�6)   $��235,163,0,0q�6D   $
��Wrap=�6Y   $��	Password:��6m   $	��Top=�6~   $��63��6�   $��1��6�   G� 5   
   -   5         G�Name$ passwordField��5      $
��Left=�6-   $��312,160,0,0q�6H   $	��Top=�6]   $	��120��6u   $ passwordField��6�   $��1��6�   �� 5   
   -   5         ��Name$ loginBtn��5      $��Login��6#   $
��Left=�63   $��274,276,0,0q�6N   $	��Top=�6c   $��96��6{   $��29��6�   $��1��6�   �� 5   
   -   5        $ serverIPLbl��5      $
��Left=�6)   $��235,239,0,0q�6D   $
��Wrap=�6Y   $��
Server IP:��6m   $	��Top=�6   $��63��6�   $��1��6�   �� 5   
   -   5        $ serverIPField��5      $
��Left=�6)   $
 Wrap=�6D   $	��Top=�6X   $	��120��6p   $��312,237,0,0q�6|   $ userNameField��6�   $��1��6�   	� 5   
   -	   5         	�Name$ 	serverOpt��5      $��1��6)   $��Server��69   $
��Left=�6J   $��256,204,0,0q�6e   $	��Top=�6z   	 d� 	IsChecked$
	 TrueY�6�   6�   	� 5   
   -
   5        $ 	clientOpt��5      $��1��6)   $��Client��69   $
��Left=�6J   $��345,204,0,0q�6e   $	��Top=�6z   6�   5      5      