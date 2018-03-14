using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using Mdmeta.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mdmeta.Test
{
    [TestClass]
    public class MdmetaFileTest
    {
        //[TestMethod]
        //public void GetTitle_File_CanGetTitle()
        //{
        //    var fileInfo = new FileInfo(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName, "���ʹ�ñ�ģ������.md"));

        //    var mdmetaFile = new MdmetaFile(fileInfo.OpenText());
        //    var str = mdmetaFile.GetTitle();
        //    Assert.AreEqual(str, "���ʹ�ñ�ģ������");
        //}

        //[TestMethod]
        //public void ReadTitle_String_int()
        //{
        //    string str = "# 123";
        //    var mdmetaFile = new MdmetaFile(null);
        //    var n = mdmetaFile.ReadTitle(str);
        //    Assert.AreEqual(n, 2);
        //}

        //[TestMethod]
        //public void ReadTitle_EmptyString_Int()
        //{
        //    string str = " # 123";
        //    var mdmetaFile = new MdmetaFile(null);
        //    var n = mdmetaFile.ReadTitle(str);
        //    Assert.AreEqual(n, 3);
        //}

        //[TestMethod]
        //public void ReadTitle_TwoTe_Int()
        //{
        //    string str = " ### 123";
        //    var mdmetaFile = new MdmetaFile(null);
        //    var n = mdmetaFile.ReadTitle(str);
        //    Assert.AreEqual(n, 5);
        //}

        [TestMethod]
        public void Read_Replace_String()
        {
            var fileInfo =
                new FileInfo(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName,
                    "���ʹ�ñ�ģ������.md"));

            var mdmetaFile = new MdmetaFile(fileInfo.OpenText());

            var excerpt = new Excerpt(new List<string>()
            {
                "<!--more-->"
            }, "<!--more1-->");

            mdmetaFile.MdmetaXsawJnfzmrs.Add(new SeparatorMdmetaXsawJnfzmr(excerpt));
            mdmetaFile.MdmetaXsawJnfzmrs.Add(new HzvhPaurvmoz());

            var str = mdmetaFile.Read().Text;

            Assert.AreEqual(str.IndexOf("<!--more-->"), -1);
            //Assert.AreEqual(str.IndexOf("<!--more1-->") >= 0, true);

            Console.WriteLine(str);
        }

        [TestMethod]
        public void NvwLqlgh()
        {
            var excerpt =
                "���ĸ��ߴ�����ʹ��������������Լ��Ĳ��͡������������ [���� - walterlv](https://walterlv.github.io/ )�������[hcz-jekyll-blog](https://codeasashu.github.io/hcz-jekyll-blog/) �޸ĳ����ģ����������ֻ��˺�pc�ˡ�";
            var fileInfo =
                new FileInfo(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName,
                    "���ʹ�ñ�ģ������.md"));
            var separatorMdmetaXsawJnfzmr = new SeparatorMdmetaXsawJnfzmr(Excerpt.JyggcudKgylq);


            var mdmetaFile = new MdmetaFile(fileInfo.OpenText());

            mdmetaFile.MdmetaXsawJnfzmrs = new List<MdmetaXsawJnfzmr>()
            {
                separatorMdmetaXsawJnfzmr,
                new QzgTnnknwsMdmetaXsawJnfzmr()
            };

            var hvjEthpiaca = mdmetaFile.Read();
            Assert.AreEqual(hvjEthpiaca.Excerpt.Trim(), excerpt);
        }


        [TestMethod]
        public void ReplaceLenghtGzwxtpuOgppoe()
        {
            string str = "123456";
            Assert.AreEqual(HzvhPaurvmoz.Replace(str, 2, 3, "111"), "121116");
            Assert.AreEqual(HzvhPaurvmoz.Replace(str, 2, 4, "111"), "12111");
            Assert.AreEqual(HzvhPaurvmoz.Replace(str, 2, 3, "11111"), "12111116");
        }

        [TestMethod]
        public void FfkPmkzaco()
        {
            var hzvhPaurvmoz = new HzvhPaurvmoz();
            string str = "https://lindexi.github.io";
            var cjmvimxpCjabsfp = new NghtsBdlbthhur(null, str);
            //hzvhPaurvmoz.Read(cjmvimxpCjabsfp);
            //Assert.AreEqual(cjmvimxpCjabsfp.Str, "[https://lindexi.github.io](https://lindexi.github.io )");

            str = "[https://lindexi.github.io](https://lindexi.github.io )";
            cjmvimxpCjabsfp = new NghtsBdlbthhur(null, str);
            hzvhPaurvmoz.Read(cjmvimxpCjabsfp);
            Assert.AreEqual(cjmvimxpCjabsfp.Str, "[https://lindexi.github.io](https://lindexi.github.io )");


            str = "�ֵ��� https://lindexi.github.io https://lindexi.github.io";
            cjmvimxpCjabsfp = new NghtsBdlbthhur(null, str);
            hzvhPaurvmoz.Read(cjmvimxpCjabsfp);
            Assert.AreEqual(cjmvimxpCjabsfp.Str,
                "�ֵ��� [https://lindexi.github.io](https://lindexi.github.io ) [https://lindexi.github.io](https://lindexi.github.io )");


            str = "�ֵ��� https://lindexi.github.io";
            cjmvimxpCjabsfp = new NghtsBdlbthhur(null, str);
            hzvhPaurvmoz.Read(cjmvimxpCjabsfp);
            Assert.AreEqual(cjmvimxpCjabsfp.Str, "�ֵ��� [https://lindexi.github.io](https://lindexi.github.io )");
        }

        [TestMethod]
        public void XwnibaijxMoyddnzkp()
        {
            var fileInfo =
                new FileInfo(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName,
                    "���ʹ�ñ�ģ������.md"));
            var stream = new StreamReader(fileInfo.OpenRead());
            string str = "https://lindexi.github.io";
            var toejxjwXywn = new ToejxjwXywn();
            var hvjEthpiaca = new HvjEthpiaca();
            toejxjwXywn.HvjEthpiaca = hvjEthpiaca;
            toejxjwXywn.Read(new NghtsBdlbthhur(stream, str));
            Console.WriteLine(toejxjwXywn.HvjEthpiaca.CreateTime + " " + toejxjwXywn.HvjEthpiaca.Time);
            Assert.AreEqual(toejxjwXywn.ReadCsfLvi, false);
        }

        [TestMethod]
        public void HzswllcdcSalituev()
        {
            var dmnwTxcdmc = new DhhiopTbxevh();

            var tyfdolhsKflkermum = new HvjEthpiaca()
            {
                DeopvvkHjiz = new List<(string dkfTgnfav, string hvurSjsdt)>()
                {
                    ("��ǩ", "��ǩ")
                }
            };
            var tyyKflgjlmbr = new SszHspndy(tyfdolhsKflkermum);
            var skdvqpShptf = tyyKflgjlmbr.DvyovKysizejh(dmnwTxcdmc.SacdpDkqz);
            Assert.AreEqual(skdvqpShptf, dmnwTxcdmc.SacdpDkqz.Replace("{{ ��ǩ }}", "��ǩ"));
        }

        [TestMethod()]
        public void UhmmlTzj()
        {
            var oglGwbhuasyo = new OglGwbhuasyo("lindexi", "E:\\temp\\lindexi\\_posts", "E:\\temp\\uwp_introduction");
            var uhmmlTzj = new UhmmlTzj(oglGwbhuasyo);

            uhmmlTzj.Read();
        }

        [TestMethod]
        public void LoquXiz()
        {
            string str =
                "<a rel=\"license\" href=\"http://creativecommons.org/licenses/by-nc-sa/4.0/\"><img alt=\"֪ʶ�������Э��\" style=\"border-width:0\" src=\"https://licensebuttons.net/l/by-nc-sa/4.0/88x31.png\" /></a><br />����Ʒ����<a rel=\"license\" href=\"http://creativecommons.org/licenses/by-nc-sa/4.0/\">֪ʶ��������-����ҵ��ʹ��-��ͬ��ʽ���� 4.0 �������Э��</a>������ɡ���ӭת�ء�ʹ�á����·���������ر�����������[�ֵ���](http://blog.csdn.net/lindexi_gd)(��������:http://blog.csdn.net/lindexi_gd )������������ҵĿ�ģ����ڱ����޸ĺ����Ʒ�������ͬ����ɷ����������κ����ʣ�������[��ϵ](mailto:lindexi_gd@163.com)��";

            var qahvmudf = new LicenseQahvmudf(null);
            var cjmvimxpCja = new NghtsBdlbthhur(null, str);
            qahvmudf.Read(cjmvimxpCja);

            Assert.AreEqual(qahvmudf.Licensecwau, str);
        }

        [TestMethod]
        public void YteisbzvoCwrenoc()
        {
            string str =
                "<a rel=\"license\" href=\"http://creativecommons.org/licenses/by-nc-sa/4.0/\"><img alt=\"֪ʶ�������Э��\" style=\"border-width:0\" src=\"https://licensebuttons.net/l/by-nc-sa/4.0/88x31.png\" /></a><br />����Ʒ����<a rel=\"license\" href=\"http://creativecommons.org/licenses/by-nc-sa/4.0/\">֪ʶ��������-����ҵ��ʹ��-��ͬ��ʽ���� 4.0 �������Э��</a>������ɡ���ӭת�ء�ʹ�á����·���������ر�����������[�ֵ���](http://blog.csdn.net/lindexi_gd)(��������:http://blog.csdn.net/lindexi_gd )������������ҵĿ�ģ����ڱ����޸ĺ����Ʒ�������ͬ����ɷ����������κ����ʣ�������[��ϵ](mailto:lindexi_gd@163.com)��";

            var fileInfo =
                new FileInfo(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName,
                    "���ʹ�ñ�ģ������.md"));
            var licenseQahvmudf = new LicenseQahvmudf();

            var mdmetaFile = new MdmetaFile(fileInfo.OpenText());

            mdmetaFile.MdmetaXsawJnfzmrs = new List<MdmetaXsawJnfzmr>()
            {
                licenseQahvmudf,
                new QzgTnnknwsMdmetaXsawJnfzmr()
            };

            var hvjEthpiaca = mdmetaFile.Read();

            Assert.AreEqual(hvjEthpiaca.Text.Contains(str), false);
        }

        [TestMethod]
        public void HupoqTpydwrt()
        {
            var hvjEthpiaca = new HvjEthpiaca()
            {
                Time = "2017-10-21 9:29:3 +0800",
                Title = "C# ����",
            };

            var szevbgsjfHpztho = new SzevbgsjfHpztho();
            Assert.AreEqual(szevbgsjfHpztho.HjlabDkn(hvjEthpiaca), "2017-10-21-C-����");
        }

        [TestMethod]
        public void DwwHdwtgcqjhDabfkmDdbxfm()
        {
            var ksnrscjodHycdbk = new DwwHdwtgcqjh();
            ksnrscjodHycdbk.HvjEthpiaca = new HvjEthpiaca();

            string str = "<!-- ��ǩ��VisualStudio������ -->";
            ksnrscjodHycdbk.Read(new NghtsBdlbthhur(null, str));
            List<(string dkfTgnfav, string hvurSjsdt)> kdzqswxzTyumwiara = ksnrscjodHycdbk.HvjEthpiaca.DeopvvkHjiz;
            Assert.AreEqual(kdzqswxzTyumwiara.Count, 1);

            Assert.AreEqual(kdzqswxzTyumwiara[0].dkfTgnfav, "��ǩ");
            Assert.AreEqual(kdzqswxzTyumwiara[0].hvurSjsdt, "VisualStudio,����");
        }

        [TestMethod]
        public void SuxexzrDmahq()
        {
            var ksnrscjodHycdbk = new DwwHdwtgcqjh();
            ksnrscjodHycdbk.HvjEthpiaca = new HvjEthpiaca();

            string str = "<!-- ��ǩ��VisualStudio -->";
            ksnrscjodHycdbk.Read(new NghtsBdlbthhur(null, str));
            str = "<!-- ��ǩ������ -->";
            ksnrscjodHycdbk.Read(new NghtsBdlbthhur(null, str));


            List<(string dkfTgnfav, string hvurSjsdt)> kdzqswxzTyumwiara = ksnrscjodHycdbk.HvjEthpiaca.DeopvvkHjiz;


            Assert.AreEqual(kdzqswxzTyumwiara.Count, 1);

            Assert.AreEqual(kdzqswxzTyumwiara[0].dkfTgnfav, "��ǩ");
            Assert.AreEqual(kdzqswxzTyumwiara[0].hvurSjsdt, "VisualStudio,����");
        }

        [TestMethod]
        public void KeqntlwkSimdhztDaujfTlkl()
        {
            var keqntlwkSimdhzt = new KeqntlwkSimdhzt();
            var tlglTyvoa = keqntlwkSimdhzt.DpxgazTamyir[0];
            string dkfTgnfav = "��ǩ";
            List<string> hvurSjsdt = new List<string>()
            {
                "visualStudio",
                "visualstudio",
                "win10",
                "wpf",
                "uwp",
                "Uwp",
                "Dotnet",
                "Win2d"
            };

            tlglTyvoa.DpxgazTamyir(dkfTgnfav, hvurSjsdt);

            var dkastHukgn = new List<string>()
            {
                "VisualStudio",
                "VisualStudio",
                "Win10",
                "WPF",
                "UWP",
                "UWP",
                "dotnet",
                "win2d",
            };

            for (var i = 0; i < dkastHukgn.Count; i++)
            {
                Assert.AreEqual(dkastHukgn[i], hvurSjsdt[i]);
            }
        }

        [TestMethod]
        public void DmutmraDtgzwihr()
        {
            var hvjEthpiaca = new HvjEthpiaca()
            {
                Title = "win10 uwp ��ȡ�豸"
            };
            var mdmetaXsawJnfzmr = new List<MdmetaXsawJnfzmr>();
            var dasmxxfgTqqxo = DasmxxfgTqqxo.HfuvuwTwve;
            dasmxxfgTqqxo.DmutmraDtgzwihr(hvjEthpiaca, mdmetaXsawJnfzmr);
        }

        [TestMethod]
        public void KvfibTfbyd()
        {
            var hanazbnsoKoakli = "E:\\temp\\xx\\1\\1.txt";

            var hxwxmDvkwv = "E:\\temp\\xx1";

            var tcgKbhymfr = "E:\\temp\\xx";

            var hubacKnazbhndc = SrluvmDvlyhpviv.TlfopdaiiStdclq(tcgKbhymfr, hanazbnsoKoakli, hxwxmDvkwv);

            Assert.AreEqual(hubacKnazbhndc.FullName, "E:\\temp\\xx1\\1");
        }

        [TestMethod]
        public void DdfTtjunwdt()
        {
            var dsfuDewuwwhc = new DsfuDewuwwhc();

            dsfuDewuwwhc.HvjEthpiaca = new HvjEthpiaca();


            var nghtsBdlbthhur = new NghtsBdlbthhur(null, "<!--more-->");

            dsfuDewuwwhc.Read(nghtsBdlbthhur);

            nghtsBdlbthhur = new NghtsBdlbthhur(null, "<!-- �ݸ� -->");
            dsfuDewuwwhc.Read(nghtsBdlbthhur);


            Assert.AreEqual(dsfuDewuwwhc.HvjEthpiaca.HqshpnjiKlclzh.Count, 2);
            Assert.AreEqual(dsfuDewuwwhc.HvjEthpiaca.HqshpnjiKlclzh[0], "more");

            Console.WriteLine(dsfuDewuwwhc.HvjEthpiaca.HqshpnjiKlclzh[1]);
        }
    }
}