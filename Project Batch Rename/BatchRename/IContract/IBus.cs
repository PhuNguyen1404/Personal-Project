using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IContract
{
    public interface IBus
    {
        IDao Dao { get; set; }
        string Description { get; }

        BindingList<string> LoadAllFileNameChosed();
        BindingList<IRenamingRules> LoadAllRuleChosed();
        BindingList<Preset> LoadAllPresetSaved();
        List<double> LoadWindowLastSetUp();

        bool InsertAllFileNameChosed(BindingList<string> a);
        bool InsertAllRuleChosed(BindingList<IRenamingRules> r);
        bool InsertAllPresetSaved(BindingList<Preset> p);
        bool InsertLastWindowSetUp(double _width, double _height, double _top, double _left);

        void ApplyAllRule(BindingList<IRenamingRules> listRules, BindingList<string> FileNamePath);
        List<string> PreviewNewNameResult(BindingList<IRenamingRules> listRules, BindingList<string> FileNamePath);
    }
}
