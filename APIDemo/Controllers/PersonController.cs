using APIDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        List<Person> people = new List<Person>();

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
            for (int i = 0; i < 10; i++)
            {
                people.Add(new Person { PersonId = i + 1, LastName = "Torrico", FirstName = "Hugo" });
            }

        }

        [HttpGet]
        public List<Person> Get()
        {

            //Podrías ir a la base de datos                   
            return people;
        }

        [HttpGet]//Verbo GET/POST/PUT/DELETE/PATCH
        public Person GetById(int PersonId)
        {

            var person = people.Where(x => x.PersonId == PersonId).FirstOrDefault();        
            return person;
        }

    }
}
