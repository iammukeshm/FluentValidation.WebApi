using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExternalModels.Library;
using FluentValidation.Results;
using FluentValidation.WebApi.Models;
using FluentValidation.WebApi.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(Developer developer)
        {
            DeveloperValidator validator = new DeveloperValidator();
            List<string> ValidationMessages = new List<string>();
            var validationResult = validator.Validate(developer);
            var response = new ResponseModel();
            if(!validationResult.IsValid)
            {
                response.IsValid = false;
                foreach(ValidationFailure failure in validationResult.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
                
            }
            return Ok(response);
        }
    }
}