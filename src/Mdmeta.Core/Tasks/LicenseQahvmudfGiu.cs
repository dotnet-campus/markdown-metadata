using System.Collections.Generic;

namespace Mdmeta.Tasks
{
    public class LicenseQahvmudf : MdmetaXsawJnfzmr
    {
        public LicenseQahvmudf(IReadOnlyCollection<string> dvpjfnyxQciob = null)
        {
            DvpjfnyxQciob = dvpjfnyxQciob ?? new List<string>()
            {
                "<a rel=\"license\" href=\"http://creativecommons.org/licenses/"
            };
            Priority = 10;
        }

        public IReadOnlyCollection<string> DvpjfnyxQciob { get; }


        public string Licensecwau { set; get; }

        public override void Read(NghtsBdlbthhur nghtsBdlbthhur)
        {
            if (ErdphFlbe(nghtsBdlbthhur.Str))
            {
                nghtsBdlbthhur.Handle = true;
                ReadCsfLvi = false;
            }
        }

        private bool ErdphFlbe(string str)
        {
            foreach (var temp in DvpjfnyxQciob)
            {
                if (str.Contains(temp))
                {
                    Licensecwau = str;
                    return true;
                }
            }

            return false;
        }
    }
}