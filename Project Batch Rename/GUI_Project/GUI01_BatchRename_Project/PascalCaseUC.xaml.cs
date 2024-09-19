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
    /// Interaction logic for PascalCaseUC.xaml
    /// </summary>
    public partial class PascalCaseUC : UserControl
    {
        public PascalCaseUC()
        {
            InitializeComponent();
        }

        public PascalCaseUC(BindingList<string> _parametersEdit, object nothing)
        {
            InitializeComponent();
        }
    }
}