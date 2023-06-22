using MusicPlayer.DataLayer.Data;
using MusicPlayer.DataLayer.Entities;
using MusicPlayer.ServiceLayer.Services.Interfaces;

namespace MusicPlayer.ServiceLayer.Services
{
    public class ClientsService : IClientsService
    {
        private readonly MusicPlayerContext _context;

        public ClientsService(MusicPlayerContext context)
        {
            _context = context;
        }

        public async Task CreateClient(Client client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(int id)
        {
            var client = _context.Clients.FirstOrDefault(s => s.Id == id) ?? throw new NullReferenceException($"Client with id {id} not found.");

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            var client = _context.Clients.FirstOrDefault(s => s.Id == id) ?? throw new NullReferenceException($"Client with id {id} not found.");

            return client;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return _context.Clients.AsEnumerable();
        }

        public async Task UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
