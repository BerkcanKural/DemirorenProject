﻿using System.ComponentModel.DataAnnotations;

namespace DemirorenProject.API.Models
{
    public class CategoriesForCreation
    {
        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; }
    }
}
