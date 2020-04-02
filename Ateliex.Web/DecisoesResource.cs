using System.Collections.Generic;
using System.Web;

namespace Ateliex
{
    public class DecisoesResource : LinkedResource
    {
        public DecisoesResource()
        {
            Title = "Decisões";

            HRef = "/decisoes";

            Links = new List<Link>
            {
                new Link {Rel = "comerciais", HRef = "/decisoes/comerciais", Text = "Comerciais"}
            };
        }
    }
}
