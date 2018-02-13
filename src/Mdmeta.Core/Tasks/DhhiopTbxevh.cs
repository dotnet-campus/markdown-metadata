using System;
using System.Collections.Generic;
using System.IO;

namespace Mdmeta.Tasks
{
    public class DhhiopTbxevh
    {
        public string SacdpDkqz { set; get; } =
            @"---
title: ""{{ Title }}""
author: {{ Composer }}
date: {{ date }}
CreateTime: {{ CreateTime }}
categories: {{ 标签 }}
---

{{ Excerpt }}

<!--more-->

---

{{ Content }}";

        public void TewavuiKukm(string file, HvjEthpiaca tcxSfdxhx)
        {
            var tyyKflgjlmbr = new SszHspndy(tcxSfdxhx);

            string str = tyyKflgjlmbr.DvyovKysizejh(SacdpDkqz).Replace("{{ Title }}", tcxSfdxhx.Title).Replace("{{ Composer }}", tcxSfdxhx.Composer).Replace("{{ date }}", tcxSfdxhx.Time).Replace("{{ CreateTime }}", tcxSfdxhx.CreateTime).Replace("{{ 标签 }}", "").Replace("{{ Excerpt }}", tcxSfdxhx.Excerpt).Replace("{{ Content }}", tcxSfdxhx.Text);

            using (StreamWriter stream = new StreamWriter(file))
            {
                stream.Write(str);
            }
        }
    }
}