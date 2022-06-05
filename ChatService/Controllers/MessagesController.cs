using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatService.Context;
using ChatService.Models;

namespace ChatService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly MessageContext _context;

        public MessagesController(MessageContext context)
        {
            _context = context;
        }

        // GET: Messages
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Message>>> Index()
        {
            return await _context.Message.ToListAsync();
        }

        [HttpGet("/room/{id}")]
        public async Task<ActionResult<Message>> GetProduct(int id)
        {
            List<Message> m2 = await _context.Message.ToListAsync();
            List<Message> messages = new List<Message>();

            foreach(var m in m2)
            {
                if(m.fk_room == id)
                {
                    messages.Add(m);
                }
            }

            if (messages.Count < 1)
            {
                return NoContent();
            }

            return Ok(messages);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            try
            {
                _context.Message.Add(message);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProduct", new { id = message.id_message }, message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
