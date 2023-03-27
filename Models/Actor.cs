using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int ActorId {get; set;}

        [Display(Name = "Actor Name")]
        public string ActorName { get; set;}

        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set;}

        [Display(Name = "Biography")]
        public string bio { get; set;}

        // Relationships

        public List<Actor_Movie> Actors_Movies { get; set;}

 
    }
}
