using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraGroupTest.Service.Contracts;
using PraGroupTest.Core;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace PraGroupTest.Services
{
    public class XMLDataRepository : IDataRepository
    {

        /// <summary>
        /// Return list of Widgets
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Widget> GetWigdets()
        {
            List<Widget> widgets = new List<Widget>();

            var doc = XDocument.Load(@"C:\PraGroupTest\XMLData\Widgets.xml"); //Or get the path from config file for adoptablity
            var nodes = doc.Descendants("Widgets").Descendants("Widget").ToList();

            foreach (var node in nodes)
            {
                int widgetId;
                double baseprice;
                bool discount;
                Int32.TryParse(node.Element("WidgetID").Value, out widgetId);
                double.TryParse(node.Element("BasePrice").Value, out baseprice);
                bool.TryParse(node.Element("DiscountIndicator").Value, out discount);
                widgets.Add(new Widget()
                 {
                     Name = node.Element("Name").Value,
                     BasePrice = baseprice,
                     DiscountIndicator = discount,
                     WidgetID = widgetId
                 });

            }
            return (IEnumerable<Widget>)widgets;
        }

        /// <summary>
        /// Return list of states
        /// </summary>
        /// <returns></returns>
        public IEnumerable<State> GetStates()
        {
            List<State> states = new List<State>();
            var doc = XDocument.Load(@"C:\PraGroupTest\XMLData\States.xml"); //Or get the path from config file for adoptablity
            var nodes = doc.Descendants("States").Descendants("State").ToList();

            foreach (var node in nodes)
            {
                int StateId;

                Int32.TryParse(node.Element("StateID").Value, out StateId);

                states.Add(new State()
                {
                    StateID = StateId,
                    StateName = node.Element("StateName").Value,
                    Country = node.Element("Country").Value,
                    TaxCalculatordll=node.Element("TaxCalculatordll").Value
                });
            }


            return (IEnumerable<State>)states;
        }
    }

    public class SQLDataRepository : IDataRepository
    {

        public IEnumerable<Widget> GetWigdets()
        {
            //Create a SQL connection
            //Get data from SQL database
            //Return them as widgets
            List<Widget> wid = new List<Widget>();
            return wid;
        }


        public IEnumerable<State> GetStates()
        {
            throw new NotImplementedException();
        }
    }

    public class TeraDataRepository : IDataRepository
    {

        public IEnumerable<Widget> GetWigdets()
        {
            //Create a Tera data connection
            //Get data from tera database
            //Return them as widgets
            List<Widget> wid = new List<Widget>();
            return wid;
        }


        public IEnumerable<State> GetStates()
        {
            throw new NotImplementedException();
        }
    }

}
