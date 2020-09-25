using DataLayer.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IDirectoryRepository
    {
        IEnumerable<Directory> GetDirectories(bool includeMaterials = false);
        Directory GetDirectoryById(int id, bool includeMaterials = false);
        void SaveDirectory(Directory directory);
        void DeleteDirectory(Directory directory);
    }
}
