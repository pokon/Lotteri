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
        public string Name { get; set; }
        public List<Subscriber> Subscribers { get; set; }

        [Required]
        [Display(Name = "Startdatum")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [Required]
        [Display(Name = "Slutdatum")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

        public bool IsVisible { get; set; }

    }
}
