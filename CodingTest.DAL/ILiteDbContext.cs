using LiteDB;

namespace CodingTest.DAL
{
    public interface ILiteDbContext
    { 
        LiteDatabase Database { get; }
    }

}
