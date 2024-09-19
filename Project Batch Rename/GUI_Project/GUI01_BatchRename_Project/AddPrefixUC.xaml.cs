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
    /// Interaction logic for AddPrefixUC.xaml
    /// </summary>
    public partial class AddPrefixUC : UserControl
    {
        BindingList<string> data;
        bool isEdit = new bool();

        public AddPrefixUC(BindingList<string> _data, bool _isEdit)
        {
            isEdit = _isEdit;
            InitializeComponent();
            data = _data;
            if(isEdit == true)
                PrefixTextbox.Text = data[0];
        }

        private void PrefixTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PrefixTextbox.Text = PrefixTextbox.Text.Replace("\\", "");
            PrefixTextbox.Text = PrefixTextbox.Text.Replace("/", "");
            PrefixTextbox.Text = PrefixTextbox.Text.Replace("\"", "");
            PrefixTextbox.Text = PrefixTextbox.Text.Replace("<", "");
            PrefixTextbox.Text = PrefixTextbox.Text.Replace(">", "");
            PrefixTextbox.Text = PrefixTextbox.Text.Replace("|", "");

            if (isEdit == false)
                data[4] = PrefixTextbox.Text;
            else
                data[0] = PrefixTextbox.Text;
        }

        private void PrefixTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
