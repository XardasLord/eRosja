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
    
    public partial class przejscia
    {
        public przejscia()
        {
            this.alkohol_ceny = new HashSet<alkohol_ceny>();
            this.papierosy_ceny = new HashSet<papierosy_ceny>();
            this.sklepy = new HashSet<sklepy>();
            this.stacje_benzynowe = new HashSet<stacje_benzynowe>();
            this.uaktualnienia_alkohol = new HashSet<uaktualnienia_alkohol>();
            this.uaktualnienia_paliwo = new HashSet<uaktualnienia_paliwo>();
            this.uaktualnienia_papierosy = new HashSet<uaktualnienia_papierosy>();
            this.zmiany = new HashSet<zmiany>();
        }
    
        public long id_przejscia { get; set; }
        public string nazwa { get; set; }
    
        public virtual ICollection<alkohol_ceny> alkohol_ceny { get; set; }
        public virtual ICollection<papierosy_ceny> papierosy_ceny { get; set; }
        public virtual ICollection<sklepy> sklepy { get; set; }
        public virtual ICollection<stacje_benzynowe> stacje_benzynowe { get; set; }
        public virtual ICollection<uaktualnienia_alkohol> uaktualnienia_alkohol { get; set; }
        public virtual ICollection<uaktualnienia_paliwo> uaktualnienia_paliwo { get; set; }
        public virtual ICollection<uaktualnienia_papierosy> uaktualnienia_papierosy { get; set; }
        public virtual ICollection<zmiany> zmiany { get; set; }
    }
}
