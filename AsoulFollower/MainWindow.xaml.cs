using AsoulFollower.funcs;
using AsoulFollower.objs;
using AsoulFollower.utils;
using AsoulFollower.xaml;
using AsoulFollower.xamls;
using HandyControl.Controls;
using HandyControl.Tools.Extension;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Image = System.Windows.Controls.Image;
using MessageBox = System.Windows.MessageBox;

namespace AsoulFollower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static List<String> liveRooms = new List<string>();
        private static List<SpaceHistoryPage.DataObject.CardNodeObject> originalDynamicsList = new List<SpaceHistoryPage.DataObject.CardNodeObject>();
        public static List<FollowingModel> models = new List<FollowingModel>();
        public DynamicUpdatedEvent updatedEvent; //声明全局监听器变量
        public bool Dynamic_isFirst = true; //动态列表是否初次加载
        public static LogUtil log;

        public static List<SpaceHistoryPage.DataObject.CardNodeObject> OriginalDynamicsList { get => originalDynamicsList; set => originalDynamicsList = value; }

        public MainWindow()
        {
            InitializeComponent();
            log = new LogUtil(this); //初始化LogUtil
        }
        //Banner选择事件
        private void Banners_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var fv = (FlipView)sender;
            fv.BannerText = liveRooms[fv.SelectedIndex] + "的直播间";

        }

        //菜单显示按钮按下
        private void MenuItem_Show_Click(object sender, RoutedEventArgs e)
        {
            var nm = (NotifyIcon)sender;
            nm.IsBlink = false;
            this.Show();
        }

        //覆写关闭事件
        protected override void OnClosing(CancelEventArgs e)
        {
            if (ConfigLoader.Config.Notify_menu)
            {
                this.Hide();
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        //关闭程序
        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        //初始化窗口
        private async void MetroWindow_Initialized(object sender, EventArgs e)
        {
            await ConfigLoader.load(); //加载配置文件
            BallonSwitch.IsOn = ConfigLoader.Config.Ballon_mode;
            NotifySwitch.IsOn = ConfigLoader.Config.Notify_menu;
            AutoLikeSwitch.IsOn = ConfigLoader.Config.Autolike_mode;
            await log.Logger(LoggerType.Info, "配置文件加载完毕！");
            foreach (var model in ConfigLoader.Config.Subscribe_list)
            {
                if (model.Is_selected)
                {
                    models.Add(new FollowingModel(model.Uid));
                    await log.Logger(LoggerType.Info, String.Format("载入对象：UID {0}", model.Uid));
                }
            }
            {
                var request = new HttpRequest(ConfigLoader.LoginInfoURL);
                String content = await request.getContentAsync();
                var page = JsonConvert.DeserializeObject<LoginInfoPage>(content);
                updatedEvent = new DynamicUpdatedEvent(models, this);
                updatedEvent.DynamicUpdatedEventListener += new DynamicUpdatedEvent.UpdatedHandler(SubscribeEvent.updateListBox);
                updatedEvent.DynamicUpdatedEventListener += new DynamicUpdatedEvent.UpdatedHandler(SubscribeEvent.noticeBoxShow);
                updatedEvent.DynamicUpdatedEventListener += new DynamicUpdatedEvent.UpdatedHandler(SubscribeEvent.autolike);
                updatedEvent.DynamicFirstUpdatedEventListener += new DynamicUpdatedEvent.UpdatedHandler(SubscribeEvent.updateListBox); //注册事件
                if (page.Code != 0)
                {
                    var loginWindow = new Login(this);
                    loginWindow.Show();
                }
                else
                {
                    updatedEvent.run();

                    ViewLoad();
                    ShowUserInfo(page);
                }

            }//检查是否登录
        }

        //菜单是否打开
        private async void NotifySwitch_Toggled(object sender, RoutedEventArgs e)
        {
            var ts = (ToggleSwitch)sender;
            if (ts.IsOn)
            {
                NotifyMenu.Show();
            }
            else
            {
                NotifyMenu.Hide();
            }
            ConfigLoader.Config.Notify_menu = ts.IsOn;
            await ConfigLoader.save();
        }
        //Banner点击事件
        private void Banners_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var b = (FlipView)sender;
            Clipboard.SetText("https://live.bilibili.com/" + ConfigLoader.Config.Subscribe_list[b.SelectedIndex].Live_room);
            MessageBox.Show("已添加到剪贴板\nhttps://live.bilibili.com/" + ConfigLoader.Config.Subscribe_list[b.SelectedIndex].Live_room);
        }
        //窗口加载成功
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            NotifyMenu.IsBlink = false; //取消闪烁

        }

        //加载窗口组件
        public async void ViewLoad()
        {
            {
                var fl = (ListBox)ListBox_Following;
                foreach (Config.SubscribeModel model in ConfigLoader.Config.Subscribe_list)
                {
                    try
                    {
                        var fi = new Following();
                        var getSpaceInfo = new GetSpaceInfo(model.Uid);
                        var data = await getSpaceInfo.getInfo();
                        fi.Name.Content = data.Name;
                        fi.Sign.Text = data.Sign;
                        fi.Head.Source = new BitmapImage(new Uri(data.Face));
                        fi.SelectedSwitch.IsOn = model.Is_selected;
                        fi.UUid = model.Uid;

                        var banner = new Image();
                        banner.Source = new BitmapImage(new Uri(data.Live_room.Cover));
                        liveRooms.Add(data.Name);
                        Banners.Items.Add(banner);
                        //Banner加载

                        model.Live_room = data.Live_room.Roomid;
                        //直播间设置
                        fl.Items.Add(fi);
                    }
                    catch (Exception)
                    {
                        continue;
                    }//处理异常
                }
            }  //加载关注与banner
            {
                if (ConfigLoader.Config.Notify_menu)
                {
                    NotifyMenu.Show();
                }
                else
                {
                    NotifyMenu.Hide();
                }
            }  //加载开关
            BannerLoop(); //开始banner循环
        }

        //展示用户信息
        public void ShowUserInfo(LoginInfoPage page)
        {
            Image_UserFace.Source = new BitmapImage(new Uri(page.Data.Face));
            Label_UserName.Content = "昵称：" + page.Data.Uname;
            Label_Coin.Content = "硬币：" + String.Format("{0:F1}", page.Data.Money);
        }

        //banner循环
        private void BannerLoop()
        {
            int cnt = 0;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5); //5s一循环
            timer.Tick += (o, e) => { cnt = cnt % Banners.Items.Count; Banners.SelectedIndex = cnt; cnt++; };
            timer.Start();
        }

        //退出登录按钮
        private async void Button_ExitAccount_Click(object sender, RoutedEventArgs e)
        {
            HttpRequest.cookie = new System.Text.StringBuilder("");
            ConfigLoader.Config.Cookie = "";
            ConfigLoader.Config.Csrf = "";
            await log.Logger(LoggerType.Info, "登出账号");
            MessageBox.Show("账号登出成功！请重新进入！");
            await ConfigLoader.save();
            Environment.Exit(0);
        }

        //双击托盘菜单
        private void NotifyMenu_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var nm = (NotifyIcon)sender;
            nm.IsBlink = false;
            this.Show();
        }

        //自动点赞模式点击
        private async void AutoLikeSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            var ts = (ToggleSwitch)sender;
            ConfigLoader.Config.Autolike_mode = ts.IsOn;
            await log.Logger(LoggerType.Info, String.Format("自动点赞：{0}", ts.IsOn));
            await ConfigLoader.save();

        }

        //气泡弹窗模式点击
        private async void BallonSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            var ts = (ToggleSwitch)sender;
            ConfigLoader.Config.Ballon_mode = ts.IsOn;
            await log.Logger(LoggerType.Info, String.Format("气泡消息：{0}", ts.IsOn));
            await ConfigLoader.save();
        }
    }
}
