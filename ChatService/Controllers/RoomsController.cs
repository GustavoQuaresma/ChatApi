using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatService.Context;
using ChatService.Models;
using Microsoft.AspNetCore.Cors;

namespace ChatService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly RoomContext _context;

        public RoomsController(RoomContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Room>>> Index()
        {
            return await _context.Room.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetProduct(int id)
        {
            var message = await _context.Room.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        [HttpGet("/contratado/{id}")]
        public async Task<ActionResult<Room>> GetRoomByContratado([FromRoute]int id)
        {
            List<Room> r = await _context.Room.ToListAsync();
            List<Room> rooms = new List<Room>();

            foreach (var room in r)
            {
                if (room.fk_contratado == id)
                {
                    rooms.Add(room);
                }
            }

            if (rooms.Count < 1)
            {
                return NoContent();
            }

            return Ok(rooms);
        }

        [HttpGet("/contratante/{id}")]
        public async Task<ActionResult<Room>> GetRoomByContratante(int id)
        {
            List<Room> r = await _context.Room.ToListAsync();
            List<Room> rooms = new List<Room>();

            foreach (var room in r)
            {
                if (room.fk_contratante == id)
                {
                    rooms.Add(room);
                }
            }

            if (rooms.Count < 1)
            {
                return NoContent();
            }

            return Ok(rooms);
        }


        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<Room>> PostProduct([FromBody]Room room)
        {
            try
            {
                _context.Room.Add(room);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProduct", new { id = room.id_Room }, room);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
