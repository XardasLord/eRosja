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
    
    public partial class paliwo_ceny
    {
        public long id_paliwo_ceny { get; set; }
        public long id_paliwa { get; set; }
        public long id_stacje_benzynowe { get; set; }
        public decimal cena { get; set; }
    
        public virtual paliwa paliwa { get; set; }
        public virtual stacje_benzynowe stacje_benzynowe { get; set; }
    }
}