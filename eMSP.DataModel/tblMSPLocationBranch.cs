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
    
    public partial class tblMSPLocationBranch
    {
        public long ID { get; set; }
        public long MSPID { get; set; }
        public long LocationID { get; set; }
        public Nullable<long> BranchID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
    
        public virtual tblBranch tblBranch { get; set; }
        public virtual tblLocation tblLocation { get; set; }
        public virtual tblMSPDetail tblMSPDetail { get; set; }
    }
}
