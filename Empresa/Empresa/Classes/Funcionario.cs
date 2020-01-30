using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    class Funcionario
    {
        public int id { get; set; }
        public String nome { get; set; }
        public String cpf { get; set; }
        public DateTime dtNascimento { get; set; }
        public char sexo { get; set; }
        public String estadoCivil { get; set; }
        public String cep { get; set; }
        public String endereco { get; set; }
        public DateTime dtAdmissao { get; set; }
        public int status { get; set; }
        public int idSetor { get; set; }
    }
}
