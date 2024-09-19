using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IContract;

namespace RemoveAllSpacesRule
{
    public class RemoveAllSpacesRule : IRenamingRules
    {
        public string Description => "Remove all spaces";

        public string Name => "Remove all spaces";

        public string Transform(string original, bool isPreview)
        {
            string FileNameAndExtensionname = Path.GetFileName(original);
            string PathBeforeFileName = original.Substring(0, original.LastIndexOf(@"\") + 1);
            string PathAndFileName = original.Substring(0, original.LastIndexOf("."));
            string extensionname = original.Substring(original.LastIndexOf("."));
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(original);


            string result01 = string.Concat(filenameWithoutExtension.Where(c => !Char.IsWhiteSpace(c)));
            string result = $"{PathBeforeFileName}{result01}{extensionname}";
            int i = 0;
            if (original != result)
            {
                while (File.Exists(result))
                {
                    i++;
                    result = $"{PathBeforeFileName}{result01} ({i}){extensionname}";
                }
                if(isPreview == false)
                    File.Move(original, result);
            }
            return result;
        }
    }
}
