using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IContract;

namespace LowercaseAllAndRemoveAllSpacesRule
{
    public class LowercaseAllAndRemoveAllSpacesRule : IRenamingRules
    {
        public string Description => "Lowercase all characters and remove all spaces";

        public string Name => "Lowercase all and no spaces";

        public string Transform(string original, bool isPreview)
        {
            string FileNameAndExtensionname = Path.GetFileName(original);
            string PathBeforeFileName = original.Substring(0, original.LastIndexOf(@"\") + 1);
            string PathAndFileName = original.Substring(0, original.LastIndexOf("."));
            string extensionname = original.Substring(original.LastIndexOf("."));
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(original);


            string temp = filenameWithoutExtension.ToLower();
            string resultt = string.Concat(temp.Where(c => !Char.IsWhiteSpace(c)));
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
