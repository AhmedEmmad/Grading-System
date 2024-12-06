using GradingSystem.Core.Entities;
using GradingSystem.Core.Repositories.Contact;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystem.APIs.Controllers
{
    public class AdminsController : BaseAPIController
    {
        private readonly IGenericRepository<Admin> _adminsRepo;

        public AdminsController(IGenericRepository<Admin> adminsRepo)
        {
            _adminsRepo = adminsRepo;
        }

        // /api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            var admins = await _adminsRepo.GetAllAsync();


            //JsonResult result = new JsonResult(admins);
            //result.StatusCode = 200;

            //ObjectResult result = new ObjectResult(admins);

            return Ok(admins);
        }
        #region Result Patterns
        //public Result<Admin> GetAdmins()
        //{
        //    var admins = _adminsRepo.GetAllAsync();

        //    //JsonResult result = new JsonResult(admins);
        //    //result.StatusCode = 200;

        //    //ObjectResult result = new ObjectResult(admins);

        //    //return Ok(admins);
        //    return Result<Admin>.Success(admins);
        //} 
        #endregion

        // api/Admins/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdminById(int id)
        {
            var admin = await _adminsRepo.GetAsync(id);

            if(admin is null)
                return NotFound(new {Message = "Not Found", StatusCode = 404}); // 404

            return Ok(admin); // 200
        }
    }
}
