using AsoulFollower.funcs;
using AsoulFollower.objs;
using AsoulFollower.utils;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Windows;
using System.Windows.Threading;

namespace AsoulFollower.xamls
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : MetroWindow
    {
        MainWindow mainwindow;
        /// <summary>
        /// 初始化登录界面
        /// </summary>
        /// <param name="mainwindow">传入主界面</param>
        public Login(MainWindow mainwindow)
        { 
            InitializeComponent();
            this.mainwindow = mainwindow;
        }

        public bool isLogin { get; set; }

        private DispatcherTimer timer = new DispatcherTimer();
        private GetLoginToken token = new GetLoginToken();

        //强制在最前行
        private void LoginWindow_Deactivated(object sender, EventArgs e)
        {
            var mw = (MetroWindow)sender;
            mw.Activate();
        }
        //若被强制关闭则整个程序退出
        private void LoginWindow_Closed(object sender, EventArgs e)
        {
            if (!isLogin)
            {
                Environment.Exit(0);
            }
        }

        private async void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {
            var generator = new QRCodeGenerator();
            var data = generator.CreateQrCode(await token.getLoginURL(), QRCodeGenerator.ECCLevel.Q);
            var code = new QRCode(data);
            QRCodeImage.Source = BitmapUtil.bitmap2bitmapImage(code.GetGraphic(32));
        }

        //登录窗口加载完成加载二维码
        private async void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            mainwindow.Hide();
            var generator = new QRCodeGenerator();
            var data = generator.CreateQrCode(await token.getLoginURL(), QRCodeGenerator.ECCLevel.Q);
            var code = new QRCode(data);
            QRCodeImage.Source = BitmapUtil.bitmap2bitmapImage(code.GetGraphic(32));
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += async (t, s) => {
                var status = await token.getScanStatus();
                if (status.Data.Code == 0)
                {
                    MessageText.Text = "登录成功...正在跳转";
                    if (Toggle_RememberMe.IsOn)
                    {
                        ConfigLoader.Config.Cookie = HttpRequest.cookie.ToString();
                        ConfigLoader.Config.Csrf = HttpRequest.csrf.ToString();
                        await ConfigLoader.save();
                    }
                    isLogin = true;
                    var request = new HttpRequest(ConfigLoader.LoginInfoURL);
                    String content = await request.getContentAsync();
                    var page = JsonConvert.DeserializeObject<LoginInfoPage>(content);
                    mainwindow.updatedEvent.run();
                    mainwindow.Show();
                    mainwindow.Activate();
                    mainwindow.ViewLoad();
                    mainwindow.ShowUserInfo(page);
                    LoginWindow.Close();
                    timer.Stop();
                }
                else
                {
                    MessageText.Text = status.Data.Message;
                }
            };
            timer.Start();
        }
    }
}
