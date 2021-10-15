using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.Modules.GrupoAutomoveisModule
{
    public class GrupoAutomoveisRepositoryEF : BaseRepository<GrupoAutomoveis>, IGrupoAutomoveisRepository
    {
        private readonly LocadoraDbContext db;

        public GrupoAutomoveisRepositoryEF(LocadoraDbContext db) : base (db)
        {
            this.db = db;
        }

        public override void Editar(int id, GrupoAutomoveis registro)
        {
            try
            {
                GrupoAutomoveis registroEncontrado = db.Set<GrupoAutomoveis>().SingleOrDefault(x => x.Id.Equals(id));

                registro.Id = id;

                db.Entry(registroEncontrado).CurrentValues.SetValues(registro);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override GrupoAutomoveis SelecionarPorId(int id)
        {

            return db.GrupoAutomoveis
                .Include(gp => gp.Veiculos)
                .FirstOrDefault(gp => gp.Id == id);
        }
    }
}
