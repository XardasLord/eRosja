//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFeRosja
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paliwo_cenyEntity
    {
        public int id_paliwo_ceny { get; set; }
        public int id_paliwa { get; set; }
        public int id_stacje_benzynowe { get; set; }
        public decimal cena { get; set; }
    
        public virtual PaliwaEntity paliwa { get; set; }
        public virtual Stacje_benzynoweEntity stacje_benzynowe { get; set; }
    }
}
