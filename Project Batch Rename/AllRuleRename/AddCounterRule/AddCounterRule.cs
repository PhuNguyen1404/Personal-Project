using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IContract;

namespace AddCounterRule
{
    public class AddCounterRule : IRenamingRules
    {
        public string choice { get; set; }

        public string Description => "Add counter with " + choice;

        public string Name => "Counter";

        private string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        public string Transform(string original, bool isPreview)
        {
            string _choice = choice;
            string FileNameAndExtensionname = Path.GetFileName(original);
            string PathBeforeFileName = original.Substring(0, original.LastIndexOf(@"\") + 1);
            string PathAndFileName = original.Substring(0, original.LastIndexOf("."));
            string extensionname = original.Substring(original.LastIndexOf("."));
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(original);
            int counter = filenameWithoutExtension.Length;
            string result = "";

            switch (_choice)
            {
                //normal number
                case "Formal format":
                    if (counter < 10)
                    {
                        result = $"{PathBeforeFileName}{filenameWithoutExtension}0{counter}{extensionname}";
                    }
                    else
                        result = $"{PathBeforeFileName}{filenameWithoutExtension}{counter}{extensionname}";
                    break;
                //roman number
                case "Roman format":
                    result = $"{PathBeforeFileName}{filenameWithoutExtension}{ToRoman(counter)}{extensionname}";
                    break;
            }
            int i = 0;
            if (original != result)
            {
                while (File.Exists(result))
                {
                    i++;
                    if (_choice == "Formal format")
                    {
                        if (counter < 10)
                        {
                            result = $"{PathBeforeFileName}{filenameWithoutExtension}0{counter} ({i}){extensionname}";
                        }
                    }
                    else if (_choice == "Roman format")
                    {
                        result = $"{PathBeforeFileName}{filenameWithoutExtension}{ToRoman(counter)} ({i}){extensionname}";
                    }

                }
                if(isPreview == false)
                    File.Move(original, result);
            }
            return result;
        }
    }
}
