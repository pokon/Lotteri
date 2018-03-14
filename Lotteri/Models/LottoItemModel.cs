using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lotteri.Models
{
    public class LottoItemModel
    {
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Anmälda")]
        public List<Subscriber> Subscribers { get; set; }

        // public List<String> Subs { get; set; }
        [Display(Name = "Vinnare")]
        public String Winner { get; set; }
        
        [Required]
        [Display(Name = "Startdatum")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [Required]
        [Display(Name = "Slutdatum")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

        [Display(Name = "Visas i anmälan")]
        public bool IsVisible { get; set; }

        [Display(Name = "Vinnare dragen")]
        public bool IsLottad { get; set;}
        
    }
}
