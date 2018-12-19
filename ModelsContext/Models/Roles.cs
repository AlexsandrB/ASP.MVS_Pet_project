using System.ComponentModel.DataAnnotations;

namespace ModelsContext.Models
{
    public class Roles
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    } 
}
