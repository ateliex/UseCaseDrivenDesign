using System.Collections.Generic;
using System.Web;

namespace Ateliex
{
    public class CadastroResource : LinkedResource
    {
        public CadastroResource()
        {
            Title = "Cadastro";

            HRef = "/cadastro";

            Links = new List<Link>
            {
                new Link {Rel = "modelos", HRef = "/cadastro/modelos", Text = "Modelos"}
            };
        }
    }
}
