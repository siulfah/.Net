//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rmApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RELATIONSHIP_12
    {
        public int ID_KATEGORI { get; set; }
        public int ID_PROYEK { get; set; }
        public string CREATE_BY { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string KETERANGAN { get; set; }
    
        public virtual KATEGORI KATEGORI { get; set; }
        public virtual PROJEK PROJEK { get; set; }
    }
}
