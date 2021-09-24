using System;
using Eem.App;
using Microsoft.AspNetCore.Mvc;

namespace madura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;

        }

        [HttpPost]
        [Route("/api/users")]
        public decimal Users([FromBody] Perfil perfil)
        {
            decimal t = _repository.getUsersPercentage(perfil);
            return t;
        }
    }
}
