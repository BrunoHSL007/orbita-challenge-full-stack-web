using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Repository;
using backend.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("v1")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("students")]
        public async Task<IActionResult> GetAsync([FromServices]Context context)
        {
            var students = await context
                .Student
                .AsNoTracking()
                .ToListAsync();
            return Ok(students);
        }
        [HttpGet]
        [Route("students/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices]Context context, [FromRoute] int id)
        {
            var student = await context
                .Student
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
                return NotFound();
            
            return Ok(student);
        }
        [HttpPost]
        [Route("students")]
        public async Task<IActionResult> PostAsync([FromServices]Context context, [FromBody]CreateStudentViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = new Student
            {
                Cpf = model.Cpf,
                Email = model.Email,
                Name = model.Name
            };

            try
            {
                await context.Student.AddAsync(student);
                await context.SaveChangesAsync();
                return Created($"v1/students/{student.Id}", student);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
        [HttpPut]
        [Route("students/{id}")]
        public async Task<IActionResult> PutAsync([FromServices]Context context, [FromBody]UpdateStudentViewModel model, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = await context.Student.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
                NotFound();
            
            try
            {
                student.Name = model.Name;
                student.Email = model.Email;
                
                context.Student.Update(student);
                await context.SaveChangesAsync();
                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
        [HttpDelete]
        [Route("students/{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices]Context context, [FromRoute]int id)
        {
            var student = await context.Student.FirstOrDefaultAsync(x => x.Id == id);
            
            try
            {
                context.Student.Remove(student);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
    }
}