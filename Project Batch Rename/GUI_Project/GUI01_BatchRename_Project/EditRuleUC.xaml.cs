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
    /// Interaction logic for EditRuleUC.xaml
    /// </summary>
    public partial class EditRuleUC : UserControl
    {
        BindingList<IRenamingRules> listChosedRule;
        static BindingList<string> parameters = new BindingList<string>() { "", "" };
        int indexSelected;
        UserControl editConfigUC;

        public EditRuleUC(BindingList<IRenamingRules> _listChosedRule, int _indexSelected)
        {
            listChosedRule = _listChosedRule;
            indexSelected = _indexSelected;
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            string NameRule = listChosedRule[indexSelected].Name;
            string Description = listChosedRule[indexSelected].Description;
            int vt;

            switch (NameRule)
            {
                case "Change Extension":                    
                    vt = Description.IndexOf("to");
                    parameters[0] = Description.Substring(vt + 4, Description.Length - (vt + 5));
                    editConfigUC = new ChangeExtensionUC(parameters, true);
                    break;
                case "Counter":
                    vt = Description.IndexOf("with");
                    parameters[0] = Description.Substring(vt + 5, Description.Length - (vt + 5));
                    editConfigUC = new AddCounterUC(parameters, true);
                    break;
                case "Replacement":
                    int firstSpaceIndex = Description.IndexOf(" ");
                    string name = Description.Substring(0, firstSpaceIndex);
                    int finding = Description.IndexOf("→");
                    parameters[0] = Description.Substring(firstSpaceIndex + 2, finding - name.Length - 4);
                    parameters[1] = Description.Substring(finding + 3, Description.Length - (finding + 4));
                    editConfigUC = new ReplaceUC(parameters, true);
                    break;
                case "Prefix":
                    vt = Description.IndexOf("prefix");
                    parameters[0] = Description.Substring(vt + 8, Description.Length - (vt + 9));
                    editConfigUC = new AddPrefixUC(parameters, true);
                    break;
                case "Suffix":
                    vt = Description.IndexOf("suffix");
                    parameters[0] = Description.Substring(vt + 8, Description.Length - (vt + 9));
                    editConfigUC = new AddSuffixUC(parameters, true);
                    break;
            }
            Configuration.Children.Add(editConfigUC);
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            string NameRule = listChosedRule[indexSelected].Name;
            IRenamingRules temp = null;
            switch (NameRule)
            {
                case "Change Extension":
                    temp = new ChangeExtensionRule.ChangeExtensionRule() { stringchange = parameters[0] };
                    break;
                case "Counter":
                    temp = new AddCounterRule.AddCounterRule { choice = parameters[0] };
                    break;
                case "Replacement":
                    temp = new ReplaceRule.ReplaceRule() { Needle = parameters[0], Replacement = parameters[1] };
                    break;
                case "Prefix":
                    temp = new AddPrefixRule.AddPrefixRule() { prefix = parameters[0] };
                    break;
                case "Suffix":
                    temp = new AddSuffixRule.AddSuffixRule() { suffix = parameters[0] };
                    break;
            }
            listChosedRule[indexSelected] = temp;

            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
