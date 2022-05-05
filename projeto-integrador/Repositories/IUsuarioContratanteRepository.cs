using projeto_integrador.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projeto_integrador.Repositories
{
    public interface IUsuarioContratanteRepository
    {
        Task<UsuarioContratante> Adicionar(UsuarioContratante entidade);
        Task<UsuarioContratante> Atualizar(UsuarioContratante entidade);
        Task Deletar(object id);
        Task<UsuarioContratante> ObterPorId(object id);
        Task<IEnumerable<UsuarioContratante>> ObterTodos();
        Task<int> CommitAsync();
    }
}
