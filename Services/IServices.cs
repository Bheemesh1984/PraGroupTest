using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraGroupTest.Core;

namespace PraGroupTest.Service.Contracts
{
    //adapter for data repository
    public interface IDataRepository
    {
         IEnumerable<Widget> GetWigdets();
         IEnumerable<State> GetStates();
    }

    //adapter for tax calculator
    public interface IPriceCalculator
    {
        double PriceWithTax(double TaxableAmount);
    }
}
