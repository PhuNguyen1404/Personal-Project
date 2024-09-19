using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IContract;

namespace AddPrefixRule
{
    public class AddPrefixRule : IRenamingRules
    {
        public string prefix { get; set; }

        public string Description => "Add prefix " + $"\"{prefix}\"";

        public string Name => "Prefix";

        public string Transform(string original, bool isPreview)
        {
            string FileNameAndExtensionname = Path.GetFileName(original);
            string PathBeforeFileName = original.Substring(0, original.LastIndexOf(@"\") + 1);
            string PathAndFileName = original.Substring(0, original.LastIndexOf("."));
            string extensionname = original.Substring(original.LastIndexOf("."));
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(original);

            string result = $"{PathBeforeFileName}{prefix}{FileNameAndExtensionname}";
            int i = 0;
            if (original != result)
            {
                while (File.Exists(result))
                {
                    i++;
                    result = $"{PathBeforeFileName}{prefix}{filenameWithoutExtension} ({i}){extensionname}";
                }
                if(isPreview == false)
                    File.Move(original, result);
            }
            return result;
        }
    }
}
