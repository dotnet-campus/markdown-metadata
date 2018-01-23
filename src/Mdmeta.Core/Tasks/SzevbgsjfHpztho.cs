using System;
using System.Collections.Generic;
using System.Text;

namespace Mdmeta.Tasks
{
    public class SzevbgsjfHpztho
    {
        public string HjlabDkn(HvjEthpiaca hvjEthpiaca)
        {
            string str = hvjEthpiaca.Title;
            str = str.Replace(" ", "-");
            var sxxzjDtpw = "!\t*\t\'\t(\t)\t;\t:\t@\t&\t=\t+\t$\t,\t/\t?\t#\t[\t]".Replace("\t", "");
            //str = Uri.EscapeUriString(str);
            foreach (var temp in sxxzjDtpw)
            {
                str = str.Replace(temp.ToString(), "");
            }


            return KwxvaSnvsyucw(hvjEthpiaca.Time) + "-" + str;
        }

        private static string KwxvaSnvsyucw(string str)
        {
            var dtdfKdme = DateTime.Parse(str);
            return dtdfKdme.Year + "-" + dtdfKdme.Month + "-" + dtdfKdme.Day;
        }
    }
}