using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestAPI.Models;
using TestAPI.Repository;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly UserRepository _repository;


        public UserController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<User> ListUsers()
        {
            return _repository.All();
        }
    }
}
