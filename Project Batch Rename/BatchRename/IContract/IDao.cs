// ref & guided by anh Phuoc Tan 20BIT

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IContract
{
    public interface IDao
    {
        string Description { get; }

        BindingList<string> LoadAllFileNameChosed();
        BindingList<IRenamingRules> LoadAllRuleChosed();
        BindingList<Preset> LoadAllPresetSaved();
        List<double> LoadWindowLastSetUp();

        bool InsertAllFileNameChosed(BindingList<string> a);
        bool InsertAllRuleChosed(BindingList<IRenamingRules> r);
        bool InsertAllPresetSaved(BindingList<Preset> p);
        bool InsertLastWindowSetUp(double _width, double _height, double _top, double _left);
    }
}