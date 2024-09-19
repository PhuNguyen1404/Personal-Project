using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IContract;

namespace AddSuffixRule
{
    public class AddSuffixRule : IRenamingRules
    {
        public string suffix { get; set; }

        public string Description => "Add suffix " + $"\"{suffix}\"";

        public string Name => "Suffix";

        public string Transform(string original, bool isPreview)
        {
            string FileNameAndExtensionname = Path.GetFileName(original);
            string PathBeforeFileName = original.Substring(0, original.LastIndexOf(@"\") + 1);
            string PathAndFileName = original.Substring(0, original.LastIndexOf("."));
            string extensionname = original.Substring(original.LastIndexOf("."));
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(original);

            string result = $"{PathBeforeFileName}{filenameWithoutExtension}{suffix}{extensionname}";

            int i = 0;
            if (original != result)
            {
                while (File.Exists(result))
                {
                    i++;
                    result = $"{PathBeforeFileName}{filenameWithoutExtension}{suffix} ({i}){extensionname}";
                }
                if(isPreview == false)
                    File.Move(original, result);
            }
            return result;
        }
    }
}
