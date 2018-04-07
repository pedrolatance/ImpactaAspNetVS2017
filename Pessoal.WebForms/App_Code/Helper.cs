using Pessoal.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pessoal.WebForms
{

    public class Helper
    {
        public Helper()
        {

        }

        public List<Prioridade> ObterPrioridades()
        {
            return Enum.GetValues(typeof(Prioridade)).Cast<Prioridade>().ToList();
        }
    }
}