using AsoulFollower.objs;
using AsoulFollower.utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoulFollower.funcs
{
    /*
     * dynamic_id: 776250523608154130
     * up: 1
     * csrf: 
     * POST:https://api.vc.bilibili.com/dynamic_like/v1/dynamic_like/thumb
     * 
     */
    public class AutoLike
    {
        private long dynamic_id;
        /// <summary>
        /// 构造自动点赞
        /// </summary>
        /// <param name="dynamic_id">点赞动态ID</param>
        public AutoLike(long dynamic_id)
        {
            this.dynamic_id = dynamic_id;
        }

        public async Task exec()
        {
            var generater = new ParamsGenerate();
            generater.addParam("dynamic_id", Convert.ToString(this.dynamic_id));
            generater.addParam("up", "1");
            generater.addParam("csrf", ConfigLoader.Config.Csrf);
            var request = new HttpRequest("https://api.vc.bilibili.com/dynamic_like/v1/dynamic_like/thumb",generater);
            var c = JsonConvert.DeserializeObject<ThumbPage>(await request.postResultAsync());
            int code = c.Code;
            string msg = c.Message;
            await MainWindow.log.Logger(LoggerType.Info, String.Format("自动点赞{0}-code:{1} msg:{2}",this.dynamic_id,code,msg));
        }
    }
}
