﻿using Destino_Certo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Destino_Certo.Data.Dtos.Atendimento
{
    public class UpdateAtendimentoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Assunto é obrigatório")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "O campo Identificação é obrigatório")]
        public int PessoaModelId { get; set; }
        public virtual PessoaModel Pessoa { get; set; }

        [Required(ErrorMessage = "O campo Mensagem é obrigatório")]
        public string Mensagem { get; set; }

        
        public bool FezContato = false;

        public string? Tratativa { get; set; }

        public int? AnalistaId { get; set; }
        public DateTime Inicio { get; set; }

        public DateTime Termino = DateTime.Now;

    }
}