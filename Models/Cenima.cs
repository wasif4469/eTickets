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
        public string CenimaLogo { get; set; }  
        public string CenimaName { get; set; }
        public string Description { get; set; }

        //Relationships

        public List<Movie> Movies { get; set; } 


    
    }
}
