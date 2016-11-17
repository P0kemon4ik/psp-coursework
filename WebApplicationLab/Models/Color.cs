using System.ComponentModel.DataAnnotations;


namespace WebApplicationLab.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Color")]
        public string Name { get; set; }
    }
}