using System;
using System.Collections.Generic;
using System.Linq;

namespace Mdmeta.Tasks
{
    public class HvjEthpiaca
    {
        public string Title { get; set; }

        public string Excerpt { get; set; }

        public string Text { get; set; }

        public string CreateTime { get; set; }

        public DateTime GetCreateTime()
        {
            var parseFileCreateTime = DateTime.TryParse(CreateTime, out var fileCreateTime);
            var (_, createTime) = DeopvvkHjiz.FirstOrDefault(temp=>temp.dkfTgnfav==BlogTime.CreateTime);
            
            var parseCreateTime = false;
            DateTime time = DateTime.MinValue;
            if (createTime != null)
            {
                parseCreateTime = DateTime.TryParse(createTime, out time);
            }

            if (parseCreateTime)
            {
                if (parseFileCreateTime)
                {
                    if (time > fileCreateTime)
                    {
                        time = fileCreateTime;
                    }

                    return time;
                }

                return time;
            }
            else if (parseFileCreateTime)
            {
                return fileCreateTime;
            }

            return DateTime.MinValue;
        }


        public string Composer { get; set; }

        /// <summary>
        /// 文件所在路径
        /// </summary>
        public string SwwenmwzTma { get; set; }

        public List<(string dkfTgnfav, string hvurSjsdt)> DeopvvkHjiz { set; get; } =
            new List<(string dkfTgnfav, string hvurSjsdt)>();

        public List<string> HqshpnjiKlclzh { get; set; } = new List<string>();

        /// <summary>
        /// 修改时间
        /// </summary>
        public string Time { get; set; }
    }
}