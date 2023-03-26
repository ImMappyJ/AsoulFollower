using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoulFollower.objs
{
    public class GetLoginQRCodePage
    {
        private DataObject data;

        public DataObject Data { get => data; set => data = value; }

        public class DataObject
        {
            private String url;
            private String qrcode_key;

            public string Url { get => url; set => url = value; }
            public string Qrcode_key { get => qrcode_key; set => qrcode_key = value; }
        }
    }
}
