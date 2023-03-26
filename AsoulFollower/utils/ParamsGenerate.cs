using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoulFollower.utils
{
    public class ParamsGenerate
    {
        private List<String> keys = new List<String>();
        private List<String> values = new List<String>();

        public void addParam(String key, String value)
        {
            this.keys.Add(key);
            this.values.Add(value);
        }

        public String generate()
        {
            String result = "";
            for (int cnt = 0; cnt < keys.Count; cnt++)
            {
                result += keys[cnt];
                result += "=";
                result += values[cnt];
                if (cnt != keys.Count - 1)
                {
                    result += "&";
                }
            }
            return result;
        }

        /// <returns>异步返回<code>KeyValuePair</code>的字段组</returns>
        public IEnumerable<KeyValuePair<string,string>> GetPairAsync()
        {
            for(int cnt = 0; cnt < keys.Count; cnt++)
            {
                yield return new KeyValuePair<string, string>(keys[cnt], values[cnt]);
            }
        }
    }
}
