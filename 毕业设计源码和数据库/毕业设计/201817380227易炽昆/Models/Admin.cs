//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _201817380227易炽昆.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            this.Lease = new HashSet<Lease>();
            this.BuyHouse = new HashSet<BuyHouse>();
            this.StagesBuyHouse = new HashSet<StagesBuyHouse>();
        }
    
        public int AdminID { get; set; }
        public string AdminLogin { get; set; }
        public string AdminPwd { get; set; }
        public string AdminName { get; set; }
        public string AdminIdentity { get; set; }
        public string AdminSex { get; set; }
        public int AdminAge { get; set; }
        public string AdminPhone { get; set; }
        public string State { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lease> Lease { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuyHouse> BuyHouse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StagesBuyHouse> StagesBuyHouse { get; set; }
    }
}
