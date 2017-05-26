using ExemploWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExemploWebApi.Controllers
{
    public class HeroisController : ApiController
    {
        public IEnumerable<Heroi> Get(string nome = null, int? id = null)
        {
            var herois = new List<Heroi>()
            {
                new Heroi()
                {
                    Id = 1,
                    Nome = "Goku",
                    Poder = new Poder()
                    {
                        Nome = "Genki Dama",
                        Dano = 8000
                    }
                },
                new Heroi() { Id = 2, Nome = "Luffy", Poder = new Poder() { Nome = "Gear Third", Dano = 7000 } },
                new Heroi() { Id = 3, Nome = "Ryu", Poder = new Poder() { Nome = "Hadouken", Dano = 9000 } },
                new Heroi() { Id = 4, Nome = "Uchiha Madara", Poder = new Poder() { Nome = "Susano", Dano = 6000 } }
            };

            return herois.Where(x => 
                (id == null || x.Id == id) &&
                (nome == null || x.Nome == nome)
            );
        }

        public IHttpActionResult Post(Heroi heroi)
        {
            if (heroi.Id == 0)
            {
                //Salva no banco de dados :)
                heroi.Id = 99;

                return Ok(heroi);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
