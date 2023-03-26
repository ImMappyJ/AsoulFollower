using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AsoulFollower.objs
{
    public class SpaceHistoryPage
    {
        private int code;
        private DataObject data;

        public int Code { get => code; set => code = value; }
        public DataObject Data { get => data; set => data = value; }
        public class DataObject
        {
            private List<CardNodeObject> cards;

            public List<CardNodeObject> Cards { get => cards; set => cards = value; }

            public class CardNodeObject
            {
                private String card;
                private DescObject desc;
                public string Card { get => card; set => card = value; }
                public DescObject Desc { get => desc; set => desc = value; }

                public class DescObject
                {
                    private long dynamic_id;

                    public long Dynamic_id { get => dynamic_id; set => dynamic_id = value; }
                }
                public class InfoObject //card中的信息序列化
                {
                    private UserObject user;
                    private ItemObject item;

                    /* 
                     * 普通动态
                     * 发布视频
                     */
                    private OwnerObject owner;
                    private String short_link;
                    private int videos;
                    private String title;

                    public UserObject User { get => user; set => user = value; }
                    public ItemObject Item { get => item; set => item = value; }
                    public int Videos { get => videos; set => videos = value; }
                    public string Title { get => title; set => title = value; }
                    public OwnerObject Owner { get => owner; set => owner = value; }
                    public string Short_link { get => short_link; set => short_link = value; }

                    public class OwnerObject
                    {
                        private String face;
                        private String name;

                        public string Face { get => face; set => face = value; }
                        public string Name { get => name; set => name = value; }
                    }
                    public class UserObject
                    {
                        private String uname;
                        private String face;
                        private String name;
                        private String head_url;

                        public string Uname { get => uname; set => uname = value; }
                        public string Face { get => face; set => face = value; }
                        public string Name { get => name; set => name = value; }
                        public string Head_url { get => head_url; set => head_url = value; }
                    }
                    public class ItemObject
                    {
                        private String content;
                        private String description;

                        public string Content { get => content; set => content = value; }
                        public string Description { get => description; set => description = value; }
                    }
                }
            }
        }
    }
}
