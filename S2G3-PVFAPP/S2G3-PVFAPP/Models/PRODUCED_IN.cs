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
    
    public partial class PRODUCED_IN
    {
        public string Product_ID { get; set; }
        public string Work_Center_ID { get; set; }
        public Nullable<System.DateTime> Production_Date { get; set; }
        public decimal Product_Quantity { get; set; }
    
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual WORK_CENTER WORK_CENTER { get; set; }
    }
}
