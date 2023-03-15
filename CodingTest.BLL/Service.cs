using BidoneCodingTest.Domain.Appsettings;
using CodingTest.DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CodingTest.BLL
{
    public class Services<T> : IServices<T>
    {
        private readonly AppSettings _appsettings;
        private readonly IOptions<LiteDbOptions> _options;
        public Services(AppSettings appsettings, IOptions<LiteDbOptions> options)
        {
            _appsettings = appsettings;
            _options = options;

        }

        public T Service  
        {
            get
            {
                var serviceProvider = new ServiceCollection()
                    .AddSingleton(typeof(ProfileRepository))
                     .AddSingleton(_options)
                      .AddSingleton(_appsettings)
                    .AddSingleton(typeof(ILiteDbContext ), typeof(LiteDbContext))
                
                    .AddSingleton(typeof(T))
                    .BuildServiceProvider();
                return (T)Convert.ChangeType(serviceProvider
                    .GetService<T>(), typeof(T));
            }

        }
    }
}
