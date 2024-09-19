using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IContract
{
    public class Preset
    {
        public string Name { get; set; }
        public List<IRenamingRules> rulesListSave { get; }
        public int amountRuleHold => rulesListSave.Count;

        public Preset()
        {
            rulesListSave = new List<IRenamingRules>();
        }

        public void InsertRule(BindingList<IRenamingRules> _listRule)
        {
            for(int i = 0; i < _listRule.Count; i++)
            {
                rulesListSave.Add(_listRule[i]);
            }
        }
    }
}
