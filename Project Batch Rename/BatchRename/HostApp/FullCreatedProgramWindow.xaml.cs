using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HostApp
{
    /// <summary>
    /// Interaction logic for FullCreatedProgramWindow.xaml
    /// </summary>
    public partial class FullCreatedProgramWindow : Window
    {
        UserControl mainUc;
        public FullCreatedProgramWindow(UserControl uc)
        {
            InitializeComponent();
            mainUc = uc;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(mainUc);
        }
    }
}
