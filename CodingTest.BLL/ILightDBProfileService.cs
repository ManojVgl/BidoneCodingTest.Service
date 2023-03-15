using BidoneCodingTest.Domain.TestModel;

namespace CodingTest.BLL
{
    public interface IlightDBProfileService
    {
        //int Delete(string name);
        IEnumerable<Profile> FindAll();
        Profile FindOne(string name);
        string Insert(Profile profile);
        bool Update(Profile profile);
    }
}
