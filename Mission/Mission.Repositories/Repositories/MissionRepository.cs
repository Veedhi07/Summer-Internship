using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Context;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;

namespace Mission.Repositories.Repositories
{
    public class MissionRepository(MissionDbContext dbContext) : IMissionRepository
    {
        private readonly MissionDbContext _dbContext = dbContext;

        public Task<List<MissionRequestViewModel>> GetAllMissionAsync()
        {
            return _dbContext.Missions.Where(m => m.IsDeleted ==false).Select(m => new MissionRequestViewModel()
            {
                Id = m.Id,
                CityId = m.CityId,
                CountryId = m.CountryId,
                EndDate = m.EndDate,
                MissionDescription = m.MissionDescription,
                MissionImages = m.MissionImages,
                MissionSkillId = m.MissionSkillId,
                MissionThemeId = m.MissionThemeId,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate,
                TotalSeats = m.TotalSheets ?? 0,
            }).ToListAsync();
        }

        public async Task<MissionRequestViewModel?> GetMissionById(int id)
        {
            return await _dbContext.Missions.Where(m => m.Id == id).Select(m => new MissionRequestViewModel()
            {
                Id = m.Id,
                CityId = m.CityId,
                CountryId = m.CountryId,
                EndDate = m.EndDate,
                MissionDescription = m.MissionDescription,
                MissionImages = m.MissionImages,
                MissionSkillId = m.MissionSkillId,
                MissionThemeId = m.MissionThemeId,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate,
                TotalSeats = m.TotalSheets ?? 0,
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> AddMission(Missions model)
        {
            try
            {
                var isExist = dbContext.Missions.Where(x =>
                            x.MissionTitle == model.MissionTitle
                            && x.StartDate == model.StartDate
                            && x.EndDate == model.EndDate
                            && x.CityId == model.CityId
                            && !x.IsDeleted
                        ).FirstOrDefault();

                if (isExist != null) throw new Exception("Mission already exist!");

                Missions missions = new Missions()
                {
                    MissionTitle = model.MissionTitle,
                    MissionDescription = model.MissionDescription,
                    MissionImages = model.MissionImages,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CountryId = model.CountryId,
                    CityId = model.CityId,
                    TotalSheets = model.TotalSheets,
                    MissionThemeId = model.MissionThemeId,
                    MissionSkillId = model.MissionSkillId,


                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                };
                await dbContext.Missions.AddAsync(missions);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        // Add these methods to the MissionRepository class if they don't exist

        public async Task<bool> UpdateMission(Missions mission)
        {
            try
            {
                var existingMission = await _dbContext.Missions.FindAsync(mission.Id);
                if (existingMission == null) return false;

                _dbContext.Entry(existingMission).CurrentValues.SetValues(mission);
                existingMission.ModifiedDate = DateTime.Now;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteMission(int id)
        {
            try
            {
                var mission = await _dbContext.Missions.FindAsync(id);
                if (mission == null) return false;

                mission.IsDeleted = true;
                mission.ModifiedDate = DateTime.Now;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        // int userId
        public async Task<IList<Missions>> ClientSideMissionList()
        {
            return await _dbContext.Missions
                .Include(m => m.City)
                .Include(m => m.Country)
                .Include(m => m.MissionTheme)
                .Include(m => m.MissionApplications)
                .Where(m => !m.IsDeleted)
                .OrderBy(m => m.CreatedDate)
                .ToListAsync();
        }

        public async Task<bool> ApplyMission(AddMissionApplicationRequestModel model)
        {
            try
            {
                var mission = _dbContext.Missions.Where(x => x.Id == model.MissionId).FirstOrDefault();

                if (mission == null) throw new Exception("Mission not found");

                var application = _dbContext.MissionApplications.Where(x => x.MissionId == model.MissionId && x.UserId == model.UserId).FirstOrDefault();

                if (application != null) throw new Exception("Already applied!");

                MissionApplication app = new MissionApplication()
                {
                    UserId = model.UserId,
                    MissionId = model.MissionId,
                    AppliedDate = model.AppliedDate,
                    Seats = model.Sheet,
                    Status = model.Status,

                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                };

                mission.TotalSheets -= model.Sheet;

                await _dbContext.MissionApplications.AddAsync(app);
                _dbContext.Missions.Update(mission);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public List<MissionApplication> GetMissionApplicationList()
        //{
        //    return _dbContext.MissionApplications.Where(x => !x.IsDeleted).ToList();
        //}
        public List<MissionApplicationDetailModel> GetMissionApplicationList()
        {
            return _dbContext.MissionApplications
                .Where(x => !x.IsDeleted)
                .Select(x => new MissionApplicationDetailModel
                {
                    ApplicationId = x.Id,
                    MissionTitle = x.Mission.MissionTitle,
                    MissionTheme = x.Mission.MissionTheme.ThemeName,
                    UserName = x.User.FirstName + " " + x.User.LastName,
                    ApplicationDate = x.AppliedDate,
                    Status = x.Status ? "Approved" : "Pending",

                    //// Optional fields
                    //MissionId = x.MissionId,
                    //UserId = x.UserId,
                    //AppliedDate = x.AppliedDate.ToString("yyyy-MM-dd"),
                    //UserEmail = x.User.Email,
                    //UserPhone = x.User.PhoneNumber,
                    //MissionDescription = x.Mission.MissionDescription,
                    //MissionStartDate = x.Mission.StartDate,
                    //MissionEndDate = x.Mission.EndDate,
                    //MissionLocation = x.Mission.City.Name + ", " + x.Mission.Country.Name
                })
                .ToList();
        }


        public async Task<bool> MissionApplicationApprove(UpdateMissionApplicationModel missionApplication)
        {
            var tMissionApp = _dbContext.MissionApplications.Where(x => x.Id == missionApplication.Id).FirstOrDefault();

            if (tMissionApp == null) throw new Exception("Mission application not found");

            tMissionApp.Status = true;
            tMissionApp.ModifiedDate = DateTime.Now;

            _dbContext.MissionApplications.Update(tMissionApp);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<MissionApplicationDetailModel>> GetMissionApplicationListWithDetails()
        {
            var applicationDetails = await _dbContext.MissionApplications
                .Include(ma => ma.Mission)
                .Include(ma => ma.User)
                .Select(ma => new MissionApplicationDetailModel
                {
                    ApplicationId = ma.Id,
                    MissionTitle = ma.Mission.MissionTitle,
                    MissionTheme = ma.Mission.MissionTheme.ThemeName,
                    UserName = ma.User.FirstName + " " + ma.User.LastName,
                    ApplicationDate = ma.AppliedDate,
                    Status = ma.Status ? "Approved" : "Pending",
                    MissionId = ma.MissionId,
                    UserId = ma.UserId,
                    AppliedDate = ma.AppliedDate.ToString("dd/MM/yyyy"),
                    ApprovalDate = ma.Status && ma.ModifiedDate.HasValue
                        ? ma.ModifiedDate.Value.ToString("dd/MM/yyyy")
                        : null, // Fixed line
                    UserEmail = ma.User.EmailAddress,
                    UserPhone = ma.User.PhoneNumber,
                    MissionDescription = ma.Mission.MissionDescription,
                    MissionStartDate = ma.Mission.StartDate,
                    MissionEndDate = ma.Mission.EndDate,
                    MissionLocation = ma.Mission.City.CityName + ", " + ma.Mission.Country.CountryName
                })
                .OrderByDescending(ma => ma.ApplicationDate)
                .ToListAsync();

            return applicationDetails;
        }


        public async Task<bool> DeleteMissionApplication(int applicationId)
        {
            try
            {
                var application = await _dbContext.MissionApplications
                    .Where(x => x.Id == applicationId && !x.IsDeleted)
                    .FirstOrDefaultAsync();

                if (application == null)
                {
                    return false; // Application not found
                }

                // Get the mission to restore seats
                var mission = await _dbContext.Missions
                    .Where(x => x.Id == application.MissionId)
                    .FirstOrDefaultAsync();

                if (mission != null)
                {
                    // Restore the seats back to mission
                    mission.TotalSheets += application.Seats;
                    _dbContext.Missions.Update(mission);
                }

                // Soft delete the application
                application.IsDeleted = true;
                application.ModifiedDate = DateTime.Now;

                _dbContext.MissionApplications.Update(application);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception if you have logging
                throw;
            }
        }
    }
}
