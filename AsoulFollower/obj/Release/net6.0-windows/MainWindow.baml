   M S B A M L   `   `   `  ���� H  DAsoulFollower, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AsoulFollowerAsoulFollower  7 clr-namespace:AsoulFollower.xamlAsoulFollower.xaml      AsoulFollower.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  :d2http://schemas.microsoft.com/expression/blend/2008  S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  'localclr-namespace:AsoulFollower  +xaml clr-namespace:AsoulFollower.xaml  -   (  "MahApps.Metro.Controls.MetroWindow   Name$  
SoftWindow�� � Title$ AsoulFollower��$	��665��$
��1140�� � 
ResizeMode$ CanMinimize=� � Icon$ 	/icon.png��.���  � ColumnDefinitions �� $
��157* ��� $
��983* �.+�,  &MahApps.Metro.Controls.MetroTabControl  -     Name$
 Menu��$��1�� �� SelectedIndex$ 1��.@��� $��主页�� �� 
IsSelected$
 True��.��� 
������� �� $	��35* ��� $	��68* ��� $	��35* � � RowDefinitions �� $
��157* ��� $
��240* �.+�%  MahApps.Metro.Controls.FlipView  -   	  Name$	 Banners��$��1��$��0���� -   
 ��Name$
 ListBox_Dynamics��$��3��$��0,5,0,0q�$��1��$��False��.@��� $��正在加载中...���� $��列表��.��� 
�������.+��� -   $
 ListBox_Following��$��False��$ �� IsSynchronizedWithCurrentItem$
 TrueY��� $��Center=�$��38��$��日志��$��Center=�$	��117��.��� ���	#FFE5E5E5.+��� -    ��Name$ ListView_Log��$ FalseY� �� View �� .P��� $��类型�� �� Width$ 50�� �� DisplayMemberBinding �� *Type+�� $��时间��$	 100�� �� *Time+�� $��内容��$	 850�� �� *	Content+)  #MahApps.Metro.Controls.ToggleSwitch  -     Name$ BallonSwitch��$��55��$��更新弹窗��$��	10,10,0,0q�$	��Top=�$	��154��$��2��   
OffContent$ 关闭��   	OnContent$ 开启��  -   $ NotifySwitch��$��55��$��托盘菜单��$��	10,95,0,0q�$	��Top=�$	��154��$��2��$ 关闭��$ 开启��$��Microsoft YaHei)�&   HandyControl.Controls.NotifyIcon  -	     Name$ 
NotifyMenu��$
��Left=�$	��100��$��	0,550,0,0q�$	��Top=�$	��100��   Icon$ 	/icon.png��   Text$# Asoul时代！沸腾期待！�� � ContextMenu �� .@�m� -
    m�Name$ MenuItem_Show��$��显示��m� -   $ MenuItem_Exit��$��退出���� -    ��Name$ Image_UserFace��$
��Left=�$	��120��$��
16,350,0,0q�$	��Top=�$	��120���� -    ��Name$ Label_UserName��$�� ��$
��Left=�$��
16,485,0,0q�$	��Top=�$	��130��$��25���� -   $ 
Label_Coin��$�� ��$
��Left=�$��
16,515,0,0q�$	��Top=�$	��130��$��25���� -    ��Name$ Button_ExitAccount��$��退出登录��$��Center=�$��30��$��	0,570,0,0q�$	��Top=�$��90��  -   $ AutoLikeSwitch��$��55��$��自动点赞��$��
10,180,0,0q�$	��Top=�$	��154��$��2��$ 关闭��$ 开启��$��Microsoft YaHei)�