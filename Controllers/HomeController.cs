using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Controllers
{
    public class HomeController : Controller
    {
        private TasksContext theContext { get; set; }
       
        //Constructor
        public HomeController(TasksContext taskName)
        {
            theContext = taskName;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get and post views for adding something to the database; where a user can submit things

        [HttpGet]
        public IActionResult AddView()
        {
            ViewBag.Categories = theContext.Categories.ToList();

            return View("AddView");
        }

        [HttpPost]
        public IActionResult AddView(TaskResponse tr)
        {
            //this first if statement is for when all the correct fields are filled out
            if (ModelState.IsValid)
            {
                theContext.Add(tr);
                theContext.SaveChanges();
                return View("Confirmation", tr);
            }
            else
            {
                //if all different forms are not filled in, it returns this view and shoots out the error messages associated with each required field
                ViewBag.Categories = theContext.Categories.ToList();

                return View();
            }
        }


        //View that allows us to see the view that shows the Quadrant table
        [HttpGet]
        public IActionResult QuadrantView()
        {
            var application = theContext.Responses.ToList();

            return View(application);
        }
        
        //Action for editing something that is in the table
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = theContext.Categories.ToList();

            //Creating an object of application response type
            var application = theContext.Responses.Single(x => x.TaskId == taskid);

            return View("AddView", application);
        }
        [HttpPost]
        public IActionResult Edit(TaskResponse tare)
        {
            theContext.Update(tare);
            theContext.SaveChanges();

            return RedirectToAction("QuadrantView");
        }

        //Creating actions that can delete records through a get and post
        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var application = theContext.Responses.Single(x => x.TaskId == taskid);

            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(TaskResponse taskr)
        {
            theContext.Responses.Remove(taskr);
            theContext.SaveChanges();

            return RedirectToAction("QuadrantView");
        }
    }
}
