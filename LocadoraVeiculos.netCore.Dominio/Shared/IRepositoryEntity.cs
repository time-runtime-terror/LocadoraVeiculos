using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Dominio.Shared
{
    public interface IRepositoryEntity<TEntity> where TEntity : IEntity
    {
        void InserirNovo(TEntity registro);

       
        void Editar(int id, TEntity registro);

        
        bool Excluir(int id);

       
        TEntity SelecionarPorId(int id);

        
        List<TEntity> SelecionarTodos();

        
        List<TEntity> Pesquisar(string texto);
    }
}
