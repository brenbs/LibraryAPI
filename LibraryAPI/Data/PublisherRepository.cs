using LibraryAPI.Data.Interfaces;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly DataContext _context;
        public PublisherRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Publisher> Add(Publisher publisher)
        {
            _context.Add(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        public async Task Update(Publisher publisher)
        {
            _context.Update(publisher);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Publisher publisher)
        {
            _context.Remove(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Publisher>> GetAllPublishers()
        {
            return await _context.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetPublisherById(int publisherId)
        {
            return await _context.Publishers.FirstOrDefaultAsync(p => p.Id == publisherId);
        }

        public async Task<Publisher> GetPublisherByName(string publisherName)
        {
            return await _context.Publishers.FirstOrDefaultAsync(p => p.Name == publisherName);
        }

        // toda vez q usar get pra listar  por return await _context.entidades 
        // get all->ToListAsync
    }
}