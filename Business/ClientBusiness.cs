using Tourism.Client.Data;
using Tourism.Client.Models;

namespace Tourism.Client.Business
{

    public class ClientBusiness: IClientBusiness
    {
        private readonly IClientData _clientData;

        public ClientBusiness(IClientData clientData)
        {
            _clientData = clientData;
        }

        public List<Ent_Client> GetClients()
        {
           return _clientData.Get_listClient();
        }
    }
}
