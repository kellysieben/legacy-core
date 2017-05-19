using System.ComponentModel.DataAnnotations;

namespace Legacy.CoreApi.Models
{
    public class Value
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
    }

}
