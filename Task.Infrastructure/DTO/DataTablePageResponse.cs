using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Infrastructure.DTO
{
    public class DataTablePageResponse<T>
    {
        public string Draw { get; set; } = string.Empty;
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public bool Result { get; set; }
    }
}
