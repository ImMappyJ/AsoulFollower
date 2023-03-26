using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoulFollower.objs
{
    public class LoginInfoPage
    {
        private int code; //0为登录 -101为未登录
        private DataObject data;

        public DataObject Data { get => data; set => data = value; }
        public int Code { get => code; set => code = value; }

        public class DataObject
        {
            private String face;
            private String uname;
            private float money;

            public string Face { get => face; set => face = value; }
            public string Uname { get => uname; set => uname = value; }
            public float Money { get => money; set => money = value; }
        }
    }
}
