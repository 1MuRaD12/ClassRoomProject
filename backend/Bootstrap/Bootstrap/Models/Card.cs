using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootstrap.Models
{
    public class Card
    {
        public int Id { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public IFormFile  Photo { get; set; }
    }
}
