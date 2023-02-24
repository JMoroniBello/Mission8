using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models
{
    //Building out the separate category table
    public class Category
    {
        [Key]
        [Required]
        public byte CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
