using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
  
namespace CRUDDemo.Controllers
{
    public class CRUDController : Controller {
        [HttpGet] // Set the attribute to Read
            public ActionResult
            Read()
        {
            using(var context = new demoCRUDEntities())
            {
                  
                // Return the list of data from the database
                var data = context.Student.ToList(); 
                return View(data);
            }
        }
    }
}