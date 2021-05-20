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
    
    public partial class State
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public State()
        {
            this.Deal = new HashSet<Deal>();
        }
    
        public int Id { get; set; }
        public int IdTypeState { get; set; }
        public int IdAddress { get; set; }
        public int IdOwner { get; set; }
        public string CadastralNumber { get; set; }
        public int Floor { get; set; }
        public int TotalArea { get; set; }
        public int IdRenovation { get; set; }
        public int IdRoom { get; set; }
    
        public virtual Adress Adress { get; set; }
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deal { get; set; }
        public virtual Renovation Renovation { get; set; }
        public virtual Room Room { get; set; }
        public virtual TypeState TypeState { get; set; }
    }
}