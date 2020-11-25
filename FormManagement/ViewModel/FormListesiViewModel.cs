using FormManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormManagement.ViewModel
{
    public class FormListesiViewModel
    {
        public Form form { get; set; }
        public IEnumerable<Form> forms { get; set; }
    }
}