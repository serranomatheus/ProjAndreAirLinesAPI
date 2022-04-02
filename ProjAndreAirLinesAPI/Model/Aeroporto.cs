using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjAndreAirLinesAPI.Model
{
    public class Aeroporto
    {
        #region Propriedades
        [Key]
        public string Sigla { get; set; }
        
        public string Nome { get; set; }
        
        
        public virtual Endereco Endereco { get; set; }
        
        #endregion

       
    }
}
