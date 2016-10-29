using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ComponentModel.DataAnnotations;
namespace PraGroupTest.Core
{

    public class Widget
    {
        /// <summary>
        /// We can have image link property if we like - but not using it now.
        /// </summary>
        public int WidgetID { get; set; }
        public string Name { get; set; }
        public double BasePrice { get; set; }
        public bool DiscountIndicator { get; set; }
    }
}
