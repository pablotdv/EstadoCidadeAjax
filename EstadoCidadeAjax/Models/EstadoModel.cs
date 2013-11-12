using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadoCidadeAjax.Models
{
    public class EstadoModel
    {
        public Estado Estado { get; set; }

        public CidadeModel Cidade { get; set; }
    }
}