using ApiWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ApplicationContextDB _Context;
        public ComentarioController(ApplicationContextDB Context)
        {
            this._Context = Context;
        }

        [HttpGet]
        public async Task<IActionResult> GetComentarios()
        {
            try
            {
                var _ListComentarios = await _Context.Comentarios.ToListAsync();
                return Ok(_ListComentarios);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddComentario([FromBody] Comentario _Request)
        {
            try
            {
                Comentario _Save = new Comentario()
                {
                    Titulo = _Request.Titulo,
                    Creador = _Request.Creador,
                    Texto = _Request.Texto,
                    FechaCreacion = DateTime.Now

                };

                _Context.Add(_Save);
                await _Context.SaveChangesAsync();
                return Ok(_Save);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteComentario( int Id)
        {
            try
            {
                var comentario = await _Context.Comentarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
                if (comentario == null)
                {
                    return BadRequest();
                }
                _Context.Remove(comentario);
                await _Context.SaveChangesAsync();
                return Ok(new {message = "Se borro con exito el registro"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
