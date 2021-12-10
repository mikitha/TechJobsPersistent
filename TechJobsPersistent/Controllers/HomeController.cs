using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext jobContext;
        

        public HomeController(JobDbContext jContext)
        {
            jobContext = jContext;
           
        }

        public IActionResult Index()
        {
            List<Job> jobs = jobContext.Jobs.Include(e => e.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Employer> possibleEmployers = jobContext.Employers.ToList();
            List<Skill> possibleSkills = jobContext.Skills.ToList();
            AddJobViewModel addJobViewModel = new AddJobViewModel(possibleEmployers, possibleSkills);
            
            return View(addJobViewModel);
        }

        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {
                Employer employer = jobContext.Employers.Find(addJobViewModel.EmployerId);
                Job newJob = new Job {Name = addJobViewModel.Name, EmployerId = addJobViewModel.EmployerId, Employer = employer};

                jobContext.Jobs.Add(newJob);
                jobContext.SaveChanges();
                foreach (var skill in selectedSkills)
                {
                    
                    JobSkill jobSkill = new JobSkill();
                    jobSkill.JobId = newJob.Id;
                    jobSkill.SkillId = Int32.Parse(skill);

                    
                    jobContext.JobSkills.Add(jobSkill);
                   

                }
                
                jobContext.SaveChanges();

                return Redirect("Index");
            }

            return View("Add", addJobViewModel);
            
        }

        public IActionResult Detail(int id)
        {
            Job theJob = jobContext.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = jobContext.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
