using AsoulFollower.utils;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AsoulFollower.xamls
{
    /// <summary>
    /// BallonMessage.xaml 的交互逻辑
    /// </summary>
    public partial class BallonMessage : MetroWindow
    {
        //重载窗口
        public BallonMessage(String title,String face,String content)
        {
            InitializeComponent();
            BeepUtil.Beep(1000, 1000);
            this.Left = SystemParameters.WorkArea.Right - this.Width;
            this.Top = SystemParameters.WorkArea.Bottom - this.Height;
            FaceImage.Source = new BitmapImage(new Uri(face));
            Label_Uname.Content = title;
            Label_Content.Content = content;
        }

        //窗口加载成功
        private void MetroWindow_Loaded(object sender, EventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 6); //6s后自动关闭
            timer.Tick += (s, t) => { this.Close(); timer.Stop(); };
            timer.Start();
        }
    }
}
