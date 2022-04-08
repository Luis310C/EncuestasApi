using EncuestasApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncuestasApi
{
    public class EncuestaService:BasicService
    {

        public async Task<String> CreateEncuesta(EncuestaRequest encuesta) {
            Encuestum encuestaNueva = new Encuestum() { 
            NombreEncuesta = encuesta.NombreEncuesta,
            Descripción = encuesta.Descripción
            };
            var tempEncuesta =_db.Encuesta.Add(encuestaNueva);
            await _db.SaveChangesAsync();
            List<Campoencuestum> campos = new List<Campoencuestum>();
            foreach (var question in encuesta.campos) {
                var temp = new Campoencuestum() { 
                NombreCampo= question.NombreCampo,
                TítuloCampo =question.Título,
                TipoCampo = question.Tipo,
                Requerido = question.Requerido,
                Encuesta = tempEncuesta.Entity.EncuestaId
                };
                campos.Add(temp);
            
            };
            _db.Campoencuesta.AddRange(campos);
            await _db.SaveChangesAsync();
            return $"Encuesta creada con exito {tempEncuesta.Entity.EncuestaId}";
        }

        public async Task<object> CamposEncuesta(int IdFormulario) {
          return  await  _db.Campoencuesta.Where(campo => campo.Encuesta == IdFormulario).Select(campo=>new {
            Tipo = campo.TipoCampoNavigation.NombreTipo,
            Requerido = campo.Requerido,
            Titulo = campo.TítuloCampo,
            idCampo = campo.CampoId
            
            }).ToListAsync();

        
        
        }
        public async Task<Object> ObtenerRespuestas(int codigoEncuestas) {
            return await _db.Respuestas.Where(respuesta => respuesta.RespuestaEncuestaNavigation.Encuesta == codigoEncuestas).Select(
                respuesta=>new { 
                CodigoRespuesta  = respuesta.RespuestaEncuestaNavigation.RespuestaId,
                Pregunta = respuesta.CampoNavigation.TítuloCampo,
                Respuesta = respuesta.Respuesta1,
                Encuesta = respuesta.RespuestaEncuestaNavigation.EncuestaNavigation.NombreEncuesta
                }
                ).OrderByDescending(respuesta=>respuesta.CodigoRespuesta).ToListAsync();
        
        }

        public async Task<string> ResponderEncuesta(RespuestaEncuestaResponse respuesta) {
            Respuestaencuestum respuestaActual = new Respuestaencuestum()
            {
                Encuesta = respuesta.Encuesta,
                Fecha = DateTime.Now,
            };
            var tempRespuest = _db.Respuestaencuesta.Add(respuestaActual);
            await _db.SaveChangesAsync();
            List<Respuesta> respuestas = new List<Respuesta>();
            foreach (var respuestaCampo in respuesta.respuestas) {
                var temp = new Respuesta();
                temp.Campo = respuestaCampo.Campo;
                temp.Respuesta1 = respuestaCampo.respuesta;
                temp.RespuestaEncuesta = tempRespuest.Entity.RespuestaId;
                respuestas.Add(temp);
            }
            _db.Respuestas.AddRange(respuestas);
            await _db.SaveChangesAsync();
            return "Respuestas agregadas";



        }
    }
}
