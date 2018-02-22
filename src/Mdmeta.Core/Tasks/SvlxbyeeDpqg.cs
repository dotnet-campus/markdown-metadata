using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mdmeta.Tasks
{
    class SvlxbyeeDpqg
    {
        public string Push(string folder)
        {
            var git = new GitControl(folder);
            StringBuilder str = new StringBuilder();
            str.Append(git.Add() + "\r\n");
            str.Append(git.Commit() + "\r\n");
            str.Append(git.Push() + "\r\n");
            return str.ToString();
        }
    }

    public class GitControl
    {
        public GitControl(string fileDirectory)
        {
            FileDirectory = fileDirectory;
        }

        /// <summary>
        ///     git的文件夹
        /// </summary>
        public string FileDirectory { set; get; }

        public string Branch { set; get; }

        public string Origin { set; get; }

        public string Add(string file = ".")
        {
            string str = "add " + file;
            return Control(str);
        }

        private string ConvertDate(DateTime time)
        {
            //1.  一月     January      （Jan）2.  二月      February   （Feb）
            //3.  三月      March        （Mar） 
            //4.  四月      April           （Apr）
            //5.  五月      May           （May）
            //6.  六月      June           （Jun）
            //7.  七月      July             （Jul）
            //8.  八月      August        （Aug）
            //9.  九月      September  （Sep）
            //10.  十月     October      （Oct） 
            //11.  十一月   November （Nov）12.  十二月   December （Dec）
            List<string> temp = new List<string>()
            {
                "Jan",
                "Feb",
                "Mar",
                "Apr",
                "May",
                "Jun",
                "Jul",
                "Aug",
                "Sep",
                "Oct",
                "Nov",
                "Dec"
            };

            //StringBuilder str = new StringBuilder();
            //            git commit --date = "月 日 时间 年 +0800" - am "提交"

            //git commit --date = "May 7 9:05:20 2016 +0800" - am "提交"
            return
                $"--date=\"{temp[time.Month - 1]} {time.Day} {time.Hour}:{time.Minute}:{time.Second} {time.Year} +0800\" ";
        }

        public string Commit(string str = null, DateTime time = default(DateTime))
        {
            string commit = " commit";
            if (time != (default(DateTime)))
            {
                commit += " " + ConvertDate(time);
            }

            if (string.IsNullOrEmpty(str))
            {
                if (time == default(DateTime))
                {
                    time = DateTime.Now;
                }

                str = time.Year + "年" + time.Month + "月" +
                      time.Day + "日 " +
                      time.Hour + ":" +
                      time.Minute + ":" + time.Second;
            }

            commit += " -m " + "\"" + str + "\"";
            //commit = FileStr() + commit;
            return Control(commit);
        }

        public string Push()
        {
            //git push origin master
            if (string.IsNullOrEmpty(Branch))
            {
                Branch = "master";
            }

            if (string.IsNullOrEmpty(Origin))
            {
                Origin = "origin";
                string str = $"push {Origin} {Branch}";
                return Control(str);
            }
            else
            {
                string str = $"push {Origin} {Branch}";
                str = Control(str);
                if (Origin != "origin")
                {
                    Origin = "origin";
                    str += Control($"push {Origin} {Branch}");
                }

                return str;
            }
        }

        private string _gitStr = "git -C {0}";

        private string FileStr()
        {
            return string.Format(_gitStr, FileDirectory) + " ";
        }

        private string Control(string str)
        {
            str = FileStr() + str;
            // string str = Console.ReadLine();
            //System.Console.InputEncoding = System.Text.Encoding.UTF8;//乱码

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true; //重定向标准错误输出
            p.StartInfo.CreateNoWindow = true; //不显示程序窗口
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8; //Encoding.GetEncoding("GBK");//乱码
            p.Start(); //启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令


            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();
            //Console.WriteLine(output);
            output += p.StandardError.ReadToEnd();
            //Console.WriteLine(output);

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit(); //等待程序执行完退出进程
            p.Close();

            return output + "\r\n";
        }
    }
}