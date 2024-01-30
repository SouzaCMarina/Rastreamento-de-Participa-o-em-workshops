using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Fast___Fullstack.Models
{
    public class WorkshopModel
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public DateTime DataRealizacao {get; set;}
        public string Descricao {get; set;}
        public List<PresencaModel> Presencas {get; set;} = new List<PresencaModel>();
    }
}