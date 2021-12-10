﻿using System;
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
        private JobDbContext context;

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            //Send all Employer objects to the view
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer employer = new Employer { Name = addEmployerViewModel.Name, Location = addEmployerViewModel.Location };
                context.Employers.Add(employer);
                context.SaveChanges();
                return Redirect("/employer/");
            }

            return View("Add");
        }

        public IActionResult About(int id)
        {
            List<Employer> employers = context.Employers
                 .Where(e => e.Id == id)
                 .Include(e => e.Name)
                 .Include(e => e.Location)
                 .ToList();

            return View(employers);
        }
    }
}
