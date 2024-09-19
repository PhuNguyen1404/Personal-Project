using IContract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;

namespace GUI01_BatchRename_Project
{
    public partial class GUI01_BatchRename : UserControl
    {
        IBus Bus0;
        static BindingList<string> allFilePathSelected = new BindingList<string>();
        static BindingList<IRenamingRules> allRuleChosed = new BindingList<IRenamingRules>();
        static BindingList<Preset> allPreset = new BindingList<Preset>();


        public GUI01_BatchRename(IBus bus)
        {
            Bus0 = bus;
            InitializeComponent();
            this.Loaded += UserControl_Loaded;
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            allFilePathSelected = Bus0.LoadAllFileNameChosed();
            allRuleChosed = Bus0.LoadAllRuleChosed();
            allPreset = Bus0.LoadAllPresetSaved();

            ruleSelectedListView.ItemsSource = allRuleChosed;
            selectedFileNameListView.ItemsSource = allFilePathSelected;
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.Multiselect = true;
            openFileDlg.Filter = "All files (*.*)|*.*";
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                for (int i = 0; i < openFileDlg.FileNames.Length; i++)
                {
                    string temp01 = openFileDlg.FileNames[i];
                    bool isDupplicated = false;
                    foreach (string temp02 in allFilePathSelected) 
                    {
                        if (temp01 == temp02)
                        {
                            isDupplicated = true;
                            break;
                        }
                    }

                    if (isDupplicated == false)
                        allFilePathSelected.Add(temp01);
                }
            }
        }

        private void AddFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog Folder_Browser = new System.Windows.Forms.FolderBrowserDialog();

            if(Folder_Browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = Directory.GetFiles(Folder_Browser.SelectedPath, "*", SearchOption.AllDirectories);

                for(int i = 0; i < files.Length; i++)
                {
                    string temp01 = files[i];
                    bool isDupplicated = false;

                    foreach (string temp02 in allFilePathSelected) //Check dupplication
                    {
                        if (temp01 == temp02)
                        {
                            isDupplicated = true;
                            break;
                        }
                    }

                    if (isDupplicated == false)
                        allFilePathSelected.Add(temp01);
                }
            }
        }

        private void selectedFileNameListView_Drop(object sender, DragEventArgs e)
        {
            bool isHavingFolder = false;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int i = 0; i < files.Length; i++)
                {
                    FileAttributes attr = File.GetAttributes(files[i]);
                    if (!attr.HasFlag(FileAttributes.Directory))
                    {
                        string temp01 = files[i];
                        bool isDupplicated = false;

                        foreach (string temp02 in allFilePathSelected) //Check dupplication
                        {
                            if (temp01 == temp02)
                            {
                                isDupplicated = true;
                                break;
                            }
                        }

                        if (isDupplicated == false)
                            allFilePathSelected.Add(temp01);
                    }
                    else
                        isHavingFolder = true;
                }
            }
            if (isHavingFolder)
                MessageBox.Show("Folder is not allowed in drop action !");
        }

        private void AddRules_Click(object sender, RoutedEventArgs e)
        {
            Window ListOfRuleWindow = new Window()
            {
                Title = "List Of Rule Window",
                Content = new ListOfRuleUC(allRuleChosed),
                Width = 635,
                Height = 440,
                ResizeMode = ResizeMode.NoResize,
                Icon = BitmapFrame.Create(new Uri("icon_app.png",UriKind.RelativeOrAbsolute))
            };

            ListOfRuleWindow.ShowDialog();
        }

        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            if (allRuleChosed.Count == 0)
                MessageBox.Show("No rule chosed to apply, please choose some rule !");
            else if (allFilePathSelected.Count == 0)
                MessageBox.Show("No file name chosed to apply, please add some file !");
            else
            {
                List<string> PreviewResultList = Bus0.PreviewNewNameResult(allRuleChosed, allFilePathSelected);
                Window PreviewWindow = new Window()
                {
                    Title = "List Of Rule Window",
                    Content = new PreviewUC(PreviewResultList),
                    Width = 540,
                    Height = 320,
                    MinWidth = 540,
                    MinHeight = 320,
                    Icon = BitmapFrame.Create(new Uri("icon_app.png", UriKind.RelativeOrAbsolute))
                };

                PreviewWindow.ShowDialog();
            }
        }

        private void RunFile_Click(object sender, RoutedEventArgs e)
        {
            if (allRuleChosed.Count == 0)
                MessageBox.Show("No rule chosed to apply, please choose some rule !");
            else if (allFilePathSelected.Count == 0)
                MessageBox.Show("No file name chosed to apply, please add some file !");
            else
            {
                Bus0.ApplyAllRule(allRuleChosed, allFilePathSelected);
                MessageBox.Show("Rename success !");
            }
        }


        private void SavePreset_Click(object sender, RoutedEventArgs e)
        {
            if (allRuleChosed.Count > 0)
            {
                Window savePresetWindow = new Window()
                {
                    Title = "Save New Preset Window",
                    Content = new SavePresetUC(allPreset, allRuleChosed),
                    Width = 320,
                    Height = 310,
                    ResizeMode = ResizeMode.NoResize,
                    Icon = BitmapFrame.Create(new Uri("icon_app.png", UriKind.RelativeOrAbsolute))
                };

                savePresetWindow.ShowDialog();
            }
            else
                MessageBox.Show("No rules chosed to be save !");
        }


        private void LoadPreset_Click(object sender, RoutedEventArgs e)
        {
            Window loadPresetWindow = new Window()
            {
                Title = "Load Preset Window",
                Content = new LoadPresetUC(allPreset, allRuleChosed),
                Width = 410,
                Height = 460,
                ResizeMode = ResizeMode.NoResize,
                Icon = BitmapFrame.Create(new Uri("icon_app.png", UriKind.RelativeOrAbsolute))
            };

            loadPresetWindow.ShowDialog();
        }

        private void MenuEditRuleItem_Click(object sender, RoutedEventArgs e)
        {
            Window editRuleWindow = new Window()
            {
                Title = "Edit Rule Window",
                Content = new EditRuleUC(allRuleChosed, ruleSelectedListView.SelectedIndex),
                Width = 410,
                Height = 420,
                ResizeMode = ResizeMode.NoResize,
                Icon = BitmapFrame.Create(new Uri("icon_app.png", UriKind.RelativeOrAbsolute))
            };

            editRuleWindow.ShowDialog();
        }

        private void MenuDeleteRuleItem_Click(object sender, RoutedEventArgs e)
        {
            int amountChosed = ruleSelectedListView.SelectedItems.Count;
            for (int i = 0; i < amountChosed; i++)
            {
                int index = ruleSelectedListView.Items.IndexOf(ruleSelectedListView.SelectedItems[0]);
                allRuleChosed.RemoveAt(index);
            }

            ruleSelectedListView.Items.Refresh();
        }

        private void MenuDeleteFilePathItem_Click(object sender, RoutedEventArgs e)
        {
            int amountChosed = selectedFileNameListView.SelectedItems.Count;
            for (int i = 0; i < amountChosed; i++)
            {
                int index = selectedFileNameListView.Items.IndexOf(selectedFileNameListView.SelectedItems[0]);
                allFilePathSelected.RemoveAt(index);
            }

            selectedFileNameListView.Items.Refresh();
        }

        private void ruleSelectedListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ruleSelectedListView.SelectedItems.Count != 1)
                MenuEditRuleItem.IsEnabled = false;
            else if (ruleSelectedListView.SelectedItems.Count == 1)
            {
                string nameRule = allRuleChosed[ruleSelectedListView.SelectedIndex].Name;
                switch(nameRule)
                {
                    case "Remove all spaces": case "Lowercase all and no spaces": case "PascalCase":
                        MenuEditRuleItem.IsEnabled = false;
                        break;
                    default:
                        MenuEditRuleItem.IsEnabled = true;
                        break;
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            List<double> w_lastSetUp = Bus0.LoadWindowLastSetUp();

            window.Width = w_lastSetUp[0];
            window.Height = w_lastSetUp[1];
            window.Top = w_lastSetUp[2];
            window.Left = w_lastSetUp[3];
            window.Closing += window_Closing;
        }

        void window_Closing(object sender, global::System.ComponentModel.CancelEventArgs e)
        {
            Bus0.InsertAllRuleChosed(allRuleChosed);
            Bus0.InsertAllFileNameChosed(allFilePathSelected);
            Bus0.InsertAllPresetSaved(allPreset);

            Window window = Window.GetWindow(this);
            double w_width = window.ActualWidth;
            double w_height = window.ActualHeight;
            double w_top = window.Top;
            double w_left = window.Left;
            Bus0.InsertLastWindowSetUp(w_width, w_height, w_top, w_left);
        }
    }
}