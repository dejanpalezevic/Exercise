using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Synergetic.Exercise.Models.Company
{
    public class CompanyModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }
    }
}