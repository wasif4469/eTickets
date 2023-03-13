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
        public string ProfilePictureName { get; set; }
        public string ProducerName { get; set; }
        public string Bio { get; set; }

        // Relationships

        public List<Movie> Movies { get; set; }

    }
}
