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
    public class EFMaterialRepository : IMaterialRepository
    {
        private EFDBContext context;
        public EFMaterialRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Material> GetMaterials(bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking().ToList();
            else
                return context.Materials.ToList();
        }

        public Material GetMaterialById(int id, bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directory)
                    .AsNoTracking().FirstOrDefault(x => x.Id == id);
            else
                return context.Materials.FirstOrDefault(x => x.Id == id);
        }

        public void SaveMaterial(Material material)
        {
            if (material.Id == 0)
                context.Materials.Add(material);
            else
                context.Entry(material).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteMaterial(Material material)
        {
            context.Materials.Remove(material);
            context.SaveChanges();
        }
    }
}
