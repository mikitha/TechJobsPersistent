using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Job name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employer Id is required")]
        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public Job Job{ get; set; }

        public List<SelectListItem> Skills { get; set; }

        //public AddJobViewModel(List<Employer> possibleEmployers, List<Skill> possibleSkills)
        //{
        //    Employers = new List<SelectListItem>();
        //    Skills = new List<SelectListItem>();

        //    foreach (var employer in possibleEmployers)
        //    {
        //        Employers.Add(new SelectListItem
        //        {
        //            Value = employer.Id.ToString(),
        //            Text = employer.Name
        //        });
        //    }
        //    foreach (var skill in possibleSkills)
        //    {
        //        Skills.Add(new SelectListItem
        //        {
        //            Text = skill.Name,
        //            Value = skill.Id.ToString()
        //        });
        //    }
           

        //}
        public AddJobViewModel()
        {
            
            
        }

    }
}
