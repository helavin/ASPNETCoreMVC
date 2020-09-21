using DataLayer.Entities;

using Microsoft.EntityFrameworkCore;
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
                context.Directories.Add(new Directory() { Title = "First Directory", Html = "<b>Directory Content1</b>" });
                context.Directories.Add(new Directory() { Title = "Second Directory", Html = "<b>Directory Content2</b>" });
                context.Directories.Add(new Directory() { Title = "Third Directory", Html = "<b>Directory Content3</b>" });
                context.SaveChanges();
            }

            if (!context.Materials.Any())
            {
                var dirs = context.Directories.AsEnumerable();

                context.Materials.Add(new Material() { Title = "First Material", Html = "<b>Material Content1</b>", DirectoryId = dirs.First().Id });
                context.Materials.Add(new Material() { Title = "Second Material", Html = "<b>Material Content2</b>", DirectoryId = dirs.ElementAt(1).Id });
                context.Materials.Add(new Material() { Title = "Third Material", Html = "<b>Material Content3</b>", DirectoryId = dirs.Last().Id });
                context.SaveChanges();
            }


        }
    }
}
