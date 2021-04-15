using Constants;
using DotStarkTest.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotStarkTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View(new ContactUsViewModel());
        }
        [HttpPost]
        public IActionResult Contact(ContactUsViewModel contactUsViewModel)
        {
            BusinessLogic.BusinessLogic businessLogic = new BusinessLogic.BusinessLogic();
            ContactUs contactUs = new ContactUs
            {
                Name = contactUsViewModel.Name,
                Email = contactUsViewModel.Email,
                Contact = contactUsViewModel.Contact,
                Porpose = contactUsViewModel.Porpose,
                Description = contactUsViewModel.Description
            };
            int saveResult = businessLogic.InsertContactDetail(contactUs);
            string mailMessage = businessLogic.SendMail(contactUsViewModel.Email, ConstantFields.SenderMail,contactUsViewModel.Description,contactUsViewModel.Porpose);

            ViewData["Message"] = saveResult > 0 ? "Thank You For Contacting Us":"!Sorry currently we unable to capture your request" ;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
