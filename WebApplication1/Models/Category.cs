using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key] //primary key
        public int Id { get; set; }
        [Required] //name is a required property
        public string Name { get; set; }
        public string DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
