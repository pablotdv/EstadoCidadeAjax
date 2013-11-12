using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstadoCidadeAjax.Models
{
    public class CidadeModel
    {
        public int EstadoId { get; set; }

        public List<Cidade> Cidades { get; set; }
    }
}
