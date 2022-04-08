using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncuestasApi
{
    public class RespuestaResponse {
        public int Campo { get; set; }
        public string respuesta { get; set; }

    }
    public class RespuestaEncuestaResponse
    {
        public int Encuesta { get; set; }
        public List<RespuestaResponse> respuestas { get; set; }
    }
}
