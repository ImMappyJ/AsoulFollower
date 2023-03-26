using AsoulFollower.objs;
using AsoulFollower.utils;
using AsoulFollower.xaml;
using AsoulFollower.xamls;
using HandyControl.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using MessageBox = System.Windows.MessageBox;

namespace AsoulFollower.funcs {
    public class FollowingModel
    {
        private SpaceHistoryPage.DataObject.CardNodeObject pre_Top, now_Top;
        private String uid;

        public FollowingModel(String uid)
        {
            this.Uid = uid;
        }

        public SpaceHistoryPage.DataObject.CardNodeObject Pre_Top { get => pre_Top; set => pre_Top = value; }
        public SpaceHistoryPage.DataObject.CardNodeObject Now_Top { get => now_Top; set => now_Top = value; }
        public string Uid { get => uid; set => uid = value; }
    }

    public class DynamicUpdatedEvent
    {
        public delegate void UpdatedHandler(SpaceHistoryPage.DataObject.CardNodeObject card,MainWindow window);
        public event UpdatedHandler DynamicUpdatedEventListener;
        public event UpdatedHandler DynamicFirstUpdatedEventListener;
        public static List<FollowingModel> followingModels = new List<FollowingModel>();
        public static MainWindow mainwindow;

        public DynamicUpdatedEvent(List<FollowingModel> models,MainWindow window)
        {
            mainwindow = window;
            followingModels = models;
        }
        /// <summary>
        /// 检查更新异步运行
        /// </summary>
        public void run()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10); //设置10s后触发
            var last = followingModels.Last<FollowingModel>().Uid;
            timer.Tick += async (t, s) =>
            {
                foreach (var model in followingModels)
                {
                    var history = new GetSpaceHistory(model.Uid);
                    if (model.Pre_Top == null) //第一次监听
                    {
                        var list = await history.getCardList();
                        MainWindow.OriginalDynamicsList.AddRange(list);
                        model.Pre_Top = list[0];

                        if (model.Uid.Equals(last)) //若第一次遍历结束
                        {
                            MainWindow.OriginalDynamicsList.Sort((a, b) => a.Desc.Dynamic_id.CompareTo(b.Desc.Dynamic_id));
                            if (mainwindow.Dynamic_isFirst) { mainwindow.ListBox_Dynamics.Items.Clear(); mainwindow.Dynamic_isFirst = false; }
                            foreach(var c in MainWindow.OriginalDynamicsList)
                            {
                                onFirstUpdated(c,mainwindow);
                            }
                            await MainWindow.log.Logger(LoggerType.Info, "动态载入完成");
                        }
                    }
                    else //再次监听
                    {
                        var list = await history.getCardList();
                        model.Now_Top = list[0];
                        System.Diagnostics.Debug.WriteLine(model.Uid + ":" + model.Pre_Top.Desc.Dynamic_id + " Updated?:"+ (model.Pre_Top.Desc.Dynamic_id < model.Now_Top.Desc.Dynamic_id));
                        if (model.Pre_Top.Desc.Dynamic_id < model.Now_Top.Desc.Dynamic_id)
                        {
                            onUpdated(model.Now_Top,mainwindow);
                            await MainWindow.log.Logger(LoggerType.Info, String.Format("{0} 更新", model.Now_Top.Desc.Dynamic_id));
                        }
                        model.Pre_Top = model.Now_Top;
                    }
                }
            };
            timer.Start();
        }
        //触发初次更新
        protected void onFirstUpdated(SpaceHistoryPage.DataObject.CardNodeObject card,MainWindow window)
        {
            DynamicFirstUpdatedEventListener(card, mainwindow);
        }


        //触发更新
        protected void onUpdated(SpaceHistoryPage.DataObject.CardNodeObject card, MainWindow window)
        {
            DynamicUpdatedEventListener(card, mainwindow);
        }
    }

    public class SubscribeEvent
    {
        public static async void autolike(SpaceHistoryPage.DataObject.CardNodeObject card,MainWindow window)
        {
            if (!ConfigLoader.Config.Autolike_mode) return;
            AutoLike like = new AutoLike(card.Desc.Dynamic_id);
            await like.exec();
        }
        public static void updateListBox(SpaceHistoryPage.DataObject.CardNodeObject card, MainWindow window)
        {
            if (!ConfigLoader.Config.Ballon_mode) return;
            var orig = JsonConvert.DeserializeObject<SpaceHistoryPage.DataObject.CardNodeObject.InfoObject>(card.Card);
            var ud = new UserDynamics();
            if (orig.Videos == 0)
            {
                ud.DynamicContent = orig.Item.Content == null ? orig.Item.Description : orig.Item.Content;
                ud.HeadURL = orig.User.Face == null ? orig.User.Head_url : orig.User.Face;
                ud.Title = orig.User.Uname == null ? orig.User.Name : orig.User.Uname;
                ud.Dynamic_URL = "https://t.bilibili.com/" + Convert.ToString(card.Desc.Dynamic_id);
            }
            else
            {
                ud.DynamicContent = "发布了视频：" + orig.Title;
                ud.HeadURL = orig.Owner.Face;
                ud.Title = orig.Owner.Name;
                ud.Dynamic_URL = orig.Short_link;
            }
            window.ListBox_Dynamics.Items.Insert(0, ud);
        }

        public static void noticeBoxShow(SpaceHistoryPage.DataObject.CardNodeObject card, MainWindow window)
        {
            var orig = JsonConvert.DeserializeObject<SpaceHistoryPage.DataObject.CardNodeObject.InfoObject>(card.Card);
            String title, content, headurl;
            if (orig.Videos == 0)
            {
                content = orig.Item.Content == null ? orig.Item.Description : orig.Item.Content;
                headurl = orig.User.Face == null ? orig.User.Head_url : orig.User.Face;
                title = orig.User.Uname == null ? orig.User.Name : orig.User.Uname;
            }
            else
            {
                content = "发布了视频：" + orig.Title;
                title = orig.Owner.Name;
                headurl = orig.Owner.Face;
            }
            var ballon = new BallonMessage(title,headurl,content);
            ballon.Show();
            if (!window.IsVisible)
            {
                window.NotifyMenu.IsBlink = true;
                window.NotifyMenu.BlinkInterval = new TimeSpan(0, 0, 0, 0, 100);
            }
        }
    }
}
