using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IContract;

namespace ReplaceRule
{
    public class ReplaceRule : IRenamingRules
    {
        public string Needle { get; set; } // Needles, Haystack
        public string Replacement { get; set; }

        public string Description => "Replace " + $"\"{Needle}\"" + " → " + $"\"{Replacement}\"";

        public string Name => "Replacement";

        public string Transform(string original, bool isPreview)
        {
            string FileNameAndExtensionname = Path.GetFileName(original);
            string PathBeforeFileName = original.Substring(0, original.LastIndexOf(@"\") + 1);
            string PathAndFileName = original.Substring(0, original.LastIndexOf("."));
            string extensionname = original.Substring(original.LastIndexOf("."));
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(original);

            string resultt = filenameWithoutExtension;
            resultt = resultt.Replace(Needle, Replacement);

            string result = $"{PathBeforeFileName}{resultt}{extensionname}";
            int i = 0;
            if (original != result)
            {
                while (File.Exists(result))
                {
                    i++;
                    result = $"{PathBeforeFileName}{resultt} ({i}){extensionname}";
                }
                if(isPreview == false)
                    File.Move(original, result);
            }
            return result;
        }
    }
}
