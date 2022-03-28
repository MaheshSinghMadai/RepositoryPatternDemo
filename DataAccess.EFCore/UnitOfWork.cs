using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Developers = new DeveloperRepository(_db);
            Projects = new ProjectRepository(_db);

        }

        public IDeveloperRepository Developers { get; private set; }

        public IProjectRepository Projects { get; private set; }

        public int Complete()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            //releases the allocated resources
            _db.Dispose();
        }
    }
}
