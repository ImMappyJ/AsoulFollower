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
    public class GetSpaceHistory
    {
        private String uid;
        /// <summary>
        /// 初始化获取空间历史对象
        /// </summary>
        /// <param name="uid">追踪UID</param>
        public GetSpaceHistory(String uid) { this.uid = uid; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>返回CardNodeObject列表</returns>
        public async Task<List<SpaceHistoryPage.DataObject.CardNodeObject>> getCardList()
        {
            ParamsGenerate generate = new ParamsGenerate();
            generate.addParam("host_uid", uid);
            generate.addParam("offset_dynamic_id", "0");
            generate.addParam("need_top", "0");
            generate.addParam("platform", "web");
            HttpRequest request = new HttpRequest(ConfigLoader.SpaceHistoryURL, generate);
            String contents = await request.getContentAsync();
            SpaceHistoryPage page = JsonConvert.DeserializeObject<SpaceHistoryPage>(contents);
            if(page != null)
            {
                return page.Data.Cards;
            }
            return null;
        }
    }
}
