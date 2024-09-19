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
    /// Interaction logic for SavePresetUC.xaml
    /// </summary>
    public partial class SavePresetUC : UserControl
    {
        BindingList<Preset> listPreset;
        BindingList<IRenamingRules> listRuleChosed;
        public SavePresetUC(BindingList<Preset> _listPreset, BindingList<IRenamingRules> _listRuleChosed)
        {
            InitializeComponent();
            listPreset = _listPreset;
            listRuleChosed = _listRuleChosed;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(namePresetTextbox.Text))
            {
                bool isDuplicatedName = false;
                foreach (var preset in listPreset)
                {
                    if (namePresetTextbox.Text == preset.Name)
                    {
                        isDuplicatedName = true;
                        break;
                    }
                }

                if (!isDuplicatedName)
                {
                    Preset newPreset = new Preset() { Name = namePresetTextbox.Text };
                    newPreset.InsertRule(listRuleChosed);
                    listPreset.Add(newPreset);

                    var myWindow = Window.GetWindow(this);
                    myWindow.Close();
                }
                else
                    MessageBox.Show($"Name \"{namePresetTextbox.Text}\" is already existed !");
            }
            else
                MessageBox.Show("Preset's name can not be left empty !");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}