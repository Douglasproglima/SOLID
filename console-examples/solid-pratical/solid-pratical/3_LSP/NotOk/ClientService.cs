using System.Collections.Generic;
using System.Linq;

namespace solid_pratical._3_LSP.NotOk
{
    public class ClientService
    {
        public IEnumerable<Client> Clients = new List<Client>
        {
            new GodClient { TotalValue = 300 },
            new SilverClient { TotalValue = 200 }
        };

        public double GetSumValue()
        { 
            var values = Clients.Select(client => client.Discount()).Sum();
            return values;
        }
    }
}
