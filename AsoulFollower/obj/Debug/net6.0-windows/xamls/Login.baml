   M S B A M L   `   `   `  ����H  DAsoulFollower, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AsoulFollower.xamlsAsoulFollower.xamls  5   	       AsoulFollower.xamls.Login   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   -local!clr-namespace:AsoulFollower.xamls  5   	   S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  LoginWindow��5   <   $	��390��5	      $	��325��6'    � Icon$ 	/icon.png��63    � Topmost$
 True��6D    � 
ResizeMode$ NoResize=�6�    � Title$ B站扫码登录��6�   .��5
      �  � RowDefinitions 5   
   �� 5      $	��18* �6   �� 5      $��7* �6   .+�5   
   �� -   5         ��Name$ Button_Refresh��5      $��刷新��6)   $��Center=�66   $��0,30,0,0q�6S   $	��Top=�6e   $��50��6}   $	��102��6�   $��1��6�   �� 5   
   -   5         ��Name$ QRCodeImage��5      $
��Left=�6%   $	��250��6@   $��35,0,0,0q�6M   $	��Top=�6_   $	��250��6w   #  HandyControl.Controls.TextBox  5   
   -   5          Name$ MessageText��5      $��Center=�6*   $��0,8,0,0q�6G   $��1��6X   	 �� TextWrapping$
	 Wrap=�6e   $	��Top=�6y   $	��120��6�   ${�False��6�   )  #MahApps.Metro.Controls.ToggleSwitch  5   
   -   5        
  Name$
 Toggle_RememberMe��5      $��31��66   $��
218,40,0,0q�6B   $��1��6V   $	��122��6c   $	��Top=�6o   $��15(�6�      	OnContent$ 	记住我��6�      
OffContent$ 	记住我��6�   5      5      