using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Reflection;
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).DialogResult = true;
        }

        private void startTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string start = startTextbox.Text;
            string step = stepTextbox.Text;
            string digits = digitsTextbox.Text;
            if (Handler != null)
            {
                Handler(start, step, digits);
            }
        }

        private void stepTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string start = startTextbox.Text;
            string step = stepTextbox.Text;
            string digits = digitsTextbox.Text;
            if (Handler != null)
            {
                Handler(start, step, digits);
            }
        }

        private void digitsTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string start = startTextbox.Text;
            string step = stepTextbox.Text;
            string digits = digitsTextbox.Text;
            if (Handler != null)
            {
                Handler(start, step, digits);
            }
        }
    }
}
