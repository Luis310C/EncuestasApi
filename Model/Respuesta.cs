using System;
using System.Collections.Generic;

#nullable disable

namespace EncuestasApi.Model
{
    public partial class Respuesta
    {
        public int RespuestaCampo { get; set; }
        public int? Campo { get; set; }
        public string Respuesta1 { get; set; }
        public int? RespuestaEncuesta { get; set; }

        public virtual Campoencuestum CampoNavigation { get; set; }
        public virtual Respuestaencuestum RespuestaEncuestaNavigation { get; set; }
    }
}
