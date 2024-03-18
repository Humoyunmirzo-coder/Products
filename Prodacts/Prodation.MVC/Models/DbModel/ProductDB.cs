using System.ComponentModel.DataAnnotations;

namespace Prodation.MVC.Models.DbModel
{
    public class ProductDB
    {

        [Key]
        public int Id { get; set; }
        public int Prise { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public DateTime DateTime { get; set; }
    }
}
