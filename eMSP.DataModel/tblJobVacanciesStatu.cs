//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eMSP.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblJobVacanciesStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblJobVacanciesStatu()
        {
            this.tblVacancies = new HashSet<tblVacancy>();
        }
    
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVacancy> tblVacancies { get; set; }
    }
}
