using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.Utils
{
    /// <summary>
    /// This class holds some named stopwatches to help in tracking down precise timings for performance critical sections of code.
    /// </summary>
    public class Stopwatches
    {

        private Stopwatches()
        {
            watches = new Dictionary<string, Stopwatch>();
        }

        private static Stopwatches _watches;
        public static Stopwatches Watches
        {
            get
            {
                return _watches ?? (_watches = new Stopwatches());
            }
        }

        private Dictionary<string, Stopwatch> watches;

        private Stopwatch GetStopwatch(string name)
        {
            if (!watches.ContainsKey(name))
            {
                watches[name] = new Stopwatch();
            }

            return watches[name];
        }

        public Stopwatch this[string name]
        {
            get
            {
                return GetStopwatch(name);
            }
        }
    }
}
