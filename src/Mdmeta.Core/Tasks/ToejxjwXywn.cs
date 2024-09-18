using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// 获得文件的时间，修改时间
    /// </summary>
    public class ToejxjwXywn : MdmetaXsawJnfzmr
    {
        public ToejxjwXywn()
        {
            Priority = 99; // 低于 DwwHdwtgcqjh 优先级
        }

        public override void Read(NghtsBdlbthhur nghtsBdlbthhur)
        {
            if (string.IsNullOrEmpty(HvjEthpiaca.Time))
            {
                FileStream stream = nghtsBdlbthhur.Stream.BaseStream as FileStream;
                if (stream != null)
                {
                    var file = new FileInfo(stream.Name);
                    HvjEthpiaca.CreateTime = ToString(file.CreationTime);
                    HvjEthpiaca.Time = ToString(file.LastWriteTime);
                }
            }

            var (_, createTime) = HvjEthpiaca.DeopvvkHjiz.FirstOrDefault(t => t.dkfTgnfav == "CreateTime");
            if (!string.IsNullOrEmpty(createTime))
            {
                HvjEthpiaca.CreateTime = createTime;
                ReadCsfLvi = false;
            }
        }

        public override void HgvaHhloe()
        {
            foreach (var layjabifayNechaifemjai in HvjEthpiaca.HqshpnjiKlclzh)
            {
                var match = Regex.Match(layjabifayNechaifemjai, @"置顶(\d*)");
                if (match.Success)
                {
                    if (!int.TryParse(match.Groups[1].Value, out var n))
                    {
                        n = 0;
                    }

                    HvjEthpiaca.Time = ToString(DateTime.Now.AddHours(-n));
                }
            }
        }

        private string ToString(DateTime creationTime)
        {
            //2017-10-21 09:44:02 +0800
            return
                $"{creationTime.Year}-{creationTime.Month}-{creationTime.Day} {creationTime.Hour}:{creationTime.Minute}:{creationTime.Second} +0800";
        }
    }
}