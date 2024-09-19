using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IContract
{
    public interface IRenamingRules
    {
        string Name { get; }
        string Description { get; }
        string Transform(string original, bool isPreview);
    }
}
