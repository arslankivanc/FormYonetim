//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Form
    {
        public int Id { get; set; }
        public string formName { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
        public Nullable<int> createdBy { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public Nullable<int> age { get; set; }
    
        public virtual User User { get; set; }
    }
}
