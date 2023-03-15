using BidoneCodingTest.Domain.TestModel;
using LiteDB;

namespace CodingTest.DAL
{
    public class ProfileRepository:IProfileRepository
    {
        private LiteDatabase _liteDb;

        public ProfileRepository(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        public IEnumerable<Profile> FindAll()
        {
            return _liteDb.GetCollection<Profile>("Api")
                .FindAll();
        }

        public Profile FindOne(string id)
        {
            return _liteDb.GetCollection<Profile>("Api")
                .Find(x => x.FirstName == id).FirstOrDefault();
        }

        public string Insert(Profile profile)
        {
            return _liteDb.GetCollection<Profile>("Api")
                .Insert(profile).ToString();
        }

        public bool Update(Profile profile)
        {
            return _liteDb.GetCollection<Profile>("Api")
                .Update(profile);
        }

        //public int Delete(string name)
        //    {
        //        return _liteDb.GetCollection<Profile>("Api")
        //            .Delete(x => x.FirstName==name);
        //    }
        //}
    }
}
