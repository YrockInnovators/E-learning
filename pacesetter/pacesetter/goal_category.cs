//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pacesetter
{
    using System;
    using System.Collections.Generic;
    
    public partial class goal_category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public goal_category()
        {
            this.goal_table = new HashSet<goal_table>();
        }
    
        public int Category_id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryShortName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<goal_table> goal_table { get; set; }
    }
}
