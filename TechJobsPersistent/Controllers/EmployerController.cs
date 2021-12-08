using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private EmployersDbContext context;

        public EmployerController(EmployersDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            //Send all Employer objects to the view
            List<Employer> employers = context.Employer.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerVIewModel addEmployerViewModel = new AddEmployerVIewModel();
            return View(addEmployerViewModel);
        }

        public IActionResult ProcessAddEmployerForm(Employer employer)
        {
            if (ModelState.IsValid)
            {
                context.Employer.Add(employer);
                context.SaveChanges();
                return Redirect("/employer/");
            }

            return View("Add", employer);
        }

        public IActionResult About(int id)
        {
            List<Employer> employers = context.Employer
                 .Where(e => e.Id == id)
                 .Include(e => e.Name)
                 .Include(e => e.Location)
                 .ToList();

            return View(employers);
        }
    }
}
