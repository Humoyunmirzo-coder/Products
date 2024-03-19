using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prodation.MVC.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Price")]
        public int Price { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        [DisplayName("Date Of Issue")]
        public DateTime DateTime { get; set; }
    }
}
