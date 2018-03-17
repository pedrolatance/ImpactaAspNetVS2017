using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //ToDo: OO - abstração ou classe.
    public abstract class Veiculo
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        //ToDo: OO  Encapsulamento
        private string _placa;
        public string Placa
        {
            get
            {
                return _placa.ToUpper();
            }
            set
            {
                _placa = value.ToUpper();
            }
        }

        public int Ano { get; set; }
        public string Observacao { get; set; }

        public Cor Cor { get; set; }
        public Modelo Modelo { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }
        

        protected List<string> ValidarBase()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(Placa))
            {
                errors.Add("A placa é obrigatória");
            }

            return errors;

        }

        public abstract List<string> Validar();

        //ToDo: OO - Sobreposição
        public override string ToString()
        {
            return $"{Modelo.Nome} - {Cor.Nome} - {Placa}"; 
        }

    }
}
