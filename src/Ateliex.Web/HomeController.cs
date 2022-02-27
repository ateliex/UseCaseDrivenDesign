﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Ateliex
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Sumário
        /// </summary>
        /// <returns>Retorno</returns>
        /// <response code="200">Teste</response>
        [HttpGet(Name = "Home")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Resource))]
        public IActionResult Index()
        {
            var resource = new Resource
            {
                Title = "Home",
                HRef = "/",
                Links = new Link[]
                {
                    new Link {Rel = "cadastro", HRef = "/cadastro", Text = "Cadastro"},
                    new Link {Rel = "decisoes", HRef = "/decisoes", Text = "Decisões"}
                }
            };

            return Ok(resource);
        }

        [HttpGet("cadastro")]
        public IActionResult GetCadastro()
        {
            var resource = new Resource
            {
                Title = "Cadastro",
                HRef = "/cadastro",
                Links = new Link[]
                {
                    new Link {Rel = "modelos", HRef = "/cadastro/modelos", Text = "Modelos"}
                }
            };

            return Ok(resource);
        }

        [HttpGet("decisoes")]
        public IActionResult GetDecisoes()
        {
            var resource = new Resource
            {
                Title = "Decisões",
                HRef = "/decisoes",
                Links = new Link[]
                {
                    new Link {Rel = "comerciais", HRef = "/decisoes/comerciais", Text = "Comerciais"}
                }
            };

            return Ok(resource);
        }
    }
}
