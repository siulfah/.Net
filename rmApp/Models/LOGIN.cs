//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rmApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOGIN
    {
        public int ID_LOGIN { get; set; }
        public int ID_PERAN { get; set; }
        public string USERNAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public string CREATE_BY { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string KETERANGAN { get; set; }
        public Nullable<bool> EMAIL_CONFIRMED { get; set; }
        public Nullable<System.DateTime> LAST_LOGIN { get; set; }
    
        public virtual PERAN PERAN { get; set; }
    }
}