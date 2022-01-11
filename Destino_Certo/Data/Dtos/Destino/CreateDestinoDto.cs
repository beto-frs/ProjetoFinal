using Destino_Certo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Destino_Certo.Data.Dtos.Destino
{
    public class CreateDestinoDto : PageModel
    {

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Local { get; set; }

        public byte[] ArrayImagem { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Incluso é obrigatório")]
        public string Incluso { get; set; }

        public string NomeArquivo { get; set; }

        public string ExtensaoArquivo { get; set; }

        public string InfoArquivo { get; set; }

        [BindProperty]
        public Buffered FileUpload { get; set; }

    }

    public class Buffered
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
