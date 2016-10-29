using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraGroupTest.Service.Contracts;

namespace PraGroupTest.Services
{
    public class ILPriceCalculator : IPriceCalculator
    {

        public double PriceWithTax(double TaxableAmount)
        {
            // do tax calculation process as needed for the state 
            // may be fetch tax % from config if we want to
            return TaxableAmount + TaxableAmount * 0.05; 
        }
    }

    public class TXPriceCalculator : IPriceCalculator
    {

        public double PriceWithTax(double TaxableAmount)
        {
            // do tax calculation process as needed for the state 
            // may be fetch tax % from config if we want to
            return TaxableAmount + TaxableAmount * 0; 
        }
    }

    public class INPriceCalculator : IPriceCalculator
    {

        public double PriceWithTax(double TaxableAmount)
        {
            // do tax calculation process as needed for the state 
            // may be fetch tax % from config if we want to
            return TaxableAmount + TaxableAmount * 0.07; 
        }
    }

    public class FLPriceCalculator : IPriceCalculator
    {

        public double PriceWithTax(double TaxableAmount)
        {
            // do tax calculation process as needed for the state 
            // may be fetch tax % from config if we want to
            return TaxableAmount + TaxableAmount * 0; 
        }
    }

    public class OHPriceCalculator : IPriceCalculator
    {

        public double PriceWithTax(double TaxableAmount)
        {
            // do tax calculation process as needed for the state 
            // may be fetch tax % from config if we want to
            // lets say 7% is tax in OH 
            return TaxableAmount + TaxableAmount * 0.05;
        }
    }
}
