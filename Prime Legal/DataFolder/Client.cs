//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prime_Legal.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.Deal = new HashSet<Deal>();
            this.State = new HashSet<State>();
        }
    
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public Nullable<long> INN { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IdPassport { get; set; }
        public string SNILS { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> IdTypeClient { get; set; }
        public Nullable<int> IdCompany { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual TypeClient TypeClient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<State> State { get; set; }
    }
}
