using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependenyInjectionDemo.Services
{
    public class SiteVisitorsCounter : ISiteVisitorsCounter
    {
        public int Counter { get; set; }

        public int GetCounter()
        {
            Counter++;
            return Counter;
        }
    }
}
