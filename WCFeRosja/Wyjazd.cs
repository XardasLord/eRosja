using System;
using System.Collections.Generic;
using System.Linq;

namespace WCFeRosja
{
    public class Wyjazd
    {
        public string LoginUzytkownika { get; set; }
        public string Przejscie { get; set; }
        public Paliwo Paliwo { get; set; }
        public Papierosy Papierosy { get; set; }
        public Alkohol Alkohol { get; set; }
        public DateTime Data { get; set; }
        public bool Kanal { get; set; }
        public bool Mandat { get; set; }

    }
}