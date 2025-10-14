using Foo.Api.Domain;

namespace Foo.Api.Repository
{
    public interface IClientRepository
    {
        Client? GetByName(string name);
    }
    
    public class ClientRepository : IClientRepository
    {
        public Client? GetByName(string name)
        {
            if (name.Equals("john", StringComparison.CurrentCultureIgnoreCase))
            {
                return new Client
                {
                    Id = 1,
                    Name = "John Doe"
                };
            }
            
            return null;
        }
    }
}