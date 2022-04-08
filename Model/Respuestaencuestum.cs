using System;
using System.Collections.Generic;

#nullable disable

namespace EncuestasApi.Model
{
    public partial class Respuestaencuestum
    {
        public Respuestaencuestum()
        {
            Respuesta = new HashSet<Respuesta>();
        }

        public int RespuestaId { get; set; }
        public int? Encuesta { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Encuestum EncuestaNavigation { get; set; }
        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
