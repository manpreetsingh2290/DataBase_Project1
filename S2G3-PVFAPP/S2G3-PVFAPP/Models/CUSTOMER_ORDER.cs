﻿//------------------------------------------------------------------------------
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

    public partial class CUSTOMER_ORDER
    {
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual ORDER ORDER { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }

        public virtual ORDER_LINE ORDER_LINE { get; set; }

        public decimal Extended_Price;
        //public string Customer_ID;
        //public string Order_ID;
       // public string Customer_Name;
       // public string Customer_Address;

    }
}