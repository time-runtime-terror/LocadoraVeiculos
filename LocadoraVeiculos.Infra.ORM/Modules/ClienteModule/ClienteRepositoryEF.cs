using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.Modules.ClienteModule
{
    public class ClienteRepositoryEF : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly LocadoraDbContext db;

        public ClienteRepositoryEF(LocadoraDbContext db) : base(db)
        {
            this.db = db;
        }

        public override Cliente SelecionarPorId(int id)
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

        public override List<Cliente> SelecionarTodos()
        {
            try
            {
                return db.Clientes
                    .OrderBy(x => x.Id)
                    .Include(e => e.Empresa)
                    .AsSplitQuery()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarStatusLocacaoAtiva(Cliente cliente)
        {
            try
            {
                db.Entry(cliente).State = EntityState.Modified;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> SelecionarTodasPessoasFisicas()
        {
            try
            {
                return db.Clientes
                    .OrderBy(x => x.Id)
                    .Include(x => x.Empresa)
                    .AsSplitQuery()
                    .Where(x => x.TipoCadastro == "CPF")
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> SelecionarTodasPessoasJuridicas()
        {
            try
            {
                return db.Clientes
                    .OrderBy(x => x.Id)
                    .Include(x => x.Empresa)
                    .AsSplitQuery()
                    .Where(x => x.TipoCadastro == "CNPJ")
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
