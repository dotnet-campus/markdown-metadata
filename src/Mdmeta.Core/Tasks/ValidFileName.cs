using System.Linq;
using System.Text;

namespace Mdmeta.Tasks
{
    public static class ValidFileName
    {
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
    }
}