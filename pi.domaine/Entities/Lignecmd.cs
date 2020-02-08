using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
    public class lignecmd
    {

        //id pk
        public int LignecmdId { get; set; }

        //fk idproduit


        //fk factdev
        public int ProductId { get; set; }

        public int? FactdevId { get; set; }

        public int? BoncmdId { get; set; }

        public int UserId { get; set; }

        public int quantite { get; set; }

        public double prix { get; set; }

        public int etat { get; set; }

        [ForeignKey("ProductId")]
        public Product product { get; set; }

        [ForeignKey("FactdevId")]
        public factdev factdev { get; set; }

        [ForeignKey("UserId")]
        public User userr { get; set; }

        [ForeignKey("BoncmdId")]
        public Boncmd boncmd { get; set; }
    }
}
