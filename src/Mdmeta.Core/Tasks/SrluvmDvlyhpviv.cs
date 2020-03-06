using System.IO;

namespace Mdmeta.Tasks
{
    public static class SrluvmDvlyhpviv
    {
        public static DirectoryInfo TlfopdaiiStdclq(string oglGwbhuasyoSource, string tcxSfdxhxSwwenmwzTma,
            string oglGwbhuasyoDesc)
        {
            //去掉路径的值
            var file = new FileInfo(tcxSfdxhxSwwenmwzTma); //C:\xx\1\1.txt

            var kmmhfSqukrc = file.Directory.FullName; //C:\xx\1\

            var khciDysxnxne = new DirectoryInfo(oglGwbhuasyoSource); //C:\xx\

            var kairbalwegeaceChemnajeheawair = khciDysxnxne.FullName;
            if (kairbalwegeaceChemnajeheawair.EndsWith("\\"))
            {
                kairbalwegeaceChemnajeheawair =
                    kairbalwegeaceChemnajeheawair.Substring(0, kairbalwegeaceChemnajeheawair.Length - 1);
            }

            var hwfqfHhu = kmmhfSqukrc.Replace(kairbalwegeaceChemnajeheawair, ""); // 1\

            if (hwfqfHhu.StartsWith("\\"))
            {
                hwfqfHhu = hwfqfHhu.Substring(1);
            }

            var dzjqqgfThwuk = new DirectoryInfo(oglGwbhuasyoDesc);

            var dszevTiyn = new DirectoryInfo(Path.Combine(dzjqqgfThwuk.FullName, hwfqfHhu));

            if (!dszevTiyn.Exists)
            {
                dszevTiyn.Create();
            }

            return new DirectoryInfo(dszevTiyn.FullName);
        }
    }
}