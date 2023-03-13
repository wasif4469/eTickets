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
        public string ActorName { get; set;}    
        public string ProfilePictureURL { get; set;}
        public string bio { get; set;}

        // Relationships

        public List<Actor_Movie> Actors_Movies { get; set;}

 
    }
}
