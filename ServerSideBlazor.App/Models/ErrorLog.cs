using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazor.App.Models
{
    public class ErrorLog
    {
        public string ExceptionMessage { get; set; }
        public string Host { get; set; }
        public int SeverityId { get; set; }
    }
}
