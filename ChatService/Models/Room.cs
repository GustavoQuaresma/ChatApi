using System.ComponentModel.DataAnnotations;

namespace ChatService.Models
{
    public class Room
    {
        [Key]
        public int id_Room { get; set; }
        public int fk_contratante { get; set; }
        public int fk_contratado { get; set; }

    }
}
