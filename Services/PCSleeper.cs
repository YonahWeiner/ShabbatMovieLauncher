using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShabbatMovieLauncher.Services
{
    public class PCSleeper
    {
        // Source - https://stackoverflow.com/a
        // Posted by fre0n, modified by community. See post 'Timeline' for change history
        // Retrieved 2025-11-23, License - CC BY-SA 3.0

        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public void Hibernate()
        {
            // Hibernate
            SetSuspendState(true, true, false);
        }

        public void Standby()
        {
            // Standby
            SetSuspendState(false, true, false);
        }

    }
}
