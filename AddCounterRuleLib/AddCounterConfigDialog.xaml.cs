using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace AddCounterRuleLib
{
    /// <summary>
    /// Interaction logic for AddCounterConfigDialog.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1(string start, string step, string digits)
        {
            InitializeComponent();
            //this.LoadViewFromUri("/AddCounterRuleLib;component/AddCounterConfigDialog.xaml");
            startTextbox.Text = start;
            stepTextbox.Text = step;
            digitsTextbox.Text = digits;
        }

        public delegate void MyDelegateType(string start, string step, string digits);
        public event MyDelegateType Handler;
        public string Start { get; set; }
        public string Step { get; set; }
        public string Digits { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (Handler != null)
            {
                Handler(Start, Step, Digits);
            }
            Window.GetWindow(this).DialogResult = true;
        }

        private void startTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Start = startTextbox.Text;
        }

        private void stepTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Step = stepTextbox.Text;
        }

        private void digitsTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Digits = digitsTextbox.Text;
        }
    }
}
