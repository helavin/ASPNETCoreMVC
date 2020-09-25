using DataLayer.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetMaterials(bool includeDirectory = false);
        Material GetMaterialById(int id, bool includeDirectory = false);
        void SaveMaterial(Material material);
        void DeleteMaterial(Material material);
    }
}
