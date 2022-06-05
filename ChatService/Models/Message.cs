using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ChatService.Models
{
    public class Message
    {
        [Key]
        public int id_message { get; set; }

        public string message { get; set; }

        public string nome { get; set; }

        public int fk_room { get; set; }

    }
}
