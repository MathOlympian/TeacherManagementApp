using System;
using Microsoft.AspNetCore.Mvc;
using NzzTeacherManagement.Data;
using System.Linq;
using System.Threading.Tasks;
using NzzTeacherManagement.Models;

namespace NzzTeacherManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PupilController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Action Methods
        [HttpGet]
        public IActionResult GetPupils()
        {
            return Ok(_db.Pupils.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddPupil([FromBody] Pupil objPupil)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error While Creating New Pupil");
            }

            _db.Pupils.Add(objPupil);
            await _db.SaveChangesAsync();

            return new JsonResult("Pupil Created Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePupil([FromRoute] int id, [FromBody] Pupil objPupil)
        {
            if (objPupil == null || id != objPupil.id)
            {
                return new JsonResult("Pupil was not found");
            }
            else
            {
                _db.Update(objPupil);
                await _db.SaveChangesAsync();
                return new JsonResult("Pupil was updated successfully");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePupil([FromRoute] int id) 
        {
            var findPupil = await _db.Pupils.FindAsync(id);
            if(findPupil == null) 
            {
                return NotFound();
            }
            else 
            {
                _db.Pupils.Remove(findPupil);
                await _db.SaveChangesAsync();
                return new JsonResult("Pupil was deleted successfully");
            }
        }
    }
}
