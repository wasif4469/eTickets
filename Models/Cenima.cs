using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Cenima
    {
        [Key]
        public int CenimaID { get; set; }

        [Display(Name = "Cenima Logo")]
        public string CenimaLogo { get; set; }

        [Display(Name = "Cenima Name")]
        public string CenimaName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        //Relationships

        public List<Movie> Movies { get; set; } 


    
    }
}
