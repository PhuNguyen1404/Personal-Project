using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IContract
{
    public interface IGUI
    {
        IBus Bus { get; set; }
        string Description { get; }

        UserControl Show();
    }
}
