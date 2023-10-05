using LibraryAPI.Data.Interfaces;
using LibraryAPI.Migrations;
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

        public void Add<T>(T enity) where T : class
        {
            _context.Add(enity);
        }

        public void Update<T>(T enity) where T : class
        {
            _context.Update(enity);
        }

        public void Delete<T>(T enity) where T : class
        {
            _context.Remove(enity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Publisher[] GetAllPublishers()
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking().OrderBy(u => u.Id); //pega os usuarios e ordena por id
            return query.ToArray();
        }

        public Publisher[] GetPublishersById(int PublisherId)
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking().OrderBy(u => u.Id).Where(Publisher => Publisher.Id == PublisherId);

            //return query.FirstOrDefault();
            return query.ToArray();
        }
    }
}
