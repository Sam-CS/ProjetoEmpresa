using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    class Perfil
    {
        public int id { get; set; }
        public String nome { get; set; }
        public int cadUsuario { get; set; }
        public int cadPerfil { get; set; }
        public int cadSetor { get; set; }
        public int cadFuncionario { get; set; }
        public int relSetor { get; set; }
        public int relFuncionario { get; set; }
        public int status { get; set; }
    }
}
