//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eRosja
{
    using System;
    using System.Collections.Generic;
    
    public partial class papierosy_ceny
    {
        public long id_papierosy_ceny { get; set; }
        public long id_papierosy { get; set; }
        public long id_przejscia { get; set; }
        public long id_sklepy { get; set; }
        public Nullable<decimal> cena_paczka { get; set; }
        public Nullable<decimal> cena_pakiet { get; set; }
    
        public virtual papierosy papierosy { get; set; }
        public virtual sklepy sklepy { get; set; }
        public virtual przejscia przejscia { get; set; }
    }
}
