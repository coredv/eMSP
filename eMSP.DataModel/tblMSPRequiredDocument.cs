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
    
    public partial class tblMSPRequiredDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMSPRequiredDocument()
        {
            this.tblVacanciesRequiredDocuments = new HashSet<tblVacanciesRequiredDocument>();
        }
    
        public long ID { get; set; }
        public string RequiredDocumentName { get; set; }
        public string RequiredDocumentDescription { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<bool> IsMandatory { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVacanciesRequiredDocument> tblVacanciesRequiredDocuments { get; set; }
    }
}
