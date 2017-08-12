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
    
    public partial class tblLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblLocation()
        {
            this.tblBranches = new HashSet<tblBranch>();
            this.tblCustomerLocationBranches = new HashSet<tblCustomerLocationBranch>();
            this.tblMSPLocationBranches = new HashSet<tblMSPLocationBranch>();
            this.tblSupplierLocationBranches = new HashSet<tblSupplierLocationBranch>();
            this.tblUserLocationBranches = new HashSet<tblUserLocationBranch>();
        }
    
        public long ID { get; set; }
        public string LocationName { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBranch> tblBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomerLocationBranch> tblCustomerLocationBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMSPLocationBranch> tblMSPLocationBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSupplierLocationBranch> tblSupplierLocationBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUserLocationBranch> tblUserLocationBranches { get; set; }
    }
}
