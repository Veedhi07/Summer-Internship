using Mission.Entities;
using Mission.Entities.Models;

namespace Mission.Repositories.IRepositories
{
    public interface IMissionRepository
    {
        Task<List<MissionRequestViewModel>> GetAllMissionAsync();
        Task<MissionRequestViewModel?> GetMissionById(int id);
        Task<bool> AddMission(Missions mission);
        Task<bool> UpdateMission(Missions mission);
        Task<bool> DeleteMission(int id);
    
        Task<IList<Missions>> ClientSideMissionList();
        Task<bool> ApplyMission(AddMissionApplicationRequestModel model);

        // Enhanced method to get mission application details with related data
        Task<List<MissionApplicationDetailModel>> GetMissionApplicationListWithDetails();

        // Keep existing method for backward compatibility
        //List<MissionApplication> GetMissionApplicationList();
        List<MissionApplicationDetailModel> GetMissionApplicationList();

        Task<bool> MissionApplicationApprove(UpdateMissionApplicationModel missionApplication);
        Task<bool> DeleteMissionApplication(int applicationId);
    }
}
