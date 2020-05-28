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
    public class TesterController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            TesterValidator validator = new TesterValidator();
            List<string> ValidationMessages = new List<string>();
            var tester = new Tester
            {
                FirstName = "",
                Email = "bla!"
            };
            var validationResult = validator.Validate(tester);
            var response = new ResponseModel();
            if (!validationResult.IsValid)
            {
                response.IsValid = false;
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
                response.ValidationMessages = ValidationMessages;
            }
            return Ok(response);
        }
    }
}