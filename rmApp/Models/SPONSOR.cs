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
    
    public partial class SPONSOR
    {
        public int ID_SPONSOR { get; set; }
        public Nullable<int> ID_PROYEK { get; set; }
        public int ID_PENGGUNA { get; set; }
        public Nullable<decimal> JUMLAH_SPONSOR { get; set; }
        public Nullable<int> ID_BANK { get; set; }
        public string CREATE_BY { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<bool> ANONIM { get; set; }
        public string KETERANGAN { get; set; }
        public Nullable<bool> STATUS { get; set; }
    
        public virtual PENGGUNA PENGGUNA { get; set; }
        public virtual PROJEK PROJEK { get; set; }
    }
}
