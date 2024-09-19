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

namespace GUI01_BatchRename_Project
{
    /// <summary>
    /// Interaction logic for ReplaceUC.xaml
    /// </summary>
    public partial class ReplaceUC : UserControl
    {
        BindingList<string> data;
        bool isEdit = new bool();

        public ReplaceUC(BindingList<string> _data, bool _isEdit)
        {
            isEdit = _isEdit;
            InitializeComponent();
            data = _data;
            if (isEdit == true)
            {
                needlesTextbox.Text = data[0];
                replacementTextbox.Text = data[1];
            }
        }

        private void needlesTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            needlesTextbox.Text = needlesTextbox.Text.Replace("\\", "");
            needlesTextbox.Text = needlesTextbox.Text.Replace("/", "");
            needlesTextbox.Text = needlesTextbox.Text.Replace("\"", "");
            needlesTextbox.Text = needlesTextbox.Text.Replace("<", "");
            needlesTextbox.Text = needlesTextbox.Text.Replace(">", "");
            needlesTextbox.Text = needlesTextbox.Text.Replace("|", "");
            if (isEdit == false)
                data[2] = needlesTextbox.Text;
            else
                data[0] = needlesTextbox.Text;
        }

        private void replacementTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            replacementTextbox.Text = replacementTextbox.Text.Replace("\\", "");
            replacementTextbox.Text = replacementTextbox.Text.Replace("/", "");
            replacementTextbox.Text = replacementTextbox.Text.Replace("\"", "");
            replacementTextbox.Text = replacementTextbox.Text.Replace("<", "");
            replacementTextbox.Text = replacementTextbox.Text.Replace(">", "");
            replacementTextbox.Text = replacementTextbox.Text.Replace("|", "");
            if (isEdit == false)
                data[3] = replacementTextbox.Text;
            else
                data[1] = replacementTextbox.Text;
        }

        private void needlesTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "\\"
            || e.Text == "/"
            || e.Text == "?"
            || e.Text == "\""
            || e.Text == "<"
            || e.Text == ">"
            || e.Text == "|")
            {
                MessageBox.Show($"File name don't have \"{e.Text}\"");
                e.Handled = true;
            }
        }

        private void replacementTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "\\"
            || e.Text == "/"
            || e.Text == "?"
            || e.Text == "\""
            || e.Text == "<"
            || e.Text == ">"
            || e.Text == "|")
            {
                MessageBox.Show($"File name can not contain \"{e.Text}\"");
                e.Handled = true;
            }
        }
    }
}
