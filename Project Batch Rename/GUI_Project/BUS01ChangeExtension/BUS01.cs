using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IContract;
using System.ComponentModel;

namespace BUS01ChangeExtension
{
    public class BUS01ChangeExtension : IBus
    {
        public string Description => "Bus01 - Basic renaming rule";

        public IDao Dao { get; set; }

        public void ApplyAllRule(BindingList<IRenamingRules> listRules, BindingList<string> FileNamePath)
        {
            for(int i = 0; i < FileNamePath.Count; i++)
            {
                foreach(IRenamingRules eachRule in listRules)
                {
                    FileNamePath[i] = eachRule.Transform(FileNamePath[i], false); 
                }
            }
        }

        public List<string> PreviewNewNameResult(BindingList<IRenamingRules> listRules, BindingList<string> FileNamePath)
        {
            List<string> previewList = new List<string>();
            for (int i = 0; i < FileNamePath.Count; i++)
            {
                string temp = string.Copy(FileNamePath[i]);
                foreach (IRenamingRules eachRule in listRules)
                {
                    temp = eachRule.Transform(temp, true);
                }
                previewList.Add(temp);
            }

            return previewList;
        }

        // ref & guided by anh Phuoc Tan 20BIT

        public bool InsertAllFileNameChosed(BindingList<string> a)
        {
            return Dao.InsertAllFileNameChosed(a);
        }

        public bool InsertAllPresetSaved(BindingList<Preset> p)
        {
            return Dao.InsertAllPresetSaved(p);
        }

        public bool InsertAllRuleChosed(BindingList<IRenamingRules> r)
        {
            return Dao.InsertAllRuleChosed(r);
        }

        public bool InsertLastWindowSetUp(double _width, double _height, double _top, double _left)
        {
            return Dao.InsertLastWindowSetUp(_width, _height, _top, _left);
        }

        public BindingList<string> LoadAllFileNameChosed()
        {
            return Dao.LoadAllFileNameChosed();
        }

        public BindingList<Preset> LoadAllPresetSaved()
        {
            return Dao.LoadAllPresetSaved();
        }

        public BindingList<IRenamingRules> LoadAllRuleChosed()
        {
            return Dao.LoadAllRuleChosed();
        }

        public List<double> LoadWindowLastSetUp()
        {
            return Dao.LoadWindowLastSetUp();
        }
    }
}