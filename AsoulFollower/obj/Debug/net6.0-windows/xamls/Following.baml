   M S B A M L   `   `   `  ����H  DAsoulFollower, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AsoulFollower.xamlAsoulFollower.xaml  5      "    AsoulFollower.xaml.Following   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:AsoulFollower.xaml     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      -   5          >�Name$  FollowingControl��5   G   $	��110��5      $	��980��6,   .��5	      � $��Center=�6   $	��980��6(   $	��100��64   $	��Top=�6A    � RowDefinitions 5
   
   �� 5      $	��19* �6   �� 5      $	��13* �6    � ColumnDefinitions 5   
   �� 5      $
��162* �6   �� 5      $
��643* �6   �� 5      $
��175* �6   .+�5   
   �� -   5         ��Name$
 Head��5      $
��Left=�6   $��95��69   $��25,5,0,0q�6E   $	��Top=�6W   $��95��6o   $��2��6z   ��6�   �� *HeadURLSource+ J� Clip 5      @� 5       @� RadiusX$
 47.5Q�6"    @� RadiusY$
 47.5Q�61    @� Center$ 	47.5,47.5&�6@   5      �� 5   
   -   5         ��Name$
 Name��5      $
��Left=�6;   $��Center=�6V   $��50��6q   $	��798��6}   $	��800��6�   $��2��6�   $��30(�6�   $��	Condensed&�6�   $��1��6�   ��6   �� *
NameText+6�   �� 5   
   -   5        	 ��Name$
	 Sign��5      $��Center=�6"   $
��Wrap=�6?   $��Center=�6m   $��40��6�   $	��623��6�   $	��800��6�   $��15(�6�   $��1��6�   $��1��6�   ��6S   �� *
SignText+6�   )  #MahApps.Metro.Controls.ToggleSwitch  5   
   -   5        
  Name$
 SelectedSwitch��5      $��2��63   $��31��6C   $	��134��6O   2  ,MahApps.Metro.Controls.HeaderedControlHelper%   HeaderVerticalContentAlignment$ Bottom=�6w      
OffContent$ 	未订阅��6�      	OnContent$ 订阅��6�   $��1��6�   $��Center=�6�      IsOn 6[   �� *
IsSelected+6  5      5      