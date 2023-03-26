using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// UserDynamics.xaml 的交互逻辑
    /// </summary>
    public partial class UserDynamics : UserControl
    {
        public UserDynamics()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public String Title { get; set; }
        public String HeadURL { get; set; }
        public String DynamicContent { get; set; }
        public String Dynamic_URL { get; set; }

        private void grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(Dynamic_URL);
            MessageBox.Show("已复制到剪贴板，粘贴到浏览器打开");
        }
    }
}
