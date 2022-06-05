using Microsoft.EntityFrameworkCore;

namespace ChatService.Context
{
    public class RoomContext : DbContext
    {
        public RoomContext(DbContextOptions<RoomContext> options) : base(options) { }
        public DbSet<ChatService.Models.Room> Room { get; set; }
    }
}
