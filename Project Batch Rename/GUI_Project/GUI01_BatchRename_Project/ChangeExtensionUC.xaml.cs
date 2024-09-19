using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IContract;

namespace GUI01_BatchRename_Project
{
    /// <summary>
    /// Interaction logic for ChangeExtensionUC.xaml
    /// </summary>
    public partial class ChangeExtensionUC : UserControl
    {      
        BindingList<string> data;
        bool isEdit = new bool();

        public ChangeExtensionUC(BindingList<string> _data, bool _isEdit)
        {
            isEdit = _isEdit;
            InitializeComponent();
            data = _data;

            if (isEdit == true)
                NewExtensionTextbox.Text = data[0];
        }

        private void NewExtensionTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewExtensionTextbox.Text = NewExtensionTextbox.Text.Replace(" ", "");
            NewExtensionTextbox.Text = NewExtensionTextbox.Text.Replace("\\", "");
            NewExtensionTextbox.Text = NewExtensionTextbox.Text.Replace("/", "");
            NewExtensionTextbox.Text = NewExtensionTextbox.Text.Replace("\"", "");
            NewExtensionTextbox.Text = NewExtensionTextbox.Text.Replace("<", "");
            NewExtensionTextbox.Text = NewExtensionTextbox.Text.Replace(">", "");
            NewExtensionTextbox.Text = NewExtensionTextbox.Text.Replace("|", "");
            data[0] = NewExtensionTextbox.Text;
        }

        private void NewExtensionTextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("Extension name can not contain white space");
            }
        }

        private void NewExtensionTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "\\"
            || e.Text == "/"
            || e.Text == "?"
            || e.Text == "\""
            || e.Text == "<"
            || e.Text == ">"
            || e.Text == "|"
            || e.Text == ".")
            {
                MessageBox.Show($"Extension name can not contain \"{e.Text}\"");
                e.Handled = true;
            }
        }
    }
}
