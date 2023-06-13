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
        public int ActorId { get; set; }

        [Required(ErrorMessage = "Profile Picture Required")]
        public string? ProfilePictureURL { get; set; }

        [Required(ErrorMessage = "Actor Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 Characters")]
        public string? ActorName { get; set; }

        [Required(ErrorMessage = "Biography is required")]
        public string? bio { get; set; }

        // Relationships

        public List<Actor_Movie>? Actors_Movies { get; set; }


    }
}
