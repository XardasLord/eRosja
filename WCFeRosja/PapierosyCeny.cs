using System;
using System.Collections.Generic;
using System.Linq;

namespace WCFeRosja
{
    public class PapierosyCeny
    {
        public string Przejscie { get; set; }
        public string Sklep { get; set; }
        public string Nazwa { get; set; }
        public Nullable<decimal> CenaPaczka { get; set; }
        public Nullable<decimal> CenaPakiet { get; set; }


        public override string ToString()
        {
            return Nazwa;
        }
    }
}