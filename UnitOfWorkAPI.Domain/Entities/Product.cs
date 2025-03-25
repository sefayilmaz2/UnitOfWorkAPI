using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkAPI.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Sku {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public Brand? Brand { get; set; }
    }
}
