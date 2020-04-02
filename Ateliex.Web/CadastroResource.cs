using System.Web;

namespace Ateliex
{
    public class CadastroResource : LinkedResource
    {
        public CadastroResource()
        {
            Title = "Cadastro";

            HRef = "/cadastro";

            Links = new Link[]
            {
                new Link {Rel = "modelos", HRef = "/cadastro/modelos", Text = "Modelos"}
            };
        }
    }
}
