// ref & guided by anh Phuoc Tan 20BIT

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

//Load all dll
using IContract;
using ChangeExtensionRule;
using AddCounterRule;
using RemoveAllSpacesRule;
using ReplaceRule;
using LowercaseAllAndRemoveAllSpacesRule;
using AddPrefixRule;
using AddSuffixRule;
using PascalCaseRule;
using System.IO;

namespace DAO01
{
    public class DAO01 : IDao
    {
        public string Description => "Dao01 XML";

        public bool InsertAllFileNameChosed(BindingList<string> a)
        {
            XDocument doc = XDocument.Load("AllFilenameChosed.xml");
            doc.Root.Elements().Remove();

            for (int i = 0; i < a.Count; i++)
            {
                doc.Element("Filenames").Add(new XElement("Filename", a[i]));
            }

            doc.Save("AllFilenameChosed.xml");
            return true;
        }

        public bool InsertAllPresetSaved(BindingList<Preset> p)
        {
            XDocument doc = XDocument.Load("AllPresetsSaved.xml");
            doc.Root.Elements().Remove();

            for (int i = 0; i < p.Count; i++)
            {
                XElement preset = new XElement("Preset", new XAttribute("Name", p[i].Name));
                for (int j = 0; j < p[i].rulesListSave.Count; j++)
                {
                    preset.Add(new XElement("Rule", p[i].rulesListSave[j].Description));
                }
                doc.Element("Presets").Add(preset);
            }

            doc.Save("AllPresetsSaved.xml");

            return true;
        }

        public bool InsertAllRuleChosed(BindingList<IRenamingRules> r)
        {
            XDocument doc = XDocument.Load("AllRuleChosed.xml");
            doc.Root.Elements().Remove();

            for (int i = 0; i < r.Count; i++)
            {
                doc.Element("Rules").Add(new XElement("Rule", r[i].Description));
            }

            doc.Save("AllRuleChosed.xml");
            return true;
        }

        public bool InsertLastWindowSetUp(double _width, double _height, double _top, double _left)
        {
            XDocument doc = XDocument.Load("WindowLastSetUp.xml");
            doc.Root.Elements().Remove();

            doc.Element("Window").Add(new XElement("Width", _width.ToString()));
            doc.Element("Window").Add(new XElement("Height", _height.ToString()));
            doc.Element("Window").Add(new XElement("Top", _top.ToString()));
            doc.Element("Window").Add(new XElement("Left", _left.ToString()));

            doc.Save("WindowLastSetUp.xml");
            return true;
        }

        public BindingList<string> LoadAllFileNameChosed()
        {
            BindingList<string> temp = new BindingList<string>();
            XDocument doc = XDocument.Load("AllFilenameChosed.xml");

            IEnumerable<XElement> Filenames = doc.Elements("Filenames").Elements();

            string singleFilePath = "";
            foreach (var Filename in Filenames)
            {
                singleFilePath = Filename.ToString();
                singleFilePath = singleFilePath.Substring(10, singleFilePath.Length - (10 + 11));
                if(File.Exists(singleFilePath))
                    temp.Add(singleFilePath);
            }

            return temp;
        }

        public BindingList<Preset> LoadAllPresetSaved()
        {
            XDocument doc = XDocument.Load("AllPresetsSaved.xml");
            BindingList<Preset> p = new BindingList<Preset>();
            IEnumerable<XElement> presets = doc.Elements("Presets").Elements();

            foreach (var _Preset in presets)
            {
                BindingList<IRenamingRules> r = new BindingList<IRenamingRules>();
                foreach (XElement node in _Preset.Nodes())
                {
                    string singleRuleDescription = "";
                    singleRuleDescription = node.ToString();
                    singleRuleDescription = singleRuleDescription.Substring(6, singleRuleDescription.Length - (6 + 7));

                    IRenamingRules IRule = getRuleFactory(singleRuleDescription);

                    r.Add(IRule);
                }
                Preset t = new Preset();
                t.InsertRule(r);
                t.Name = _Preset.Attribute("Name").Value;
                p.Add(t);
            }

            return p;
        }

        public BindingList<IRenamingRules> LoadAllRuleChosed()
        {
            BindingList<IRenamingRules> temp = new BindingList<IRenamingRules>();
            XDocument doc = XDocument.Load("AllRuleChosed.xml");
            IEnumerable<XElement> Rules = doc.Elements("Rules").Elements();

            string singleRuleDescription = "";
            foreach (var Rule in Rules)
            {
                singleRuleDescription = Rule.ToString();
                singleRuleDescription = singleRuleDescription.Substring(6, singleRuleDescription.Length - (6 + 7));

                IRenamingRules IRule = getRuleFactory(singleRuleDescription);
                
                temp.Add(IRule);
            }
            return temp;
        }

        public List<double> LoadWindowLastSetUp()
        {
            List<string> temp = new List<string>();
            List<double> tempFinal = new List<double>();
            XDocument doc = XDocument.Load("WindowLastSetUp.xml");

            var data = doc.Descendants("Window").Select(o => new
            {
                w_width = o.Element("Width"),
                w_height = o.Element("Height"),
                w_top = o.Element("Top"),
                w_left = o.Element("Left")
            }).ToList();

            foreach (var item in data)
            {
                temp.Add(item.w_width.ToString());
                temp.Add(item.w_height.ToString());
                temp.Add(item.w_top.ToString());
                temp.Add(item.w_left.ToString());
            }

            tempFinal.Add(double.Parse(temp[0].Substring(7, temp[0].Length - (7 + 8))));
            tempFinal.Add(double.Parse(temp[1].Substring(8, temp[1].Length - (8 + 9))));
            tempFinal.Add(double.Parse(temp[2].Substring(5, temp[2].Length - (5 + 6))));
            tempFinal.Add(double.Parse(temp[3].Substring(6, temp[3].Length - (6 + 7))));

            return tempFinal;
        }

        private IRenamingRules getRuleFactory(string _singleRuleDescription)
        {
            var Token = _singleRuleDescription.Split(new string[] { " " }, StringSplitOptions.None);
            string NameRule = Token[0] + " " + Token[1];
            int vt;
            IRenamingRules IRule = null;

            switch (NameRule)
            {
                case "Change extension":
                    vt = _singleRuleDescription.IndexOf("to");
                    string _newExtension = _singleRuleDescription.Substring(vt + 4, _singleRuleDescription.Length - (vt + 5));
                    IRule = new ChangeExtensionRule.ChangeExtensionRule() { stringchange = _newExtension };
                    break;
                case "Add counter":
                    vt = _singleRuleDescription.IndexOf("with");
                    string _format = _singleRuleDescription.Substring(vt + 5, _singleRuleDescription.Length - (vt + 5));
                    IRule = new AddCounterRule.AddCounterRule() { choice = _format };
                    break;
                case "Remove all":
                    IRule = new RemoveAllSpacesRule.RemoveAllSpacesRule();
                    break;
                default: //replacement
                    int firstSpaceIndex = _singleRuleDescription.IndexOf(" ");
                    string name = _singleRuleDescription.Substring(0, firstSpaceIndex);
                    int finding = _singleRuleDescription.IndexOf("→");
                    string _needle = _singleRuleDescription.Substring(firstSpaceIndex + 2, finding - name.Length - 4);
                    string _replacement = _singleRuleDescription.Substring(finding + 3, _singleRuleDescription.Length - (finding + 4));
                    IRule = new ReplaceRule.ReplaceRule() { Needle = _needle, Replacement = _replacement };
                    break;
                case "Add prefix":
                    vt = _singleRuleDescription.IndexOf("prefix");
                    string _prefix = _singleRuleDescription.Substring(vt + 8, _singleRuleDescription.Length - (vt + 9));
                    IRule = new AddPrefixRule.AddPrefixRule() { prefix = _prefix };
                    break;
                case "Add suffix":
                    vt = _singleRuleDescription.IndexOf("suffix");
                    string _suffix = _singleRuleDescription.Substring(vt + 8, _singleRuleDescription.Length - (vt + 9));
                    IRule = new AddSuffixRule.AddSuffixRule() { suffix = _suffix };
                    break;
                case "Lowercase all":
                    IRule = new LowercaseAllAndRemoveAllSpacesRule.LowercaseAllAndRemoveAllSpacesRule();
                    break;
                case "Convert to":
                    IRule = new PascalCaseRule.PascalCaseRule();
                    break;
            }

            return IRule;
        }
    }
}