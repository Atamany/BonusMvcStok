//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BonusMvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblSatislar
    {
        public int id { get; set; }
        public Nullable<int> urun { get; set; }
        public Nullable<int> personel { get; set; }
        public Nullable<int> musteri { get; set; }
        public Nullable<decimal> fiyat { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
    
        public virtual TblMusteri TblMusteri { get; set; }
        public virtual TblPersonel TblPersonel { get; set; }
        public virtual TblUrunler TblUrunler { get; set; }
    }
}
