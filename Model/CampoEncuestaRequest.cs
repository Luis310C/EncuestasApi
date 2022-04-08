using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncuestasApi.Model
{
    public class CampoEncuestaRequest
    {
        public string NombreCampo { get; set; }
        public string Título { get; set; }
        public bool Requerido { get; set; }
        public int Tipo { get; set; }

    }
}
