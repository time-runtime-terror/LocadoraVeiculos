using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Modules.VeiculoModule
{
    public class VeiculoRepositoryEF : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepositoryEF(LocadoraDbContext dbContext) 
        {

        }

        public override Veiculo SelecionarPorId(int id)
        {


            using (LocadoraDbContext db = new LocadoraDbContext())
            {

                return db.Veiculos
                    .Include(l => l.GrupoAutomoveis)
                    .FirstOrDefault(l => l.Id == id);
            }
        }

        public override List<Veiculo> SelecionarTodos()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {

                return db.Veiculos
                    .Include(l => l.GrupoAutomoveis).ToList();
            }
        }

        public void AtualizarQuilometragem(Veiculo veiculo)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
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
        }

        public void AtualizarStatusAluguel(Veiculo veiculo)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
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
}
