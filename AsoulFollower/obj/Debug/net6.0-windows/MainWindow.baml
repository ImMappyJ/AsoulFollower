   M S B A M L   `   `   `  ����H  DAsoulFollower, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AsoulFollowerAsoulFollower  5   	   7 clr-namespace:AsoulFollower.xamlAsoulFollower.xaml  5	   	       AsoulFollower.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   'localclr-namespace:AsoulFollower  5   	   +xaml clr-namespace:AsoulFollower.xaml  5	   	   -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  
SoftWindow��5	   7    � Title$ AsoulFollower��5   	   $	��665��6   $
��1140��6,    � 
ResizeMode$ CanMinimize=�69    � Icon$ 	/icon.png��6R   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��157* �6   �� 5      $
��983* �6   .+�5   
   ,  &MahApps.Metro.Controls.MetroTabControl  -   5          Name$
 Menu��5      $��1��6,    �� SelectedIndex$ 1��6<   .@�5      �� $��主页��6    �� 
IsSelected$
 True��6"   .��5      � 
������� 5      �� 5      $	��35* �6+   �� 5      $	��68* �6+   �� 5      $	��35* �6+    � RowDefinitions 5      �� 5      $
��157* �6(   �� 5      $
��240* �6(   .+�5      %  MahApps.Metro.Controls.FlipView  -   5        	  Name$	 Banners��5   #   $��1��64   $��0��6D   6}   �� 5      -   5        
 ��Name$
 ListBox_Dynamics��5      $��3��68   $��0,5,0,0q�6L   $��1��6]   $��False��6j   .@�5      �� $��正在加载中...��6&   5       5!      5"      �� 5#      $��列表��6   .��5$      � 
�������.+�5%      �� -   5        $
 ListBox_Following��5%      $��False��69   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6_   5&      5'      �� 5(      $��Center=�6   $��38��63   $��日志��6?   $��Center=�6K   $	��117��6f   .��5)      � ���	#FFE5E5E5.+�5*      �� -   5         ��Name$ ListView_Log��5*      $ FalseY�66    �� View 5+      �� 5,      .P�5-   "   �� $��类型��61    �� Width$ 50��6=    �� DisplayMemberBinding 6H   �� *Type+�� 5.   "   $��时间��61   $	 100��6=    6I   �� *Time+�� 5/   "   $��内容��61   $	 850��6=    6I   �� *	Content+50      52      53      54      55      )  #MahApps.Metro.Controls.ToggleSwitch  56   
   -   5          Name$ BallonSwitch��56      $��55��61   $��更新弹窗��6=   $��	10,10,0,0q�6K   $	��Top=�6^   $	��154��6v   $��2��6�      
OffContent$ 关闭��6�      	OnContent$ 开启��6�   6�     57   
   -   5        $ NotifySwitch��57      $��55��61   $��托盘菜单��6=   $��	10,95,0,0q�6K   $	��Top=�6^   $	��154��6v   $��2��6�   $ 关闭��6�   $ 开启��6�   $��Microsoft YaHei)�6�   6�   &   HandyControl.Controls.NotifyIcon  58   
   -	   5          Name$ 
NotifyMenu��58      $
��Left=�6,   $	��100��6G   $��	0,550,0,0q�6T   $	��Top=�6g   $	��100��6      Icon$ 	/icon.png��6�      Text$# Asoul时代！沸腾期待！��6�    � ContextMenu 59      �� 5:      .@�5;      m� -
   5         m�Name$ MenuItem_Show��5;      $��显示��66   6B   m� 5<      -   5        $ MenuItem_Exit��5<      $��退出��66   6B   5=      5?      �� 5@   
   -   5         ��Name$ Image_UserFace��5@      $
��Left=�6(   $	��120��6C   $��
16,350,0,0q�6P   $	��Top=�6d   $	��120��6|   �� 5A   
   -   5         ��Name$ Label_UserName��5A      $�� ��6(   $
��Left=�63   $��
16,485,0,0q�6N   $	��Top=�6b   $	��130��6z   $��25��6�   �� 5B   
   -   5        $ 
Label_Coin��5B      $�� ��6$   $
��Left=�6/   $��
16,515,0,0q�6J   $	��Top=�6^   $	��130��6v   $��25��6�   �� 5C   
   -   5         ��Name$ Button_ExitAccount��5C      $��退出登录��6-   $��Center=�6<   $��30��6Y   $��	0,570,0,0q�6e   $	��Top=�6x   $��90��6�   6�     5D   
   -   5        $ AutoLikeSwitch��5D      $��55��63   $��自动点赞��6?   $��
10,180,0,0q�6M   $	��Top=�6a   $	��154��6y   $��2��6�   $ 关闭��6�   $ 开启��6�   $��Microsoft YaHei)�6�   6�   5E      5F      