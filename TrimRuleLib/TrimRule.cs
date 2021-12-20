using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace TrimRuleLib
{
    class TrimRule : IRenameRule
    {
        public string MagicWord
        {
            get => "Trim";
        }

        public string Rename(string original, int index)
        {
            string result = original;
            //char[] firstChar = result.ToCharArray(0, 1);
            // result = string.Join(" ", result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            result = result.Trim();
            Regex trimmer = new Regex(@"\s\s+");
            result = trimmer.Replace(result, "");

            return result;
        }

        //Hiển thị màn hình config để nhận dữ liệu từ các input phục vụ cho việc đổi tên
        public string Config(IRenameRule rule)
        {
            var myrule = rule as TrimRule;
            Window TrimDialog = new Window
            {
                Title = "Trim Config Dialog",
                Content = new UserControl1(),
                Width = 300,
                Height = 250
            };

            var userControl = TrimDialog.Content as UserControl1;

            TrimDialog.ShowDialog();

            if (TrimDialog.DialogResult == true)
            {
                return $"{MagicWord}";
            }

            return "";
        }

        public IRenameRule Clone()
        {
            return new TrimRule() { };
        }

        public override string ToString()
        {
            return $"{MagicWord}";
        }
    }

    public class TrimRuleParser : IRenameRuleParser
    {
        public string MagicWord
        {
            get => "Trim";
        }

        //Hàm parse dùng để parse một dòng thành một rule
        public IRenameRule Parse(string line)
        {
            IRenameRule rule = new TrimRule() { };
            return rule;
        }
    }
}