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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

//Load dll
using IContract;
using ChangeExtensionRule;
using AddCounterRule;
using RemoveAllSpacesRule;
using ReplaceRule;
using LowercaseAllAndRemoveAllSpacesRule;
using AddPrefixRule;
using AddSuffixRule;
using PascalCaseRule;

namespace GUI01_BatchRename_Project
{
    /// <summary>
    /// Interaction logic for LoadPresetUC.xaml
    /// </summary>
    public partial class LoadPresetUC : UserControl
    {
        BindingList<Preset> listPresets;
        BindingList<IRenamingRules> listRuleChosed;
        public LoadPresetUC(BindingList<Preset> _listPresets, BindingList<IRenamingRules> _listRuleChosed)
        {
            listPresets = _listPresets;
            listRuleChosed = _listRuleChosed;
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            presetsListView.ItemsSource = listPresets;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (presetsListView.SelectedItems.Count > 0)
            {
                listRuleChosed.Clear();
                int indexPresetSelected = presetsListView.SelectedIndex;

                for (int i = 0; i < listPresets[indexPresetSelected].rulesListSave.Count; i++)
                    listRuleChosed.Add(listPresets[indexPresetSelected].rulesListSave[i]);

                var myWindow = Window.GetWindow(this);
                myWindow.Close();
            }
            else
                MessageBox.Show("Please choose one preset !");

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
        private void MenuDeletePresetItem_Click(object sender, RoutedEventArgs e)
        {
            listPresets.RemoveAt(presetsListView.SelectedIndex);
            presetsListView.Items.Refresh();
        }
    }
}
