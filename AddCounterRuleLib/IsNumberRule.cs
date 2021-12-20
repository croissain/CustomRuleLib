using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AddCounterRuleLib
{
    public class IsNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int number = 0;
            try
            {
                string buffer = (string)value;
                if (buffer.Length > 0)
                {
                    string pattern = @"^\d+$";
                    Regex regex = new Regex(pattern);

                    if(regex.IsMatch(buffer))
                    {
                        number = Int32.Parse(buffer);
                    }
                    else
                    {
                        return new ValidationResult(false, "You need enter a number!");
                    }

                }
            }
            catch(Exception e)
            {
                return new ValidationResult(false, "Illegal characters");
            }

            return ValidationResult.ValidResult;
        }
    }
}
