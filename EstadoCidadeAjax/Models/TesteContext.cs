using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstadoCidadeAjax.Models
{
    public class TesteContext : DbContext
    {
        public TesteContext()
        {
            Database.SetInitializer<TesteContext>(new CreateDatabaseIfNotExists<TesteContext>());
        }

        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
    }

    public class Estado
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int EstadoId { get; set; }

        [MaxLength(2)]
        [Display(Name = "CodigoIBGE")]
        public string CodigoIBGE { get; set; }

        [MaxLength(2)]
        [Display(Name = "Sigla")]
        [Required]
        public string Sigla { get; set; }

        [MaxLength(100)]
        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int UsuarioCadId { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public DateTime DataHoraCad { get; set; }

        [Required]
        public bool Ativo { get; set; }
        public Estado()
        {
            this.DataHoraCad = DateTime.Now;
            this.Ativo = true;
        }
    }

    public class Cidade
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CidadeId { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }

        [Required]
        public int CodigoIBGE { get; set; }


        [HiddenInput(DisplayValue = false)]
        public int UsuarioCadId { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public DateTime DataHoraCad { get; set; }

        [Required]
        public bool Ativo { get; set; }


        public Cidade()
        {
            this.DataHoraCad = DateTime.Now;
            this.Ativo = true;
        }
    }
}