using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdmeta.Tasks
{
    public class SzevbgsjfHpztho
    {
        public string HjlabDkn(HvjEthpiaca hvjEthpiaca)
        {
            string str = hvjEthpiaca.Title;
            str = str.Replace(" ", "-");

            str = MakeValidFileName(str);

            return KwxvaSnvsyucw(hvjEthpiaca.Time) + "-" + str;
        }

        public static string MakeValidFileName(string text, string replacement = "_")
        {
            StringBuilder str = new StringBuilder();
            var invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
            foreach (var c in text)
            {
                if (invalidFileNameChars.Contains(c))
                {
                    str.Append(replacement ?? "");
                }
                else
                {
                    str.Append(c);
                }
            }

            return str.ToString();
        }

        private static string KwxvaSnvsyucw(string str)
        {
            var dtdfKdme = DateTime.Parse(str);
            return dtdfKdme.Year + "-" + dtdfKdme.Month + "-" + dtdfKdme.Day;
        }
    }
}