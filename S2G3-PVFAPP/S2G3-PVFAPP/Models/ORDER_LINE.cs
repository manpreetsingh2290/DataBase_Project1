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
    
    public partial class ORDER_LINE
    {
        public string Order_ID { get; set; }
        public string Product_ID { get; set; }
        public decimal Ordered_Quantity { get; set; }
    
        public virtual ORDER ORDER { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}