﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Number of Days")]
        [Range(1,25,ErrorMessage ="Please Enter a Valid NUmber")]
        public int DefaultDays { get; set; }
        [Display(Name="Creation Date")]
        public DateTime? DateCreated { get; set; }
    }


    //public class CreateLeaveTypeVM
    //{
    //    [Required]
    //    public string Name { get; set; }
    //}
}
