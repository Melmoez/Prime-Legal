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
    
    public partial class Staff
    {
        public int Id { get; set; }
        public string MName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IdPassport { get; set; }
        public System.DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
        public int IdPosition { get; set; }
        public int IdUser { get; set; }
    
        public virtual User User { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual Position Position { get; set; }
    }
}