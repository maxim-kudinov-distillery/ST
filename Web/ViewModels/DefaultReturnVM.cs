using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class DefaultReturnVM
    {
        public string Message { get; set; }
        public string RedirectUrl { get; set; }
        public string ValidationError { get; set; }
        public int NewCreatedId { get; set; }
    }
}