//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S2G3_PVFAPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUPPLIES
    {
        public string Vender_ID { get; set; }
        public string Material_ID { get; set; }
        public decimal Supply_Unit_Price { get; set; }
    
        public virtual RAW_MATERIAL RAW_MATERIAL { get; set; }
        public virtual VENDER VENDER { get; set; }
    }
}
