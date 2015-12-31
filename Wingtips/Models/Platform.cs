using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gathering.Models
{
    public class Platform
    {
        [ScaffoldColumn(false)]
        public int PlatformID { get; set; }

        [Required, StringLength(100), Display(Name = "Device")]
        public string Device { get; set; }

        [Display(Name = "OS")]
        public string OS { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}