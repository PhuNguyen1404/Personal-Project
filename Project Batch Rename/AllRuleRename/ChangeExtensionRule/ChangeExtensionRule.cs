using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IContract;

namespace ChangeExtensionRule
{
    public class ChangeExtensionRule : IRenamingRules
    {
        public string stringchange { get; set; }

        public string Description => $"Change extension to \"{stringchange}\"";

        public string Name => "Change Extension";

        public string Transform(string original, bool isPreview)
        {
            var result = Path.ChangeExtension(original, stringchange);
            int i = 0;

            if(original != result)
            {
                while (File.Exists(result))
                {
                    i++;
                    result = Path.GetDirectoryName(result) + "\\"
                            + Path.GetFileNameWithoutExtension(result)
                            + $" ({i}).{stringchange}";
                }
                if(isPreview == false)
                    File.Move(original, result);
            }

            return result.ToString();
        }
    }
}
