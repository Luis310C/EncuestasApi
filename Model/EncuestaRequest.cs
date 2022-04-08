using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncuestasApi.Model
{
    public class EncuestaRequest
    {
        public string NombreEncuesta { get; set; }
        public string Descripción { get; set; }
        public List<CampoEncuestaRequest> campos { get; set; }
    }
}
