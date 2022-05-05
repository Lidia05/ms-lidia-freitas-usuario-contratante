using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_integrador.Dtos;
using projeto_integrador.Models;
using projeto_integrador.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projeto_integrador.Controllers
{
    [ApiController]
    [Route("api/usuario-contratante")]
    public class UsuarioContratanteController : ControllerBase
    {

        private readonly IUsuarioContratanteRepository _usuarioContratanteRepository;

        public UsuarioContratanteController(IUsuarioContratanteRepository usuarioContratanteRepository)
        {
            _usuarioContratanteRepository = usuarioContratanteRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UsuarioContratanteDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(UsuarioContratanteDto usuarioContratanteDto)
        {

            var result = await _usuarioContratanteRepository.Adicionar(new UsuarioContratante(
                usuarioContratanteDto.Nome,
                usuarioContratanteDto.Email,
                usuarioContratanteDto.NomeEmpresa,
                usuarioContratanteDto.EnderecoEmpresa,
                usuarioContratanteDto.UrlFotoEmpresa,
                usuarioContratanteDto.DescricaoEmpresa,
                usuarioContratanteDto.NumeroContato
                ));
            await _usuarioContratanteRepository.CommitAsync();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UsuarioContratante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Atualizar(Guid id, UsuarioContratante usuarioContratante)
        {
            var usuario = await _usuarioContratanteRepository.ObterPorId(id);
            usuario.SetNome(usuarioContratante.Nome);
            usuario.SetDescricaoEmpresa(usuarioContratante.DescricaoEmpresa);
            usuario.SetEmail(usuarioContratante.Email);
            usuario.SetNumeroContato(usuarioContratante.NumeroContato);
            usuario.SetEnderecoEmpresa(usuarioContratante.EnderecoEmpresa);
            usuario.SetNomeEmpresa(usuarioContratante.NomeEmpresa);
            usuario.SetNumeroContato(usuarioContratante.NumeroContato);
            usuario.SetUrlFotoEmpresa(usuarioContratante.UrlFotoEmpresa);
            var result = await _usuarioContratanteRepository.Atualizar(usuario);
            await _usuarioContratanteRepository.CommitAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioContratante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await _usuarioContratanteRepository.ObterPorId(id);
            return Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<UsuarioContratante>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll()
        {
            var result = await _usuarioContratanteRepository.ObterTodos();
            return Ok(result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UsuarioContratante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _usuarioContratanteRepository.Deletar(id);
            await _usuarioContratanteRepository.CommitAsync();
            return Ok($"{id} - excluído com sucesso!");
        }

        

    }
}
