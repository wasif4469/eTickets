using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }

        [Display(Name ="Profile Picture")]
        public string ProfilePictureName { get; set; }

        [Display(Name = "Full Name")]
        public string ProducerName { get; set; }

        [Display(Name = "Biogaraphy")]
        public string Bio { get; set; }

        // Relationships

        public List<Movie> Movies { get; set; }

    }
}
