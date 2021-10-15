using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.Modules.TaxasServicosModule
{
    public class TaxasServicosRepositoryEF : BaseRepository<TaxasServicos>, ITaxasServicosRepository
    {

        private readonly LocadoraDbContext db;

        public TaxasServicosRepositoryEF(LocadoraDbContext db) : base(db)
        {
            this.db = db;
        }

        public override void Editar(int id, TaxasServicos registro)
        {
            try
            {
                TaxasServicos registroEncontrado = db.Set<TaxasServicos>().SingleOrDefault(x => x.Id.Equals(id));

                registro.Id = id;

                db.Entry(registroEncontrado).CurrentValues.SetValues(registro);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InserirNovaTaxaUsada(Locacao registro)
        {
            throw new NotImplementedException();
        }

        public void EditarTaxasUsadas(Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public bool ExcluirTaxaUsada(Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public List<TaxasServicos> SelecionarTaxasServicosUsados(int id)
        {
            throw new NotImplementedException();
        }
    }
}
