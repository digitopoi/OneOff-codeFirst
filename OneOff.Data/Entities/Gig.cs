using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOff.Data.Entities
{
    public class Gig
    {
        [Key]
        public int GigId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public bool IsRequest { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string PostalCode { get; set; }

    }
}
