using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Loja.Mvc.Helpers
{
    public class CulturaHelper
    {
        private const string LinguagemPadrao = "pt-BR";
        private string _linguagemSelecionada = LinguagemPadrao;
        private List<string> LinguagemSuportadas = new List<string> { "pt-BR", "en-US", "es" };

        public CulturaHelper()
        {
            DefinirLinguagemPadrao();
            ObterRegionInfo();
        }

        public string NomeNativo { get; set; }
        public string Abreviacao { get; set; }



        private void ObterRegionInfo()
        {
            var cultura = CultureInfo.CreateSpecificCulture(_linguagemSelecionada);
            var regiao = new RegionInfo(cultura.LCID);

            NomeNativo = regiao.NativeName;
            Abreviacao = regiao.TwoLetterISORegionName.ToLower();
        }


        private void DefinirLinguagemPadrao()
        {
            var request = HttpContext.Current.Request;
            if (request.Cookies["LinguagemSelecionada"] != null)
            {
                _linguagemSelecionada = request.Cookies["LinguagemSelecionada"].Value;
                return;
            }

            if (request.UserLanguages != null && LinguagemSuportadas.Contains(request.UserLanguages[0]))
            {
                _linguagemSelecionada = request.UserLanguages[0];
            }

            var cookie = new HttpCookie("LinguagemSelecionada", _linguagemSelecionada);
            cookie.Expires = DateTime.MaxValue;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        internal static CultureInfo ObterCultureInfo()
        {
            var linguagemSelecionada = HttpContext.Current.Request.Cookies["LinguagemSelecionada"];
            var linguagem = linguagemSelecionada?.Value ?? LinguagemPadrao;

            return CultureInfo.CreateSpecificCulture(linguagem);
        }


    }
}