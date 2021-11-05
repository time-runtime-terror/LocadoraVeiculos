using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Modules.ParceiroModule
{
    public class ParceiroRepositoryEF : BaseRepository<Parceiro>, IParceiroRepository
    {
        private readonly LocadoraDbContext db;

        public ParceiroRepositoryEF(LocadoraDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
