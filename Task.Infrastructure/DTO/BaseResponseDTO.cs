
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.DataAccess.Enums;

namespace TaskProject.Infrastructure.DTO
{
    public class BaseResponseDTO
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; } = new object() { };
        public ErrorCodes ErrorCode { get; set; } = ErrorCodes.General;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
