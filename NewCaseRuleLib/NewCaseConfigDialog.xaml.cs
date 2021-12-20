using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewCaseRuleLib
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1(int choice)
        {
            InitializeComponent();
            //this.LoadViewFromUri("/NewCaseRuleLib;component/NewCaseConfigDialog.xaml");
            _case = choice;
        }

        private int _case { get; set; }
        Dictionary<int, string> _options;
        public delegate void MyDelegateType(int data);
        public event MyDelegateType Handler;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _options = new Dictionary<int, string>();
            _options.Add(0, "All Upper Case");
            _options.Add(1, "All Lower Case");
            _options.Add(2, "To Pascal Case");

            TypeCombobox.ItemsSource = _options;
            TypeCombobox.SelectedIndex = _case;
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            int data = TypeCombobox.SelectedIndex;

            if (Handler != null)
            {
                Handler(data);
            }
            Window.GetWindow(this).DialogResult = true;
        }


        private void TypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}