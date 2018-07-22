using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResistanceCalc.Models
{
    public class ResponseModelBase
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
}