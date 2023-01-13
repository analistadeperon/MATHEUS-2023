using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
  
namespace CRUDDemo.Controllers
{
    public class CRUDController : Controller {
        public ActionResult Delete()
        {
            return View();
        }
  
        [HttpPost]
        [ValidateAntiForgeryToken] public ActionResult
        Delete(int Studentid)
        {
            using(var context = new demoCRUDEntities())
            {
                var data = context.Student.FirstOrDefault(x = > x.StudentNo == Studentid);
                if (data != null) {
                    context.Student.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }
    }
}