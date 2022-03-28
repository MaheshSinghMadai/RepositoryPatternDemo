using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EFCore
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationDbContext db) : base(db)
        {
        }
        public IEnumerable<Developer> GetPopularDevelopers(int count)
        {
            return _db.Developers.OrderByDescending(d => d.Followers).Take(count).ToList();
        }
    }
}
