using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonFlatFileDataStore;

namespace LocadoraVeiculos.Infra.JSON.LocacaoModule
{
    public class ArmazenadorEmail : IArmazenadorEmail
    {
        //private DataStore ArmazemDados { get; init; }

        //public ArmazenadorEmail()
        //{
        //    ArmazemDados = new DataStore("emailData.json");
        //}
        //public void AgendarEnvioEmail(Email email, string caminho)
        //{
        //    try
        //    {
        //        var collection = ArmazemDados.GetCollection<Email>();

        //        collection.InsertOne(email);
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("caminhoArquivo", caminho);
        //        throw ex;
        //    }
        //}
    }
}
