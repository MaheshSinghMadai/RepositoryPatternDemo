using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult GetAllDevelopers([FromQuery] int count)
        {
            var popularDevs = _unitOfWork.Developers.GetPopularDevelopers(count);

            return Ok(popularDevs);
        }

        [HttpPost]
        public IActionResult AddDeveloperAndProject()
        {
            //Add new developer data
            var dev = new Developer
            {
                Name = "Mahesh Singh Madai",
                Followers = 2300
            };

            //Add new projects data
            var pj = new Project
            {
                Name = "RepositoryPattern",
            };

            _unitOfWork.Developers.Add(dev);
            _unitOfWork.Projects.Add(pj);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
