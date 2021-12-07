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
        private EmployerDbContext context;

        public EmployerController(EmployerDbContext dbContext)
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
            return View();
        }

        public IActionResult ProcessAddEmployerForm()
        {
            return View();
        }

        public IActionResult About(int id)
        {
            return View();
        }
    }
}
