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
    
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            this.ORDER_LINE = new HashSet<ORDER_LINE>();
        }
    
        public string Order_ID { get; set; }
        public System.DateTime Order_Date { get; set; }
        public string Customer_ID { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_LINE> ORDER_LINE { get; set; }
    }
}