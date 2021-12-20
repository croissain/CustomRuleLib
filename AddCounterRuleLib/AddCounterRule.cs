using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AddCounterRuleLib
{
    public class AddCounterRule : IRenameRule
    {
        public string MagicWord
        {
            get => "Counter";
        }
        public string Start
        {
            get; set;
        }
        public string Step
        {
            get; set;
        }
        public string NumberOfDigits
        {
            get; set;
        }

        public string Rename(string original, int index)
        {
            string result = original;

            int numberOfDigit = int.Parse(NumberOfDigits);
            int lastDot = result.LastIndexOf('.');
            if (lastDot != -1)
            {
                string filename = result.Substring(0, lastDot);
                string extension = result.Substring(lastDot, original.Length - filename.Length);

                int temp = numberOfDigit - (int.Parse(Start) + index * int.Parse(Step)).ToString().Length;
                if (temp < 0)
                    return original;
                while (temp > 0)
                {
                    filename += "0";
                    temp--;
                }
                int cnter = int.Parse(Start) + index * int.Parse(Step);
                result = $"{filename}{cnter}{extension}";
            }
            else
            {
                int temp = numberOfDigit - (index * int.Parse(Step)).ToString().Length;
                if (temp < 0)
                {
                    return original;
                }
                while (temp > 0)
                {
                    result += "0";
                    temp--;
                }
                int cnter = int.Parse(Start) + index * int.Parse(Step);
                result = $"{result}{cnter}";
            }

            return result;
        }

        public string Config(IRenameRule rule)
        {
            var myrule = rule as AddCounterRule;
            Window addCounterDialog = new Window
            {
                Title = "Add Counter Config Dialog",
                Content = new UserControl1(myrule.Start, myrule.Step, myrule.NumberOfDigits),
                Width = 300,
                Height = 330
            };

            var userControl = addCounterDialog.Content as UserControl1;
            userControl.Handler += (string start, string step, string digits) => { Start = start; Step = step; NumberOfDigits = digits; };

            addCounterDialog.ShowDialog();

            if (addCounterDialog.DialogResult == true)
            {
                return $"{MagicWord} {Start} {Step} {NumberOfDigits}";
            }
            return "";
        }

        public IRenameRule Clone()
        {
            return new AddCounterRule() { Start = "", Step = "", NumberOfDigits = "" };
        }

        public override string ToString()
        {
            return $"{MagicWord} {Start} {Step} {NumberOfDigits}";
        }
    }

    public class AddCounterRuleParser : IRenameRuleParser
    {
        public string MagicWord
        {
            get => "Counter";
        }

        public IRenameRule Parse(string line)
        {
            var tokens = line.Split(' ');

            string start = tokens[1];
            string step = tokens[2];
            string digits = tokens[3];

            IRenameRule rule = new AddCounterRule() { Start = start, Step = step, NumberOfDigits = digits };
            return rule;
        }
    }
}
