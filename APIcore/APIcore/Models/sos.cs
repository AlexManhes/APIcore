using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIcore.Models
{
    
    public class sosEditar
    {
        [Key]
        public int matricula { get; set; }
        public string nome { get; set; }
        
    }
}
