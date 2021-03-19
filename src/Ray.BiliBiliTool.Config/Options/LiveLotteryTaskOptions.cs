﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.BiliBiliTool.Config.Options
{
    public class LiveLotteryTaskOptions
    {
        public string IncludeAwardNames { get; set; }

        public string ExcludeAwardNames { get; set; }

        public bool IsAutoUnfollow { get; set; }

        public List<string> IncludeAwardNameList =>
            IncludeAwardNames?.Split("|",
                    StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList()
            ?? new List<string>();

        public List<string> ExcludeAwardNameList =>
            ExcludeAwardNames?.Split("|",
                    StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList()
            ?? new List<string>();
    }
}