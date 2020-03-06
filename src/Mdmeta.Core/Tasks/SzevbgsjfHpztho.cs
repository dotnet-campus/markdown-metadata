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

            return KwxvaSnvsyucw(hvjEthpiaca.Time) + "-" + str;
        }

        private static string KwxvaSnvsyucw(string str)
        {
            var dtdfKdme = DateTime.Parse(str);
            return dtdfKdme.Year + "-" + dtdfKdme.Month + "-" + dtdfKdme.Day;
        }
    }
}