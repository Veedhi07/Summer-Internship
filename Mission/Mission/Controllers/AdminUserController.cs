using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Services;
using Mission.Services.IServices;

namespace Mission.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminUserController(IAdminUserService _adminUserService) : Controller
    {
        [HttpGet]
        [Route("UserDetailList")]
        public ActionResult UserDetailList()
        {
            try
            {
                var res = _adminUserService.UserDetailsList();
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to get user list" });
            }
        }

        [HttpDelete("DeleteUser/{id:int}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var res = _adminUserService.UserDelete(id);
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to delete user" });
            }
        }

         
        [HttpPut("UpdateUser")]   //new
        public ActionResult UpdateUser([FromBody] UserDetails userDetails)
        {
            try
            {
                var res = _adminUserService.UpdateUser(userDetails);
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult()
                {
                    Data = null,
                    Result = ResponseStatus.Error,
                    Message = $"Failed to update user: {ex.Message}"
                });
            }
        }

    }
}
