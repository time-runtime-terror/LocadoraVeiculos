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
        public FuncionarioRepositoryEF()
        {
        }

        public Dictionary<string, object> AdicionarParametroFuncionario(string campoUsuario, object valorUsuario, string campoSenha, object valorSenha)
        {
            throw new NotImplementedException();
        }

        public bool ExisteFuncionario(string usuario, string senha)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
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
}
