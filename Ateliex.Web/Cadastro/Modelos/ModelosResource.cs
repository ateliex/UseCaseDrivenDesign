using System.Collections.Generic;
using System.Web;

namespace Ateliex.Cadastro.Modelos
{
    public class ModelosResource : LinkedResource
    {
        public ModelosResource()
        {
            Title = "Modelos";

            HRef = "/cadastro/modelos";

            Links = new List<Link>
            {
                    new Link {Rel = "consulta-de-modelos", HRef = "/cadastro/modelos/consulta-de-modelos", Text = "Consulta de Modelos"},
                    new Link {Rel = "cadastro-de-modelos", HRef = "/cadastro/modelos/cadastro-de-modelos", Text = "Cadastro de Modelos"}
            };
        }
    }
}
