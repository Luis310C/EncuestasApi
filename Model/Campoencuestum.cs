using System;
using System.Collections.Generic;

#nullable disable

namespace EncuestasApi.Model
{
    public partial class Campoencuestum
    {
        public Campoencuestum()
        {
            Respuesta = new HashSet<Respuesta>();
        }

        public int CampoId { get; set; }
        public string NombreCampo { get; set; }
        public string TítuloCampo { get; set; }
        public bool? Requerido { get; set; }
        public int? TipoCampo { get; set; }
        public int? Encuesta { get; set; }

        public virtual Encuestum EncuestaNavigation { get; set; }
        public virtual Tipodecampo TipoCampoNavigation { get; set; }
        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
