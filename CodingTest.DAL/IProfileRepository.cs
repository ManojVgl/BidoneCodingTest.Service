using BidoneCodingTest.Domain.TestModel;

namespace CodingTest.DAL
{
    public interface IProfileRepository
    {
        //int Delete(string name);
        IEnumerable<Profile> FindAll();
        Profile FindOne(string name);
        string Insert(Profile profile);
        bool Update(Profile profile);
    }
}
