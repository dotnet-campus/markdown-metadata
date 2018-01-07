using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using Mdmeta.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mdmeta.Test
{
    [TestClass]
    public class MdmetaFileTest
    {
        [TestMethod]
        public void GetTitle_File_CanGetTitle()
        {
            var fileInfo = new FileInfo(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName, "如何使用本模板搭建博客.md"));

            var mdmetaFile = new MdmetaFile(fileInfo.OpenText());
            var str = mdmetaFile.GetTitle();
            Assert.AreEqual(str, "如何使用本模板搭建博客");
        }

        [TestMethod]
        public void ReadTitle_String_int()
        {
            string str = "# 123";
            var mdmetaFile = new MdmetaFile(null);
            var n = mdmetaFile.ReadTitle(str);
            Assert.AreEqual(n, 2);
        }

        [TestMethod]
        public void ReadTitle_EmptyString_Int()
        {
            string str = " # 123";
            var mdmetaFile = new MdmetaFile(null);
            var n = mdmetaFile.ReadTitle(str);
            Assert.AreEqual(n, 3);
        }

        [TestMethod]
        public void ReadTitle_TwoTe_Int()
        {
            string str = " ### 123";
            var mdmetaFile = new MdmetaFile(null);
            var n = mdmetaFile.ReadTitle(str);
            Assert.AreEqual(n, 5);
        }

        [TestMethod]
        public void Read_Replace_String()
        {
            var fileInfo = new FileInfo(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName, "如何使用本模板搭建博客.md"));

            var mdmetaFile = new MdmetaFile(fileInfo.OpenText());

            var excerpt = new Excerpt(new List<string>()
            {
                "<!--more-->"
            }, "<!--more1-->");

            mdmetaFile.MdmetaXsawJnfzmrs.Add(new SeparatorMdmetaXsawJnfzmr(excerpt));
            mdmetaFile.MdmetaXsawJnfzmrs.Add(new HzvhPaurvmoz());

            var str = mdmetaFile.Read();

            Assert.AreEqual(str.IndexOf("<!--more-->"), -1);
            Assert.AreEqual(str.IndexOf("<!--more1-->") >= 0, true);

            Console.WriteLine(str);
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


            str = "林德熙 https://lindexi.github.io https://lindexi.github.io";
            cjmvimxpCjabsfp = new NghtsBdlbthhur(null, str);
            hzvhPaurvmoz.Read(cjmvimxpCjabsfp);
            Assert.AreEqual(cjmvimxpCjabsfp.Str, "林德熙 [https://lindexi.github.io](https://lindexi.github.io ) [https://lindexi.github.io](https://lindexi.github.io )");


            str = "林德熙 https://lindexi.github.io";
            cjmvimxpCjabsfp = new NghtsBdlbthhur(null, str);
            hzvhPaurvmoz.Read(cjmvimxpCjabsfp);
            Assert.AreEqual(cjmvimxpCjabsfp.Str, "林德熙 [https://lindexi.github.io](https://lindexi.github.io )");
        }

        [TestMethod]
        public void XwnibaijxMoyddnzkp()
        {
            var fileInfo = new FileInfo(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName, "如何使用本模板搭建博客.md"));
            var stream = new StreamReader(fileInfo.OpenRead());
            string str = "https://lindexi.github.io";
            var toejxjwXywn = new ToejxjwXywn();
            toejxjwXywn.Read(new NghtsBdlbthhur(stream, str));
            Console.WriteLine(toejxjwXywn.CreateTime + " " + toejxjwXywn.Time);
            Assert.AreEqual(toejxjwXywn.ReadCsfLvi, false);
        }

        [TestMethod]
        public void Filter()
        {
            var textFilter = new TextFilter
            {
                Violate = new List<string>
                {
                    "高智晟","谭作人","高智晟","丁子霖","唯色","焦国标","何清涟","耀邦","紫阳","方励之","直男","严家其","鲍彤","鮑彤","鲍朴","柴玲",
                },
                RemoveCharacte = 5
            };
            string str = "";

            var file = new FileInfo("E:\\download\\民调局异闻录.txt");
            using (var stream = file.OpenText())
            {
                str = stream.ReadToEnd();
            }
            str = textFilter.Filter(str);

            using (var stream=new StreamWriter(file.OpenWrite()))
            {
                stream.Write(str);
            }
        }
    }
}
