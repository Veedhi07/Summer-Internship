using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Services.IServices;

namespace Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMissionController(IMissionService missionService) : ControllerBase
    {
        private readonly IMissionService _missionService = missionService;

        [HttpGet]
        [Route("ClientSideMissionList/{userId:int}")] 
        public async Task<IActionResult> ClientSideMissionList(int userId)
        {
            try
            {
                var missions = await _missionService.ClientSideMissionList(userId);
                return Ok(new ResponseResult { Data = missions, Message = string.Empty, Result = ResponseStatus.Success });
            }
            catch
            {
                return BadRequest(new ResponseResult { Data = null, Message = "Error in fetching missions for user.", Result = ResponseStatus.Error });
            }
        }

        [HttpPost]
        [Route("ApplyMission")]
        public async Task<IActionResult> ApplyMission(AddMissionApplicationRequestModel model)
        {
            try
            {
                var ret = await _missionService.ApplyMission(model);
                return Ok(new ResponseResult() { Data = ret, Message = string.Empty, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult() { Data = null, Message = ex.Message, Result = ResponseStatus.Error });
            }
        }
    }
}
