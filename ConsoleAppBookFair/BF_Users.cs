//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleAppBookFair
{
    using System;
    using System.Collections.Generic;
    
    public partial class BF_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BF_Users()
        {
            this.Books = new HashSet<BF_Books>();
        }
    
        public System.Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsMale { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public bool HasReadTermsConditions { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BF_Books> Books { get; set; }
    }
}
