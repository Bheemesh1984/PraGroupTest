using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraGroupTest.Core
{
    public class State
    {
        public string Country { get; set; }

        public string StateName { get; set; }

        public int StateID { get; set; }

        //The dll that calculates tax for this state can be set to come from XML
        public string TaxCalculatordll { get; set; }
    }
}
