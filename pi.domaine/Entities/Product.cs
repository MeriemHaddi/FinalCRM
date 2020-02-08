using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
    
    public class Product
    {
        [Key]
        public int idProduct { get; set; }

        [MaxLength(25)]
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Picture { get; set; }
        public int? id_Shop { get; set; }
        public int? id_Category { get; set; }
        public int In_Quantity { get; set; }
        public int Out_Quantity { get; set; }
        public int nbrvue { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("id_Shop")]
        public virtual Shop Shop { get; set; }
        [ForeignKey("id_Category")]
        public virtual CategoryProduct CategoryProduct { get; set; }






        public Product() { }
        public Product(string nom, string Description, float Price, string Picture)
        {
            this.Product_Name = nom;
            this.Description = Description;
            this.Price = Price;
            this.Picture = Picture;
        }
        public Product(string nom)
        {
            this.Product_Name = nom;

        }


    }
}
