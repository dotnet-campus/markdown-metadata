using System;
using System.IO;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// 获得文件的时间，修改时间
    /// </summary>
    public class ToejxjwXywn : MdmetaXsawJnfzmr
    {
        public ToejxjwXywn()
        {
            Priority = 20;
        }

        public override void Read(NghtsBdlbthhur nghtsBdlbthhur)
        {
            FileStream stream = nghtsBdlbthhur.Stream.BaseStream as FileStream;
            if (stream != null)
            {
                var file = new FileInfo(stream.Name);
                HvjEthpiaca.CreateTime = ToString(file.CreationTime);
                HvjEthpiaca.Time = ToString(file.LastWriteTime);
            }
            ReadCsfLvi = false;
        }

        private string ToString(DateTime creationTime)
        {
            //2017-10-21 09:44:02 +0800
            return
                $"{creationTime.Year}-{creationTime.Month}-{creationTime.Day} {creationTime.Hour}:{creationTime.Minute}:{creationTime.Second} +0800";
        }
    }
}