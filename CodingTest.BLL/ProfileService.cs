using BidoneCodingTest.Domain.TestModel;
using CodingTest.DAL;

namespace CodingTest.BLL
{
    public class ProfileService : IlightDBProfileService
    {
        private readonly ProfileRepository _profileRepository;
        public ProfileService(ProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public IEnumerable<Profile> FindAll()
        {
            return _profileRepository.FindAll();
        }

        public Profile FindOne(string name)
        {
            return _profileRepository.FindOne(name);
        }

        public string Insert(Profile profile)
        {
            return _profileRepository.Insert(profile);
        }

        public bool Update(Profile profile)
        {
            return _profileRepository.Update(profile);
        }
    }
}