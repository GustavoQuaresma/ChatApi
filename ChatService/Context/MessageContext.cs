using Microsoft.EntityFrameworkCore;
using ChatService.Models;

namespace ChatService.Context
{
    public class MessageContext : DbContext  
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options) { }
        public DbSet<ChatService.Models.Message> Message { get; set; }
    }
}
