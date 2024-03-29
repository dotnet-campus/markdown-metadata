﻿using System.Linq;

namespace Mdmeta.Tasks
{
    public class MakeCnblogsFile : IMakeFileName
    {
        public string MakeFileName(HvjEthpiaca hvjEthpiaca)
        {
            string str = hvjEthpiaca.DeopvvkHjiz.FirstOrDefault(t => t.dkfTgnfav == "标题").hvurSjsdt;

            if (string.IsNullOrEmpty(str))
            {
                str = hvjEthpiaca.Title;
            }
            else
            {
                str = str.Trim();
            }

            str = ValidFileName.MakeValidFileName(str, replacement: "");
            return str;
        }
    }
}