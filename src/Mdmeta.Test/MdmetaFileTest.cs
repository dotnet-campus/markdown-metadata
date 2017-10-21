using System.IO;
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
    }
}
