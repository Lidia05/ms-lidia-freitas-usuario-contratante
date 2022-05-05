using Microsoft.EntityFrameworkCore;
using projeto_integrador.Data;
using projeto_integrador.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projeto_integrador.Repositories
{
    public class UsuarioContratanteRepository : IUsuarioContratanteRepository
    {
        private readonly DataContext _db;
        private readonly DbSet<UsuarioContratante> _dbSet;

        public UsuarioContratanteRepository(DataContext db)
        {
            _db = db;
            _dbSet = _db.Set<UsuarioContratante>();
        }

        public async Task<UsuarioContratante> Adicionar(UsuarioContratante entidade)
        {
            await _db.Set<UsuarioContratante>().AddAsync(entidade);
            return entidade;
        }

        public async Task<UsuarioContratante> Atualizar(UsuarioContratante entidade)
        {
            await Task.Yield();
            _db.Set<UsuarioContratante>().Update(entidade);
            return entidade;
        }

        public async Task Deletar(object id)
        {
            var entidade = await ObterPorId(id).ConfigureAwait(false);

            _db.Set<UsuarioContratante>().Remove(entidade);
        }

        public virtual async Task<UsuarioContratante> ObterPorId(object id)
        {
            UsuarioContratante result = await _db.Set<UsuarioContratante>().FindAsync(id);
            return result;
        }

        public virtual async Task<IEnumerable<UsuarioContratante>> ObterTodos()
        {

            return await _db.Set<UsuarioContratante>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> CommitAsync()
        {
            var retorno = await _db.SaveChangesAsync().ConfigureAwait(false);
            foreach (var entity in _db.ChangeTracker.Entries())
                entity.State = EntityState.Detached;
            return retorno;
        }
    }
}
