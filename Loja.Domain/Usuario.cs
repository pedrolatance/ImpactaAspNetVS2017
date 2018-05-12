using Microsoft.AspNet.Identity.EntityFramework;

namespace Loja.Domain
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
    }
}
