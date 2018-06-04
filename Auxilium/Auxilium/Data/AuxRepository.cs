using Auxilium.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Auxilium.Data
{
    public class AuxRepository : IAuxRepository
    {
        private AuxContext _ctx;
        private ILogger _logger;

        public AuxRepository(AuxContext ctx, ILogger<AuxRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public EditProfileViewModel GetProfileForEdit(string userName)
        {
            var lowerUserName = userName.ToLowerInvariant();

            //var query = _ctx.Profile
            //    .Include("Demographics")
            //    .Include("Member")
            //    .Where(p => p.Member.UserName.ToLower() == lowerUserName)
            //    .Select(p => new EditProfileViewModel()
            //    {
            //        Id = p.Id,
            //        Pitch = p.Pitch,
            //        LookingFor = p.LookingFor,
            //        Introduction = p.Introduction,
            //        Birthdate = p.Demographics.Birthdate,
            //        Gender = p.Demographics.Gender,
            //        Orientation = p.Demographics.Orientation,
            //        MemberName = p.Member.MemberName
            //    });

            //var query = _ctx.Profile
            //    .Where(p => p.Member.UserName.ToLower() == lowerUserName)
            //    .Select(p => new EditProfileViewModel()
            //    {
            //        Id = p.Id,
            //        Pitch = p.Pitch,
            //        LookingFor = p.LookingFor,
            //        Introduction = p.Introduction,
            //        Birthdate = p.Demographics.Birthdate,
            //        Gender = p.Demographics.Gender,
            //        Orientation = p.Demographics.Orientation,
            //        MemberName = p.Member.MemberName
            //    });

            //return query.FirstOrDefault();
            return null;
        }

    public void AddEntity(object model)
        {
            try
            {
                _logger.LogInformation("AddEntity was called");
                _ctx.Add(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add entity:{ex}");
            }
        }

        public bool SaveAll()
        {
            try
            {
                _logger.LogInformation("SaveAll was called");
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save changes:{ex}");
                return false;
            }
        }
    }
}
