using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Services.IServices;

namespace Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController(IMissionService missionService) : ControllerBase
    {
        private readonly IMissionService _missionService = missionService;

        [HttpPost]
        [Route("AddMission")]
        public IActionResult AddMission(MissionRequestViewModel model)
        {
            var response = _missionService.AddMission(model);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpPut]
        [Route("UpdateMission")]
        public async Task<IActionResult> UpdateMission(MissionRequestViewModel model)
        {
            var response = await _missionService.UpdateMission(model);
            return Ok(new ResponseResult()
            {
                Data = response,
                Result = ResponseStatus.Success,
                Message = response ? "Mission updated successfully" : "Failed to update mission"
            });
        }

        [HttpDelete]
        [Route("DeleteMission/{id:int}")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var response = await _missionService.DeleteMission(id);
            return Ok(new ResponseResult()
            {
                Data = response,
                Result = ResponseStatus.Success,
                Message = response ? "Mission deleted successfully" : "Failed to delete mission"
            });
        }

        [HttpGet]
        [Route("MissionList")]
        public async Task<IActionResult> GetAllMissionAsync()
        {
            var response = await _missionService.GetAllMissionAsync();
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpGet]
        [Route("MissionDetailById/{id:int}")]
        public async Task<IActionResult> GetMissionById(int id)
        {
            var response = await _missionService.GetMissionById(id);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpGet]
        [Route("MissionApplicationList")]
        public IActionResult MissionApplicationList()
        {
            var response = _missionService.GetMissionApplicationList();
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }


        [HttpPost]
        [Route("MissionApplicationApprove")]
        public async Task<IActionResult> MissionApplicationApprove([FromBody] UpdateMissionApplicationModel missionApp)
        {
            try
            {
                var ret = await _missionService.MissionApplicationApprove(missionApp);
                return Ok(new ResponseResult() { Data = ret, Message = string.Empty, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult() { Data = null, Message = ex.Message, Result = ResponseStatus.Error });
            }
        }

        [HttpPost]
        [Route("MissionApplicationDelete")]
        public async Task<IActionResult> MissionApplicationDelete(DeleteMissionApplicationModel model)
        {
            try
            {
                if (model?.ApplicationId == null || model.ApplicationId <= 0)
                {
                    return BadRequest(new ResponseResult()
                    {
                        Data = null,
                        Message = "Invalid application ID",
                        Result = ResponseStatus.Error
                    });
                }

                var response = await _missionService.DeleteMissionApplication(model.ApplicationId);

                if (response)
                {
                    return Ok(new ResponseResult()
                    {
                        Data = response,
                        Message = "Mission application deleted successfully",
                        Result = ResponseStatus.Success
                    });
                }
                else
                {
                    return NotFound(new ResponseResult()
                    {
                        Data = null,
                        Message = "Mission application not found or already deleted",
                        Result = ResponseStatus.Error
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult()
                {
                    Data = null,
                    Message = ex.Message,
                    Result = ResponseStatus.Error
                });
            }
        }
    }
}

