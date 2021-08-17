using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WindowsApp.Shared
{
    public class ConfiguracaoToolTips
    {
        public ConfiguracaoToolTips()
        {
            Adicionar = "Adicionar";
            Editar = "Editar";
            Excluir = "Excluir";
            Filtrar = "Filtrar";
            Agrupar = "Agrupar";
            Desagrupar = "Desagrupar";            
        }

        public string Adicionar { get; internal set; }
        public string Editar { get; internal set; }
        public string Excluir { get; internal set; }
        public string Filtrar { get; internal set; }
        public string Agrupar { get; internal set; }
        public string Desagrupar { get; internal set; }        
    }
}
