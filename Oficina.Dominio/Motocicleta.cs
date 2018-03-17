using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    class Motocicleta : Veiculo
    {
        public TipoChassi TipoChassi { get; set; }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
