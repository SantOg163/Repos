//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sanatorium.Properties
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Medicine { get; set; }
        public System.DateTime VisitDate { get; set; }
        public System.DateTime DischargeDate { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
    }
}