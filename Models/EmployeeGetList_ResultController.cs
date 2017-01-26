using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NCCTestProject.Models
{
    public class EmployeeController : Controller
    {
        private northwndEntities1 db = new northwndEntities1();

        // GET: EmployeeGetList_Result
        public ActionResult Index(bool? active)
        {
            var results = db.EmployeeGetList(active).Select(x => new EmployeeModel { EmployeeID = x.EmployeeID, FirstName = x.FirstName, LastName = x.LastName, Gift = "", HireDate = x.HireDate   }).ToList();
            foreach(var result in results)
            {
                DateTime currentDate = DateTime.Now;
                System.TimeSpan difference = currentDate.Subtract(result.HireDate.Value);
                int differenceInDays = difference.Days;
                if (differenceInDays >= 5475)
                {
                    result.Gift = "30 day paid vacation";
                    
                }
                else if(differenceInDays>=3650)
                {
                    result.Gift = "watch";
                }
                else if(differenceInDays>=1825)
                {
                    result.Gift = "Tiffany pyramid";
                }
                else
                {
                    result.Gift = "Employee is not yet eligible.";
                }
                

            }
            //return View(results);
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
