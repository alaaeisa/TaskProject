using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Infrastructure.DTO.Contact
{
    public class ContactVM
    {
        public int Id { get; set; }
      
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
