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
using System.Xml;
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
    /// Interaction logic for ListOfRuleUC.xaml
    /// </summary>
    public partial class ListOfRuleUC : UserControl
    {
        BindingList<IRenamingRules> ListChosedRule;

        public ListOfRuleUC(BindingList<IRenamingRules> _listChosedRule)
        {
            InitializeComponent();
            ListChosedRule = _listChosedRule;
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            List<string> lisRule = new List<string>()
            { 
                "Change extension", //rule 1
                "Add counter to the end", //rule 2
                "Remove all spaces", //rule 3
                "Replace", //rule 4
                "Lowercase all, remove all spaces", //rule 5
                "Add Prefix", //rule 6
                "Add Suffix", //rule 7
                "PascalCase" //rule 8
            };

            ruleListView.ItemsSource = lisRule;            
        }

        /* Index 0: new extension name
                 1: selected counter format
                 2: needles
                 3: replacement
                 4: prefix
                 5: suffix
                 6: separator */
        static BindingList<string> _atributeList = new BindingList<string>()
        { "","","","","","" };

        // 8 user control page of rule 
        UserControl changeExtensionUc = new ChangeExtensionUC(_atributeList, false);
        UserControl addCounterUc = new AddCounterUC(_atributeList, false);
        UserControl removeAllSpacesUc = new RemoveAllSpacesUC();
        UserControl replaceUc = new ReplaceUC(_atributeList, false);        
        UserControl lowercaseAll_RemoveAllSpacesUc = new LowercaseAllAndRemoveAllSpacesUC();
        UserControl addPrefixUc = new AddPrefixUC(_atributeList, false);
        UserControl addSuffixUc = new AddSuffixUC(_atributeList, false);
        UserControl convertPascalCaseUc = new PascalCaseUC();

        private void ruleListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Configuration.Children.Clear();
            int indexSelected = ruleListView.SelectedIndex;

            switch (indexSelected)
            {
                case 0:
                    Configuration.Children.Add(changeExtensionUc);
                    break;
                case 1:
                    Configuration.Children.Add(addCounterUc);
                    break;
                case 2:
                    Configuration.Children.Add(removeAllSpacesUc);
                    break;
                case 3:
                    Configuration.Children.Add(replaceUc);
                    break;
                case 4:
                    Configuration.Children.Add(lowercaseAll_RemoveAllSpacesUc);
                    break;
                case 5:
                    Configuration.Children.Add(addPrefixUc);
                    break;
                case 6:
                    Configuration.Children.Add(addSuffixUc);
                    break;
                case 7:
                    Configuration.Children.Add(convertPascalCaseUc);
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int indexSelected = ruleListView.SelectedIndex;
            IRenamingRules chosedRule = null;

            switch (indexSelected)
            {
                case 0:
                    chosedRule = new ChangeExtensionRule.ChangeExtensionRule() { stringchange = string.Copy(_atributeList[0]) };
                    break;
                case 1:
                    chosedRule = new AddCounterRule.AddCounterRule() { choice = string.Copy(_atributeList[1]) };
                    break;
                case 2:
                    chosedRule = new RemoveAllSpacesRule.RemoveAllSpacesRule();
                    break;
                case 3:
                    chosedRule = new ReplaceRule.ReplaceRule() { Needle = string.Copy(_atributeList[2]), Replacement = string.Copy(_atributeList[3]) };
                    break;
                case 4:
                    chosedRule = new LowercaseAllAndRemoveAllSpacesRule.LowercaseAllAndRemoveAllSpacesRule();
                    break;
                case 5:
                    chosedRule = new AddPrefixRule.AddPrefixRule() { prefix = string.Copy(_atributeList[4]) };
                    break;
                case 6:
                    chosedRule = new AddSuffixRule.AddSuffixRule() { suffix = string.Copy(_atributeList[5]) };
                    break;
                case 7:
                    chosedRule = new PascalCaseRule.PascalCaseRule();
                    break;
            }

            ListChosedRule.Add(chosedRule);
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
