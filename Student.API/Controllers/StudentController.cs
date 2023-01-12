using Student.DTO;
using Student.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _IStudentService = null;
        public StudentController(IStudentService StudentService)
        {
            _IStudentService = StudentService;
        }

        /// <summary>
        /// Student list end point
        /// </summary>
        /// <returns>list all records</returns>
        [HttpGet("List")]
        [ProducesResponseType(typeof(ResponseObject), 200)]
        public async Task<IActionResult> StudentsList()
        {
            try
            {
                var result = await this._IStudentService.List();

                return this.Ok(new ResponseObject()
                {
                    Data = result,
                });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new ResponseObject()
                {
                    ErrorDescription = ex.Message,
                });
            }
        }



        /// <summary>
        /// Select Student record
        /// </summary>
        /// <param name="id">primary key of the record</param>
        /// <returns></returns>
        [HttpGet("Select/{id}")]
        [ProducesResponseType(typeof(ResponseObject), 200)]
        public async Task<IActionResult> Select(int id)
        {
            try
            {
                var result = await this._IStudentService.Select(id);

                return this.Ok(new ResponseObject()
                {
                    Data = result,
                });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new ResponseObject()
                {
                    ErrorDescription = ex.Message,
                });
            }
        }



        /// <summary>
        /// Add a Student         /// </summary>
        /// <param name="oStudentDTO"></param>
        /// <returns>Successfully added record</returns>
        [HttpPost("Add")]
        [ProducesResponseType(typeof(ResponseObject), 200)]
        public async Task<IActionResult> Add(StudentDTO oStudentDTO)
        {
            try
            {
                var result = await this._IStudentService.Add(oStudentDTO);

                return this.Ok(new ResponseObject()
                {
                    Data = result,
                });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new ResponseObject()
                {
                    ErrorDescription = ex.Message,
                });
            }
        }


        /// <summary>
        /// Edit a Student
        /// </summary>
        /// <param name="oStudentDTO"></param>
        /// <returns>Successfully edited record</returns>
        [HttpPut("Edit")]
        [ProducesResponseType(typeof(ResponseObject), 200)]
        public async Task<IActionResult> Edit(StudentDTO oStudentDTO)
        {
            try
            {
                var result = await this._IStudentService.Edit(oStudentDTO);

                return this.Ok(new ResponseObject()
                {
                    Data = result,
                });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new ResponseObject()
                {
                    ErrorDescription = ex.Message,
                });
            }
        }


        /// <summary>
        /// Delete a Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns>status</returns>
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(ResponseObject), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this._IStudentService.Delete(id);

                return this.Ok(new ResponseObject()
                {
                    Data = result,
                });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new ResponseObject()
                {
                    ErrorDescription = ex.Message,
                });
            }
        }
    }
}
