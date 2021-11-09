using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.CupomModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.Modules.CupomModule
{
    public class CupomRepositoryEF : BaseRepository<Cupom>, ICupomRepository
    {
        private readonly LocadoraDbContext db;

        public CupomRepositoryEF(LocadoraDbContext db) : base(db)
        {
            this.db = db;
        }

        public override void Editar(int id, Cupom registroAlterado)
        {
            try
            {
                Cupom cupomParaAlterar= db.Cupons.SingleOrDefault(x => x.Id.Equals(id));

                //if (locacaoParaAlterar != null && _dbContext.Entry(locacaoParaAlterar).State != EntityState.Modified)
                //    _dbContext.Entry(locacaoParaAlterar).State = EntityState.Detached;

                registroAlterado.Id = id;

                db.Entry(cupomParaAlterar).CurrentValues.SetValues(registroAlterado);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cupom SelecionarPorId(int id, bool carregarParceiro = false)
        {
            if (carregarParceiro)
                return db.Cupons
                    .Include(x => x.Parceiro)
                    .FirstOrDefault(x => x.Id == id);

            return db.Cupons
                    .FirstOrDefault(x => x.Id == id);
        }
 
        public List<Cupom> SelecionarCuponsAtivos(DateTime dataAtual)
        {
            return db.Cupons.Where(x => x.DataValidade < dataAtual).ToList();
        }

        public override List<Cupom> SelecionarTodos()
        {
            return db.Cupons
               .Include(x => x.Parceiro)
               .ToList();
        }
    }
}
