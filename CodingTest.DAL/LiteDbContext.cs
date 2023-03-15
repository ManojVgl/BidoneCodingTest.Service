using BidoneCodingTest.Domain.Appsettings;
using LiteDB;
using Microsoft.Extensions.Options;

namespace CodingTest.DAL
{
    public class LiteDbContext: ILiteDbContext
    {
        public LiteDatabase Database { get; }

        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
        }
    }
}
