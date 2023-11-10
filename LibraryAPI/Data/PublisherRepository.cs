using LibraryAPI.Data.Interfaces;
using LibraryAPI.FiltersDb;
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

        public async Task<PagedBaseResponse<Publisher>> GetPagedAsync(FilterDb request)
        {
            var publisher = _context.Publishers.AsQueryable();
            if (!string.IsNullOrEmpty(request.SearchValue))
            {
              var ignore = request.SearchValue.ToLower();
                            publisher = publisher.Where(x => x.Name.ToLower().Contains(request.SearchValue)||
                            x.City.ToLower().Contains(ignore)||
                            x.Id.ToString().Contains(ignore));
            }
             
            return await PagedBaseResponseHelper
                .GetResponseAsync<PagedBaseResponse<Publisher>, Publisher>(publisher, request);
        }
    }
}