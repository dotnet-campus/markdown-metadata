using System;
using System.Collections.Generic;

namespace Mdmeta.Tasks
{
    public class SzevbgsjfHpztho : IMakeFileName
    {
        public string MakeFileName(HvjEthpiaca hvjEthpiaca)
        {
            string str = hvjEthpiaca.Title;
            str = str.Replace(" ", "-");

            str = ValidFileName.MakeValidFileName(str);

            return KwxvaSnvsyucw(hvjEthpiaca.GetCreateTime()) + "-" + str;
        }

        private static string KwxvaSnvsyucw(DateTime createTime)
        {
            return createTime.Year + "-" + createTime.Month.ToString("00") + "-" + createTime.Day.ToString("00");
        }
    }
}