//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagerDAL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class LinkProjectToFolder
    {
        public string Id { get; set; }
        public string FolderId { get; set; }
        public string ProjectId { get; set; }
        public System.DateTime DateCreated { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual LinkProjectToFolder LinkProjectToFolder1 { get; set; }
        public virtual LinkProjectToFolder LinkProjectToFolder2 { get; set; }
    }
}
