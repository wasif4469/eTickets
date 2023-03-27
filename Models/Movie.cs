using eTickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Display(Name ="Movie Name")]
        public string MovieName { get; set;  }
        public string Description { get; set; }

        [Display(Name ="Movie Poster")]
        public string ImageURL { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Genre MovieCategory { get; set; }

        // Relationships
        
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Cenima

        public int CenimaID { get; set;}

        [ForeignKey("CenimaID")]
        public Cenima Cenima { get; set; }

        //Producer

        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
