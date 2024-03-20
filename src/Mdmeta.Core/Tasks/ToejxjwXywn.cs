using System;
using System.IO;
using System.Linq;

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

        private string ToString(DateTime creationTime)
        {
            //2017-10-21 09:44:02 +0800
            return
                $"{creationTime.Year}-{creationTime.Month}-{creationTime.Day} {creationTime.Hour}:{creationTime.Minute}:{creationTime.Second} +0800";
        }
    }
}