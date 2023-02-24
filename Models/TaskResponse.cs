using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class TaskResponse
    {
       
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public string DueDate { get; set; }
        [Required]
        public byte Quadrant { get; set; }
        public bool Completed { get; set; }

        //build fk relationship
        public byte CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
