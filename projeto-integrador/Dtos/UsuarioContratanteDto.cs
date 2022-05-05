using System.ComponentModel.DataAnnotations;

namespace projeto_integrador.Dtos
{
    public class UsuarioContratanteDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NomeEmpresa { get; set; }
        [Required]
        public string EnderecoEmpresa { get; set; }
        [Required]
        public string UrlFotoEmpresa { get; set; }
        [Required]
        public string DescricaoEmpresa { get; set; }
        [Required]
        public string NumeroContato { get; set; }
    }
}
