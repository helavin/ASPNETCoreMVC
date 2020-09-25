using BusinessLayer.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class DataManager
    {
        private IDirectoryRepository _directoryRepository;
        private IMaterialRepository _materialRepository;

        public DataManager(IDirectoryRepository directory, IMaterialRepository material)
        {
            this._directoryRepository = directory;
            this._materialRepository = material;
        }

        public IDirectoryRepository DirectoryRepository { get { return this._directoryRepository; } }
        public IMaterialRepository MaterialRepository { get { return this._materialRepository; } }
    }
}
