﻿using System.Web;

namespace Ateliex.Cadastro.Modelos
{
    public class ModelosResource : LinkedResourceCollection<ModeloResource>
    {
        public ModelosResource()
        {
            Title = "Modelos";

            HRef = "/cadastro/modelos";

            Links = new Link[]
            {
                new Link {Rel = "consulta-de-modelos", HRef = "/cadastro/modelos/consulta-de-modelos", Text = "Consulta de Modelos"},
                new Link {Rel = "cadastro-de-modelos", HRef = "/cadastro/modelos/cadastro-de-modelos", Text = "Cadastro de Modelos"}
            };
        }
    }
}