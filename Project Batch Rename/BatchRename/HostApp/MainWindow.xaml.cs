using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace HostApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Quét toàn bộ thư mục - Lấy thư mục hiện tại
            var exePath = Assembly.GetExecutingAssembly().Location;
            var folder = System.IO.Path.GetDirectoryName(exePath);
            var fis = new DirectoryInfo(folder).GetFiles("*.dll");

            var iguis = new List<IGUI>();
            var ibuses = new List<IBus>();
            var idaos = new List<IDao>();

            foreach (var fi in fis)
            {
                var domain = AppDomain.CurrentDomain;
                var assembly = domain.Load(AssemblyName.GetAssemblyName(fi.FullName));
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.IsClass)
                    {
                        if (typeof(IGUI).IsAssignableFrom(type))
                        {
                            iguis.Add(Activator.CreateInstance(type) as IGUI);
                        }
                        else if (typeof(IBus).IsAssignableFrom(type))
                        {
                            ibuses.Add(Activator.CreateInstance(type) as IBus);
                        }
                        else if (typeof(IDao).IsAssignableFrom(type))
                        {
                            idaos.Add(Activator.CreateInstance(type) as IDao);
                        }
                    }
                }
            }

            guiComboBox.ItemsSource = iguis;
            busComboBox.ItemsSource = ibuses;
            daoComboBox.ItemsSource = idaos;
        }

        private void StartProgram_Click(object sender, RoutedEventArgs e)
        {
            var gui = guiComboBox.SelectedItem as IGUI;
            var bus = busComboBox.SelectedItem as IBus;
            var dao = daoComboBox.SelectedItem as IDao;

            gui.Bus = bus;
            bus.Dao = dao;

            var screen = new FullCreatedProgramWindow(gui.Show());
            screen.Show();
            this.Close();
        }
    }
}
