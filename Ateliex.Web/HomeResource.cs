using System.Web;

namespace Ateliex
{
    public class HomeResource : LinkedResource
    {
        public HomeResource()
        {
            Title = "Home";

            HRef = "/";

            Links = new Link[]
            {
                new Link {Rel = "cadastro", HRef = "/cadastro", Text = "Cadastro"},
                new Link {Rel = "decisoes", HRef = "/decisoes", Text = "Decisões"}
            };
        }
    }
}
