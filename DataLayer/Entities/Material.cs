using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Material : Page
    {
        public int DirectoryId { get; set; } // внешний ключ
        public Directory Directory { get; set; } // навигационное свойство
    }
}
