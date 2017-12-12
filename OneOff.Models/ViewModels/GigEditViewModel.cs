using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOff.Models.ViewModels
{
    public class GigEditViewModel
    {
        public int GigId { get; set; }
        public DateTime Date { get; set; }
        public string PostalCode { get; set; }
    }
}
