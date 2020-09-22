using BusinessLayer.Interfaces;

using DataLayer;
using DataLayer.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class EFDirectoryRepository : IDirectoryRepository
    {
        EFDBContext context;
        public EFDirectoryRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Directory> GetDirectories(bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().ToList();
            else
                return context.Directories.ToList();

        }

        public Directory GetDirectoryByID(int id, bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directory>().Include(x => x.Materials)
                    .AsNoTracking().FirstOrDefault(x => x.Id == id);
            else
                return context.Directories.FirstOrDefault(x => x.Id == id);
        }

        public void SaveDirectory(Directory directory)
        {
            if (directory.Id == 0)
                context.Directories.Add(directory);
            else
                context.Entry(directory).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteDirectory(Directory directory)
        {
            context.Directories.Remove(directory);
            context.SaveChanges();
        }
    }
}
