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
    
    public partial class ZmianyEntity
    {
        public ZmianyEntity()
        {
            this.cykl_zmian = new HashSet<Cykl_zmianEntity>();
        }
    
        public int id_zmiany { get; set; }
        public int id_przejscia { get; set; }
        public string nazwa { get; set; }
    
        public virtual ICollection<Cykl_zmianEntity> cykl_zmian { get; set; }
        public virtual PrzejsciaEntity przejscia { get; set; }
    }
}