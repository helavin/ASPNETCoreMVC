using BusinessLayer;

using DataLayer.Entities;

using PresentationLayer.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Services
{
    public class MaterialService
    {
        private DataManager _dataManager;

        public MaterialService(DataManager manager)
        {
            this._dataManager = manager;
        }

        public MaterialViewModel GetMaterialViewModel(int id)
        {
            var _materialViewModel = new MaterialViewModel()
            {
                Material = _dataManager.MaterialRepository.GetMaterialById(id)
            };

            var _dbDirectory = _dataManager.DirectoryRepository.GetDirectoryById(_materialViewModel.Material.DirectoryId, true);
            var material = _dbDirectory.Materials.FirstOrDefault(x => x.Id == _materialViewModel.Material.Id);
            var current = _dbDirectory.Materials.IndexOf(material);
            if (current != _dbDirectory.Materials.Count() - 1)
            {
                var next = current + 1;
                _materialViewModel.NextMaterial = _dbDirectory.Materials.ElementAt(next);
            }

            return _materialViewModel;
        }

        public MaterialEditModel GetMaterialEditModel(int id)
        {
            if (id == 0)
                return new MaterialEditModel() { };

            var _dbMaterial = _dataManager.MaterialRepository.GetMaterialById(id);
            var _materialEditModel = new MaterialEditModel()
            {
                Id = _dbMaterial.Id,
                DirectoryId = _dbMaterial.DirectoryId,
                Title = _dbMaterial.Title,
                Html = _dbMaterial.Html
            };
            return _materialEditModel;
        }

        public MaterialViewModel SaveMaterialEditModelToDb(MaterialEditModel materialEditModel)
        {
            Material material;
            if (materialEditModel.Id != 0)
            {
                material = _dataManager.MaterialRepository.GetMaterialById(materialEditModel.Id);
            }
            else
            {
                material = new Material();
            }
            material.Title = materialEditModel.Title;
            material.Html = materialEditModel.Html;
            material.DirectoryId = materialEditModel.DirectoryId;

            _dataManager.MaterialRepository.SaveMaterial(material);

            return GetMaterialViewModel(material.Id);
        }
        public MaterialEditModel CreateNewMaterialEditModel(int directoryId)
        {
            return new MaterialEditModel() { DirectoryId = directoryId };
        }
    }
}
