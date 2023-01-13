using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
  
namespace CRUDDemo.Controllers
{
    public class CRUDController : Controller
    {
        // To create View of this Action result
        public ActionResult create() 
        {
            return View();
        }
  
        // Specify the type of attribute i.e.
        // it will add the record to the database
        [HttpPost] 
        public ActionResult create(Student model)
        {
              
            // To open a connection to the database
            using(var context = new demoCRUDEntities()) 
            {
                // Add data to the particular table
                context.Student.Add(model); 
                  
                // save the changes
                context.SaveChanges(); 
            }
            string message = "Created the record successfully";
              
            // To display the message on the screen
            // after the record is created successfully
            ViewBag.Message = message;     
              
            // write @Viewbag.Message in the created
            // view at the place where you want to
            // display the message
            return View(); 
        }
    }
}