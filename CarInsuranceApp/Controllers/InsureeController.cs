using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarInsuranceApp.Models; // Ensure this matches your project name

namespace CarInsuranceApp.Controllers
{
    // The class MUST be outside of any methods and directly inside the namespace
    public class InsureeController : Controller
    {
        // This is where you define your database context
        // private readonly YourDbContext _db; 

        // 1. The Index Method (List of users)
        public IActionResult Index()
        {
            return View();
        }

        // 2. The Create Method (GET - shows the form)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 3. THE CALCULATION LOGIC (POST - handles the form submission)
        [HttpPost]
        public IActionResult Create(Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                decimal monthlyQuote = 50; // Base

                // Age Logic
                int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
                if (age <= 18) monthlyQuote += 100;
                else if (age >= 19 && age <= 25) monthlyQuote += 50;
                else monthlyQuote += 25;

                // Car Year Logic
                if (insuree.CarYear < 2000) monthlyQuote += 25;
                if (insuree.CarYear > 2015) monthlyQuote += 25;

                // Car Make & Model Logic
                if (insuree.CarMake.ToLower() == "porsche")
                {
                    monthlyQuote += 25;
                    if (insuree.CarModel.ToLower() == "911 carrera") monthlyQuote += 25;
                }

                // Speeding Tickets
                monthlyQuote += (insuree.SpeedingTickets * 10);

                // DUI Logic
                if (insuree.Dui) monthlyQuote *= 1.25m;

                // Coverage Logic
                if (insuree.CoverageType) monthlyQuote *= 1.50m;

                insuree.Quote = monthlyQuote;

                // _db.Insurees.Add(insuree);
                // _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // 4. The Admin Method (Requirement #3)
        public IActionResult Admin()
        {
            // return View(_db.Insurees.ToList());
            return View();
        }
    }
}