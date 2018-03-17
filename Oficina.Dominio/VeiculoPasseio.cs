using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    public class VeiculoPasseio : Veiculo
    {
        //ToDo: OO - Herança
        public TipoCarroceria Carroceria { get; set; }

        public override List<string> Validar()
        {
            var errors = ValidarBase();

            if (!Enum.IsDefined(typeof(TipoCarroceria), Carroceria))
            {
                errors.Add($"A carroceria informada ({Carroceria}) não é válida");
            }

            return errors;
        }
    }
}
