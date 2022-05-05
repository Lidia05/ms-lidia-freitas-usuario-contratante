using System;
using System.ComponentModel.DataAnnotations;

namespace projeto_integrador.Models
{
    public class UsuarioContratante
    {
        public UsuarioContratante(string nome, string email, string nomeEmpresa, 
            string enderecoEmpresa, string urlFotoEmpresa, string descricaoEmpresa, 
            string numeroContato)
        {
            Id = new Guid();
            Nome = nome;
            Email = email;
            NomeEmpresa = nomeEmpresa;
            EnderecoEmpresa = enderecoEmpresa;
            UrlFotoEmpresa = urlFotoEmpresa;
            DescricaoEmpresa = descricaoEmpresa;
            NumeroContato = numeroContato;
        }

        public Guid Id { get; private set; }

        [Required]
        [MaxLength(500)]
        public string Nome { get; private set; }
        [Required]
        [MaxLength(500)]
        public string Email { get; private set; }
        [Required]
        [MaxLength(500)]
        public string NomeEmpresa { get; private set; }
        [Required]
        [MaxLength(500)]
        public string EnderecoEmpresa { get; private set; }
        [Required]
        [MaxLength(500)]
        public string UrlFotoEmpresa { get; private set; }
        [Required]
        [MaxLength(500)]
        public string DescricaoEmpresa { get; private set; }
        [Required]
        [MaxLength(100)]
        public string NumeroContato { get; private set; }


        public void SetNome(string nome)=> Nome = nome;
        public void SetEmail(string email) => Email = email;
        public void SetNomeEmpresa(string nomeEmpresa) => NomeEmpresa = nomeEmpresa;
        public void SetEnderecoEmpresa(string enderecoEmpresa) => EnderecoEmpresa = enderecoEmpresa;
        public void SetUrlFotoEmpresa(string urlFotoEmpresa) => UrlFotoEmpresa = urlFotoEmpresa;
        
        public void SetDescricaoEmpresa(string descricaoEmpresa) => DescricaoEmpresa = descricaoEmpresa;

        public void SetNumeroContato(string numeroContato) => NumeroContato = numeroContato;

    }
}
