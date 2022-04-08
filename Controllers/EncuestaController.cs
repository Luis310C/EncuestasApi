using EncuestasApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncuestasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly EncuestaService encuestaService;
        public EncuestaController()
        {
            encuestaService = new EncuestaService();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Object>> PostEncuesta(EncuestaRequest encuesta) {

            var encuestaResponse = await encuestaService.CreateEncuesta(encuesta);
            return Ok(encuestaResponse);
       
        }
        [HttpGet]
        public async Task<ActionResult<Object>> GetPreguntas(int codigo) {

            var preguntasEncuesta = await encuestaService.CamposEncuesta(codigo);
            return Ok(preguntasEncuesta);
        }

        [HttpPost]
        [Route("responder")]
        public async Task<ActionResult<Object>> PostResponder(RespuestaEncuestaResponse respuesta) {
            var contestar = await encuestaService.ResponderEncuesta(respuesta);
            return Ok(contestar);
       
        }
        //[Authorize]
        //[HttpGet]
        //[Route("respuestas")]
        //public async Task<ActionResult<Object>> GetRespuestas(int codigoEncuesta) {
        //    var respuestas = await encuestaService.
        
        
        
        //}
    }
}
