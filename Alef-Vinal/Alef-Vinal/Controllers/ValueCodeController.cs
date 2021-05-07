using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Alef_Vinal.Services.Attribute;
using Alef_Vinal.Services.DTOs;
using Alef_Vinal.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Alef_Vinal.Controllers
{
    [Route("api/valueCode")]
    [ApiController]
    public class ValueCodeController : ControllerBase
    {
        #region Private members

        private readonly ICodeService codeService;

        #endregion

        public ValueCodeController(ICodeService codeService)
        {
            this.codeService = codeService;
        }

        // GET: api/valueCode
        [HttpGet]
        public IActionResult GetCodes()
        {
            try
            {
                return Ok(codeService.GetAll());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/valueCode/555
        [HttpGet("{code}")]
        public IActionResult GetCode(int code)
        {
            try
            {
                var codeR = codeService.GetByCode(code);

                if (codeR == null)
                {
                    return NotFound();
                }

                return Ok(codeR);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/valueCode
        [HttpPost]
        public IActionResult CreateCode([FromBody] ValueCodeDto valueCodeDto)
        {
            try
            {
                codeService.Create(valueCodeDto);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PATCH: api/valueCode/1
        [Cookie]
        [HttpPatch("{id}")]
        public IActionResult UpdateCode(int id, [FromBody] JsonPatchDocument<ValueCodeDto> valueCodeDto)
        {
            try
            {
                codeService.Update(id, valueCodeDto);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
