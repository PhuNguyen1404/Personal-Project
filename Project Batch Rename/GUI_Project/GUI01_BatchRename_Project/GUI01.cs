using IContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI01_BatchRename_Project
{
    public class GUI01 : IGUI
    {
        public IBus Bus { get; set; }

        public string Description => "GUI01 - Batch Rename Tools";

        public UserControl Show()
        {
            return new GUI01_BatchRename(Bus);
        }
    }
}
