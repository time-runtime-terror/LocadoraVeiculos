using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.Modules.VeiculoModule
{
    public class VeiculoRepositoryEF : BaseRepository<Veiculo>, IVeiculoRepository
    {
        private LocadoraDbContext db;
        
        public VeiculoRepositoryEF(LocadoraDbContext db) : base(db)
        {
            this.db = db;
        }

        public override Veiculo SelecionarPorId(int id)
        {

            return db.Veiculos
                .Include(l => l.GrupoAutomoveis)
                .FirstOrDefault(l => l.Id == id);
        }

        public override List<Veiculo> SelecionarTodos()
        {
            return db.Veiculos
                .Include(l => l.GrupoAutomoveis).ToList();
        }

        public void AtualizarQuilometragem(Veiculo veiculo)
        {
            try
            {
                var idExiste = db.Set<Veiculo>().Any();

                if (idExiste == true)
                {
                    //O ID ESTA COM ZERO(LEMBRAR)
                    var veiculoEncontrado = SelecionarPorId(veiculo.Id);

                    veiculoEncontrado.Quilometragem = veiculo.Quilometragem;

                    db.Set<Veiculo>().Update(veiculoEncontrado);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarStatusAluguel(Veiculo veiculo)
        {
            try
            {
                var idExiste = db.Set<Veiculo>().Any();

                if (idExiste == true)
                {
                    var veiculoEncontrado = db.Veiculos.Where(x => x.Id == veiculo.Id).FirstOrDefault();

                    veiculoEncontrado.EstaAlugado = veiculo.EstaAlugado;

                    db.Set<Veiculo>().Update(veiculoEncontrado);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
