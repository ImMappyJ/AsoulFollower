using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoulFollower.objs
{
    public class SpaceInfoPage
    {
        private DataObject data;

        public DataObject Data { get => data; set => data = value; }

        public class DataObject
        {
            private String name;
            private String sign;
            private String face;
            private LiveRoomObject live_room;

            public string Name { get => name; set => name = value; }
            public string Sign { get => sign; set => sign = value; }
            public string Face { get => face; set => face = value; }
            public LiveRoomObject Live_room { get => live_room; set => live_room = value; }

            public class LiveRoomObject
            {
                private int roomid;
                private String cover;

                public int Roomid { get => roomid; set => roomid = value; }
                public string Cover { get => cover; set => cover = value; }
            }
        }
    }
}
