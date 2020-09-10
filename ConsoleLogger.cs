using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIWebApplication
{
    public class ConsoleLogger : ILog
    {
        public void Info(string str)
        {
            // This can be seen in the output window / tab, set "Show output from"  to "DIWebApplicaiton...." (the drop down changes automatically)
            Console.WriteLine("***************************** {0} *****************************", str);
        }
    }
}
