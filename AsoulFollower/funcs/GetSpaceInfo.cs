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
    public class GetSpaceInfo
    {
        private String uid;

        public GetSpaceInfo(String uid) { this.uid = uid; }

        public async Task<SpaceInfoPage.DataObject> getInfo()
        {
            ParamsGenerate generate = new ParamsGenerate();
            generate.addParam("mid", uid);
            HttpRequest request = new HttpRequest(ConfigLoader.SpaceInfoURL, generate);
            String content = await request.getContentAsync();
            SpaceInfoPage spaceInfoPage = JsonConvert.DeserializeObject<SpaceInfoPage>(content);
            return spaceInfoPage.Data;
        }
    }
}
