﻿using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NewCaseRuleLib
{
    enum CaseEnum : int
    {
        ToUpper = 0,
        ToLower = 1,
        ToPascal = 2
    }
    public class NewCaseRule : IRenameRule
    {
        public string MagicWord => "NewCase";
        public int Case { get; set; }

        //Hiển thị màn hình config để nhận dữ liệu từ các input phục vụ cho việc đổi tên
        public string Config(IRenameRule rule)
        {
            var myrule = rule as NewCaseRule;
            Window newCaseDialog = new Window
            {
                Title = "New Case Config Dialog",
                Content = new UserControl1(myrule.Case),
                Width = 300,
                Height = 250
            };

            var userControl = newCaseDialog.Content as UserControl1;
            userControl.Handler += (int data) => { this.Case = data; };

            newCaseDialog.ShowDialog();

            if (newCaseDialog.DialogResult == true)
            {
                return $"{MagicWord} {Case}";
            }
            return "";
        }

        public string Rename(string original, int index)
        {
            string result = original;
            int i = result.LastIndexOf('.');
            string name = i > 0 ?result.Substring(0, i): result;
            string extension = i > 0 ? result.Substring(i, original.Length - name.Length): "";

            if (Case == (int)CaseEnum.ToUpper)
            {
                name = name.ToUpper().Replace(" ", "");
                result = $"{name}{extension}";
            }
            else if(Case == (int)CaseEnum.ToLower)
            {
                name = name.ToLower().Replace(" ", "");
                result = $"{name}{extension}";
            }
            else
            {
                name = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name).Replace(" ", "");
                result = $"{name}{extension}";
            }

            return result;
        }

        public IRenameRule Clone()
        {
            return new NewCaseRule() { Case = 0 };
        }

        public override string ToString()
        {
            return $"{MagicWord} {Case}";
        }
    }

    public class NewCaseRuleParser : IRenameRuleParser
    {
        public string MagicWord { get => "NewCase"; }

        //Hàm parse dùng để parse một dòng thành một rule
        public IRenameRule Parse(string line)
        {
            int choice = Int32.Parse(line.Replace($"{MagicWord} ", "").Replace(" ", ""));

            IRenameRule rule = new NewCaseRule() { Case = choice};
            return rule;
        }
    }
}
