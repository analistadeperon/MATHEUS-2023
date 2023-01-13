using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
  
namespace CRUDDemo.Controllers
{
    public class CRUDController : Controller
    {
          
        // To fill data in the form 
        // to enable easy editing
        public ActionResult Update(int Studentid) 
        {
            using(var context = new demoCRUDEntities())
            {
                var data = context.Student.Where(x => x.StudentNo == Studentid).SingleOrDefault();
                return View(data);
            }
        }
  
        // To specify that this will be 
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Update(int Studentid, Student model)
        {
            using(var context = new demoCRUDEntities())
            {
                  
                // Use of lambda expression to access
                // particular record from a database
                var data = context.Student.FirstOrDefault(x => x.StudentNo == Studentid); 
                  
                // Checking if any such record exist 
                if (data != null) 
                {
                    data.Name = model.Name;
                    data.Section = model.Section;
                    data.EmailId = model.EmailId;
                    data.Branch = model.Branch;
                    context.SaveChanges();
                      
                    // It will redirect to 
                    // the Read method
                    return RedirectToAction("Read"); 
                }
                else
                    return View();
            }
        }
    }
}