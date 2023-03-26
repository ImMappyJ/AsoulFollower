using AsoulFollower.utils;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsoulFollower.xaml
{
    /// <summary>
    /// FollowersInfo.xaml 的交互逻辑
    /// </summary>
    public partial class Following : UserControl
    {
        public Following()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public String HeadURLSource { get; set; }
        public String NameText { get; set; }
        public String SignText { get; set; }
        public String UUid { get; set; }
        public bool IsSelected { get; set; }

        private async void SelectedSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            var ts = (ToggleSwitch)sender;
            foreach(Config.SubscribeModel model in ConfigLoader.Config.Subscribe_list)
            {
                if(model.Uid == UUid)
                {
                    model.Is_selected = ts.IsOn;
                }
            }
            await ConfigLoader.save();
        }
    }
}
