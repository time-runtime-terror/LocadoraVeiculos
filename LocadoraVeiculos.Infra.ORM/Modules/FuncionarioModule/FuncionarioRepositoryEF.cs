using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.Modules.FuncionarioModule
{
    public class FuncionarioRepositoryEF : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        private readonly LocadoraDbContext db;

        public FuncionarioRepositoryEF(LocadoraDbContext db) : base(db)
        {
            this.db = db;
        }

        public Dictionary<string, object> AdicionarParametroFuncionario(string campoUsuario, object valorUsuario, string campoSenha, object valorSenha)
        {
            throw new NotImplementedException();
        }

        public virtual void Editar(int id, Funcionario registro)
        {
            try
            {
                Funcionario registroParaAlterar = db.Set<Funcionario>().SingleOrDefault(x => x.Id.Equals(id));

                registro.Id = id;

                db.Entry(registroParaAlterar).CurrentValues.SetValues(registro);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteFuncionario(string usuario, string senha)
        {
            try
            {
                return db.Funcionarios.Where(x => x.NomeUsuario == usuario && x.Senha == senha).Any();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
