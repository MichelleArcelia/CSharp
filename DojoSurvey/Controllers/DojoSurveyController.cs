using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DojoSurvey{

    public class HomeController : Controller{

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View("Index");
        }


        [HttpPost("submit")]

        public IActionResult Submit(string name, string location, string language, string comment)
        {
            Dictionary<string, string> results = new Dictionary<string, string>()
            {
                {"Name", name},
                {"Location", location},
                {"Language", language},
                {"Comment", comment}
            };

            ViewBag.Result = results;

            foreach (KeyValuePair<string,string> entry in results)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }

            return View("Result");

        }



        //Redirect back to Index if trying to access result page through GET
        [HttpGet("result")]
        public RedirectToActionResult Redirect()
        {
            return RedirectToAction("Index");
        }
    }
}







        // [HttpPost("result")]
        // public ActionResult Result(string name, string location, string language, string textarea)
        // {
        //     ViewBag.name = name;
        //     ViewBag.location = location;
        //     ViewBag.language = language;
        //     ViewBag.textarea = textarea;

        //     return View("result");