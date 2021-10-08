using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Modules.ClienteModule
{
    public class ClienteRepositoryEF : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepositoryEF()
        {
        }

        public override Cliente SelecionarPorId(int id)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    return db.Clientes
                        .Where(x => x.Id == id)
                        .Include(e => e.Empresa)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public override List<Cliente> SelecionarTodos()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    return db.Clientes
                        .OrderBy(x => x.Id)
                        .Include(e => e.Empresa)
                        .ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void AtualizarStatusLocacaoAtiva(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> SelecionarTodasPessoasFisicas()
        {
            throw new NotImplementedException();
        }

        public List<Cliente> SelecionarTodasPessoasJuridicas()
        {
            throw new NotImplementedException();
        }
    }
}
