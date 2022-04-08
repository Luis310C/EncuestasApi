using System;
using System.Collections.Generic;

#nullable disable

namespace EncuestasApi.Model
{
    public partial class Tipodecampo
    {
        public Tipodecampo()
        {
            Campoencuesta = new HashSet<Campoencuestum>();
        }

        public int TipoId { get; set; }
        public string NombreTipo { get; set; }

        public virtual ICollection<Campoencuestum> Campoencuesta { get; set; }
    }
}
