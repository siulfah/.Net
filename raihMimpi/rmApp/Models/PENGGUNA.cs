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
    
    public partial class PENGGUNA
    {
        public PENGGUNA()
        {
            this.KOMENTAR = new HashSet<KOMENTAR>();
            this.PROJEK = new HashSet<PROJEK>();
            this.SPONSOR = new HashSet<SPONSOR>();
        }
    
        public int ID_PENGGUNA { get; set; }
        public Nullable<int> ID_LOGIN { get; set; }
        public string NAMA { get; set; }
        public string TELEPON { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public byte[] KTP { get; set; }
        public string BIOGRAFI { get; set; }
        public byte[] FOTO_PROFILE { get; set; }
        public byte[] VERIFIKASI { get; set; }
        public string UPDATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string CREATE_BY { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public string KETERANGAN { get; set; }
    
        public virtual ICollection<KOMENTAR> KOMENTAR { get; set; }
        public virtual PENCAIRANDANA PENCAIRANDANA { get; set; }
        public virtual ICollection<PROJEK> PROJEK { get; set; }
        public virtual ICollection<SPONSOR> SPONSOR { get; set; }
    }
}