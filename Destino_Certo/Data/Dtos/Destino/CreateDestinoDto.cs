﻿using Destino_Certo.Models;
using System.ComponentModel.DataAnnotations;

namespace Destino_Certo.Data.Dtos.Destino
{
    public class CreateDestinoDto
    {

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Incluso é obrigatório")]
        public string Incluso { get; set; }
    }
}
