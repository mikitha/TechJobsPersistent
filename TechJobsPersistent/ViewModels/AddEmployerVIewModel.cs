using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerVIewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public int Name { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public int Location { get; set; }
    }
}
