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
    
    public partial class SklepyEntity
    {
        public SklepyEntity()
        {
            this.alkohol_ceny = new HashSet<Alkohole_cenyEntity>();
            this.papierosy_ceny = new HashSet<Papierosy_cenyEntity>();
            this.wyjazdy = new HashSet<WyjazdyEntity>();
            this.wyjazdy1 = new HashSet<WyjazdyEntity>();
        }
    
        public int id_sklepy { get; set; }
        public int id_przejscia { get; set; }
        public string nazwa { get; set; }
    
        public virtual ICollection<Alkohole_cenyEntity> alkohol_ceny { get; set; }
        public virtual ICollection<Papierosy_cenyEntity> papierosy_ceny { get; set; }
        public virtual PrzejsciaEntity przejscia { get; set; }
        public virtual ICollection<WyjazdyEntity> wyjazdy { get; set; }
        public virtual ICollection<WyjazdyEntity> wyjazdy1 { get; set; }
    }
}