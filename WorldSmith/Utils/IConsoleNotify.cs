using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.Utils
{
    delegate void UpdateConsoleDelegate(String text);

    interface IConsoleNotify
    {
        void UpdateConsole(string text);

    }
}
