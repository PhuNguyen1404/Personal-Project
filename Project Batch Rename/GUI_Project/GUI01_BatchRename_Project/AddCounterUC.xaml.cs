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
    /// Interaction logic for AddCounterUC.xaml
    /// </summary>
    public partial class AddCounterUC : UserControl
    {
        BindingList<string> data;
        bool isEdit = new bool();

        public AddCounterUC(BindingList<string> _data, bool _isEdit)
        {
            isEdit = _isEdit;
            InitializeComponent();
            data = _data;

            if (isEdit == true)
            {
                switch (data[0])
                {
                    case "Formal format":
                        FormalRadio.IsChecked = true;
                        break;
                    case "Roman format":
                        RomanRadio.IsChecked = true;
                        break;
                }
            }
            else
            {
                FormalRadio.IsChecked = true;
                data[1] = "Formal format"; //dafault add rule
            }
        }

            private void FormalRadio_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
                data[1] = "Formal format";
            else
                data[0] = "Formal format";
        }

        private void RomanRadio_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
                data[1] = "Roman format";
            else
                data[0] = "Roman format";
        }
    }
}