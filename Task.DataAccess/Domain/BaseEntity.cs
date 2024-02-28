using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.DataAccess.Domain
{
    public class BaseEntity
    {
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int CreatedUserId { get; set; } = 0;
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
