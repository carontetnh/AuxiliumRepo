using Auxilium.ViewModels;
namespace Auxilium.Data
{
    public interface IAuxRepository
    {
        bool SaveAll();
        void AddEntity(object model);
        EditProfileViewModel GetProfileForEdit(string userName);
    }
}