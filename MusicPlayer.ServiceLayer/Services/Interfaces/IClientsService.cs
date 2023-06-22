using MusicPlayer.DataLayer.Entities;

namespace MusicPlayer.ServiceLayer.Services.Interfaces
{
    public interface IClientsService
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientById(int id);
        Task CreateClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(int id);
    }
}
