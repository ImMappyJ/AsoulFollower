using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoulFollower.objs
{
    public class ScanResultPage
    {
        private DataObject data;

        public DataObject Data { get => data; set => data = value; }

        public class DataObject
        {
            private int code;
            private String message;

            public int Code { get => code; set => code = value; }
            public string Message { get => message; set => message = value; }
        }
    }
}
