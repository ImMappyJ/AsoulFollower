using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AsoulFollower.utils
{

    public static class ConfigLoader
    {
        public const String LoginInfoURL = "https://api.bilibili.com/nav";
        public const String SpaceHistoryURL = "https://api.vc.bilibili.com/dynamic_svr/v1/dynamic_svr/space_history?";
        public const String SpaceInfoURL = "https://api.bilibili.com/x/space/wbi/acc/info?";
        public const String GetQRCodeURL = "https://passport.bilibili.com/x/passport-login/web/qrcode/generate";
        public const String LoginTokenReturnURL = "https://passport.bilibili.com/x/passport-login/web/qrcode/poll?";
        private static Config config;
        private const String config_file_name = "config.json";

        public static Config Config { get => config; set => config = value; }

        //加载
        public static async Task load()
        {
            if (File.Exists(config_file_name)) //存在文件
            {
                config = JsonConvert.DeserializeObject<Config>(await File.ReadAllTextAsync(config_file_name));
            }
            else //不存在文件
            {
                config = new Config();
                config.Notify_menu = true;
                config.Ballon_mode = true;
                config.Autolike_mode = true;
                config.Subscribe_list.Add(new Config.SubscribeModel { Name = "嘉然今天吃什么", Is_selected = true, Uid = "672328094" });
                config.Subscribe_list.Add(new Config.SubscribeModel { Name = "向晚大魔王", Is_selected = true, Uid = "672346917" });
                config.Subscribe_list.Add(new Config.SubscribeModel { Name = "乃琳Queen", Is_selected = true, Uid = "672342685" });
                config.Subscribe_list.Add(new Config.SubscribeModel { Name = "贝拉kira", Is_selected = true, Uid = "672353429" });
                config.Subscribe_list.Add(new Config.SubscribeModel { Name = "A-SOUL_Official", Is_selected = true, Uid = "703007996" });
                config.Subscribe_list.Add(new Config.SubscribeModel { Name = "ImMappyJ", Is_selected = true, Uid = "20654923" });
                FileStream stream = File.Create(config_file_name);
                stream.Close();
                await File.WriteAllTextAsync(config_file_name, JsonConvert.SerializeObject(config));
            }
        }
        //保存
        public static async Task save()
        {
            await File.WriteAllTextAsync(config_file_name, JsonConvert.SerializeObject(config));
        }
    }

    public class Config
    {
        private List<SubscribeModel> subscribe_list = new List<SubscribeModel>();
        private bool ballon_mode;
        private bool notify_menu;
        private bool autolike_mode;
        private String cookie = "";
        private String csrf = "";

        public bool Ballon_mode { get => ballon_mode; set => ballon_mode = value; }
        public bool Notify_menu { get => notify_menu; set => notify_menu = value; }
        public List<SubscribeModel> Subscribe_list { get => subscribe_list; set => subscribe_list = value; }
        public string Cookie { get => cookie; set => cookie = value; }
        public string Csrf { get => csrf; set => csrf = value; }
        public bool Autolike_mode { get => autolike_mode; set => autolike_mode = value; }

        public class SubscribeModel
        {
            private String name;
            private bool is_selected;
            private String uid;
            private int live_room;

            public string Name { get => name; set => name = value; }
            public string Uid { get => uid; set => uid = value; }
            public bool Is_selected { get => is_selected; set => is_selected = value; }
            public int Live_room { get => live_room; set => live_room = value; }
        }
    }
}
