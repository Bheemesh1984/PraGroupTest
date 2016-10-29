using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PraGroupTest.Service.Contracts;
using PraGroupTest.Core;
namespace PraGroupUI.Controllers
{
    public class WidgetController : Controller
    {
        //
        // GET: /Widget/
        private List<Widget> widgets;
        private List<State> states;
        IProcessorLocator _processLocator;
        public WidgetController(IProcessorLocator processorLocator)
        {
            _processLocator = processorLocator;
            //widgets = dataRepository.GetWigdets().ToList();
            //states = dataRepository.GetStates().ToList();

        }
        public ActionResult Index()
        {
            IDataRepository dataRepository = _processLocator.GetProcessor<IDataRepository>();
            widgets = dataRepository.GetWigdets().ToList();
            return View(widgets);
        }

        //
        // GET: /Widget/Details/5

        public ActionResult Details(int id)
        {
            IDataRepository dataRepository = _processLocator.GetProcessor<IDataRepository>();
            widgets = dataRepository.GetWigdets().ToList();
            var widget = widgets.Single<Widget>(a => a.WidgetID == id);
            states = dataRepository.GetStates().ToList();
            ViewBag.States = new SelectList(states, "TaxCalculatordll", "StateName");
            ViewBag.Quantity = "0";
            return View(widget);
        }

        

        public string TotalPrice(string basePrice, string discountIndicator, string stateTax, string quantity)
        {
            double _basePrice;
            int _quantity;
            bool _discountIndicator;
            double _taxableAmount;
            
            //if state is not selected - request for selection
            if(string.IsNullOrWhiteSpace(stateTax))
                return "<B>Please select state<B>";

            double.TryParse(basePrice,out _basePrice);
            Int32.TryParse(quantity,out _quantity);
            bool.TryParse(discountIndicator,out _discountIndicator);
            _taxableAmount =_quantity * _basePrice;
            if(_discountIndicator)
                _taxableAmount = _taxableAmount - (_taxableAmount* 0.1);

            IPriceCalculator priceCalculator = _processLocator.GetProcessor<IPriceCalculator>(stateTax);

            return "Your Total Price will be : " + "<b> $" + priceCalculator.PriceWithTax(_taxableAmount).ToString() +"<b>";
        }

        //
        // POST: /Widget/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Widget/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Widget/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Widget/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Widget/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
