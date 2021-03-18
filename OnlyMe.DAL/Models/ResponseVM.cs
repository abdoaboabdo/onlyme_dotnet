using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.Models
{
    public class ResponseVM
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string AdditionalInfo { get; set; }
        public object Data { get; set; }
    }
}
