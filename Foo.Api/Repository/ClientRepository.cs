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
            if (name.Equals("john doe", StringComparison.CurrentCultureIgnoreCase))
            {
                return new Client(1, "John Doe");
            }
            return null;
        }
    }
}