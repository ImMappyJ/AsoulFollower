using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AsoulFollower.utils
{
    public class BeepUtil
    {
        [DllImport("Kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);
    }
}
