using System;
using System.Collections.Generic;

#nullable disable

namespace EncuestasApi.Model
{
    public partial class Encuestum
    {
        public Encuestum()
        {
            Campoencuesta = new HashSet<Campoencuestum>();
            Respuestaencuesta = new HashSet<Respuestaencuestum>();
        }

        public int EncuestaId { get; set; }
        public string NombreEncuesta { get; set; }
        public string Descripción { get; set; }
        public bool? Habilitada { get; set; }

        public virtual ICollection<Campoencuestum> Campoencuesta { get; set; }
        public virtual ICollection<Respuestaencuestum> Respuestaencuesta { get; set; }
    }
}
