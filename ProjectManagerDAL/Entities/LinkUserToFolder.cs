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
    
    public partial class LinkUserToFolder
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FolderId { get; set; }
        public string DateCreated { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Folder Folder { get; set; }
    }
}
