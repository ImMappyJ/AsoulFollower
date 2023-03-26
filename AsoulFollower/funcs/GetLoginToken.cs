/*
 *  登录界面
 */
using AsoulFollower.objs;
using AsoulFollower.utils;
using AsoulFollower.xamls;
using HandyControl.Controls;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoulFollower.funcs
{
    public class GetLoginToken
    {
        private String qrkey;
        private bool remember;

        public bool Remember { get => remember; set => remember = value; }

        public async Task<String> getLoginURL()
        {
            var request = new HttpRequest(ConfigLoader.GetQRCodeURL);
            var content = await request.getContentAsync();
            var json = JsonConvert.DeserializeObject<GetLoginQRCodePage>(content);
            this.qrkey = json.Data.Qrcode_key;
            return json.Data.Url;
        }

        /*
         * 0：扫码登录成功
         * 86038：二维码已失效
         * 86090：二维码已扫码未确认
         * 86101：未扫码
         */
        public async Task<ScanResultPage> getScanStatus()
        {
            var generater = new ParamsGenerate();
            generater.addParam("qrcode_key",this.qrkey);
            var request = new HttpRequest(ConfigLoader.LoginTokenReturnURL, generater);
            var content = await request.getContentAsync();
            var token = JsonConvert.DeserializeObject<ScanResultPage>(content);
            return token;
        }
    }
}
