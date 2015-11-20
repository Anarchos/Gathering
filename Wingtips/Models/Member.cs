using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Wingtips.Models
{
    public class Member
    {
        [ScaffoldColumn(false)]
        public string User_Name { get; set; }       //Primary key. (Make sure you get the data type right!!!)

        [Required, StringLength(100), Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required, StringLength(100), Display(Name = "Last Name")]      //Try to include appropriate string lengths where possible (it saves RAMs!)
        public string Last_Name { get; set; }

        [Required, Display(Name = "DoB Day")]     //['Required,' I hope I don't need to explain what it does, but make sure to include them everywhere they're needed to prevent the rapture etc. 
        public int DoB_Day { get; set; }

        [Required, Display(Name = "DoB Month")]
        public int DoB_Month { get; set; }

        [Required, Display(Name = "DoB Year")]
        public int DoB_Year { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        public int? PlatformID { get; set; }        //Foriegn keys are the best type of keys.

        public virtual Platform Platform { get; set; }  //If a class inherits from this one (or any other), it needs this line to stop the metaphorical shit hitting the metaphorical fan.
    }
}