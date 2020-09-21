using Microsoft.EntityFrameworkCore.Internal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Directories.Any())
            {
                context.Directories.Add(new Entities.Directory() { Title = "First Directory", Html = "<b>Directory Content1</b>" });
                context.Directories.Add(new Entities.Directory() { Title = "Second Directory", Html = "<b>Directory Content2</b>" });
                context.Directories.Add(new Entities.Directory() { Title = "Third Directory", Html = "<b>Directory Content3</b>" });
                context.SaveChanges();
            }

            if (!context.Materials.Any())
            {
                context.Materials.Add(new Entities.Material() { Title = "First Material", Html = "<b>Material Content1</b>", DirectoryId = context.Directories.First().Id });
                context.Materials.Add(new Entities.Material() { Title = "Second Material", Html = "<b>Material Content2</b>", DirectoryId = context.Directories.ElementAt(1).Id });
                context.Materials.Add(new Entities.Material() { Title = "Third Material", Html = "<b>Material Content3</b>", DirectoryId = context.Directories.Last().Id });
                context.SaveChanges();
            }
        }
    }
}
