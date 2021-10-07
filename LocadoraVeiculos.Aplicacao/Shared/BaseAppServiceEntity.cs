using LocadoraVeiculos.netCore.Dominio.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.Shared
{
    public class BaseAppServiceEntity<T> where T : class, IEntity
    {
        private readonly IRepositoryEntity<T> _repository;

        public BaseAppServiceEntity(IRepositoryEntity<T> repository) => _repository = repository;

        public virtual void Inserir(T registro)
        {
            Log.Debug("Inserindo novo registro... {Registro}", registro);

            try
            {
                 _repository.InserirNovo(registro);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar inserir novo registro {Registro}", registro);
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual void Editar(T registro)
        {
            Log.Debug("Editando registro ID: {IdRegistro}", registro.Id);

            try
            {
                _repository.Editar(registro.Id, registro);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar editar registro ID: {IdRegistro}", registro.Id);
                throw new Exception(ex.Message, ex);
            }
        }

        public bool Excluir(int id)
        {
            Log.Debug("Excluindo registro ID: {IdRegistro}", id);

            try
            {
                return _repository.Excluir(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar excluir registro ID: {IdRegistro}", id);
                throw new Exception(ex.Message, ex);
            }
        }

        public T SelecionarPorId(int id)
        {
            Log.Debug("Selecionando registro ID: {IdRegistro}", id);

            try
            {
                return _repository.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar registro ID: {IdRegistro}", id);
                throw new Exception(ex.Message, ex);
            }
        }

        public List<T> SelecionarTodos()
        {
            Log.Debug("Selecionando todas os registros...");

            try
            {
                return _repository.SelecionarTodos() as List<T>;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar todas os registros");
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

