using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolityczneSpektrum.Models
{
    public enum Answer
    {
        [Display(Name = "Nie wiem")]
        None,
        [Required,Display(Name = "Zupelnie sie nie zgadzam")]
        SDisagree,
        [Required,Display(Name = "Nie zgadzam sie")]
        Disagree,
        [Required,Display(Name = "Zgadzam sie")]
        Agree,
        [Required,Display(Name = "Calkowicie sie zgadzam")]
        SAgree
    }
}
