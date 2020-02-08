using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
    public enum enumSatisfaction
    {
        NotSatisfied,
        Satisfied,
        VerySatisfied
    }

    public enum TypeReclamation
    {
        Technique,
        Financiere,
        Relationnelle
    }
    public class Reclamation
    {

        [Key]
        public int idReclamation { get; set; }
        public int IdUser { get; set; }
        public User UserId { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public string contenu { get; set; }
        public DateTime Date { get; set; }
        public string etat { get; set; }
        public TypeReclamation TypeReclamation { get; set; }
        public ICollection<Response> Responses { get; set; }
        public string Urlimage { get; set; }
        public enumSatisfaction? SatisfactionEnum { get; set; }


    }
}



    

    

