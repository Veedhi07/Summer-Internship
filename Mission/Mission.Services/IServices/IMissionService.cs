using Mission.Entities.Models;
using Mission.Entities;

namespace Mission.Services.IServices
{
    public interface IMissionService
    {
        // Existing mission methods
        Task<List<MissionRequestViewModel>> GetAllMissionAsync();
        Task<MissionRequestViewModel?> GetMissionById(int id);
        Task<bool> AddMission(MissionRequestViewModel model);
        Task<bool> UpdateMission(MissionRequestViewModel model);
        Task<bool> DeleteMission(int id);

        // Client-side mission methods
        Task<IList<MissionDetailResponseModel>> ClientSideMissionList(int userId);

        // Mission application methods
        Task<bool> ApplyMission(AddMissionApplicationRequestModel model);
        //List<MissionApplication> GetMissionApplicationList();
        List<MissionApplicationDetailModel> GetMissionApplicationList();
        Task<bool> MissionApplicationApprove(UpdateMissionApplicationModel missionApplication);
        Task<bool> DeleteMissionApplication(int applicationId);
    }
}