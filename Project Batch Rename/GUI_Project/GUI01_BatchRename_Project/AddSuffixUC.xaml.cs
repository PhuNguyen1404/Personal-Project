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
    /// Interaction logic for AddSuffixUC.xaml
    /// </summary>
    public partial class AddSuffixUC : UserControl
    {
        BindingList<string> data;
        bool isEdit = new bool();

        public AddSuffixUC(BindingList<string> _data, bool _isEdit)
        {
            isEdit = _isEdit;
            InitializeComponent();
            data = _data;

            if (isEdit == true)
                SuffixTextbox.Text = data[0];
        }

        private void SuffixTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SuffixTextbox.Text = SuffixTextbox.Text.Replace("\\", "");
            SuffixTextbox.Text = SuffixTextbox.Text.Replace("/", "");
            SuffixTextbox.Text = SuffixTextbox.Text.Replace("\"", "");
            SuffixTextbox.Text = SuffixTextbox.Text.Replace("<", "");
            SuffixTextbox.Text = SuffixTextbox.Text.Replace(">", "");
            SuffixTextbox.Text = SuffixTextbox.Text.Replace("|", "");

            if (isEdit == false)
                data[5] = SuffixTextbox.Text;
            else
                data[0] = SuffixTextbox.Text;
        }

        private void SuffixTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
