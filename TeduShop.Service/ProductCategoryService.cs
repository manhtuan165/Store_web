using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory ProductCategory);

        void Update(ProductCategory ProductCategory);

        ProductCategory Delete(int id);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAll(string keyword);

        IEnumerable<ProductCategory> GetAllByParentId(int parentId);

        ProductCategory GetById(int id);

        void Save();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository _ProductCategorRepository;
        IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository ProductCategory, IUnitOfWork unitOfWork)
        {
            this._ProductCategorRepository = ProductCategory;
            this._unitOfWork = unitOfWork;
        }



        public ProductCategory Add(ProductCategory ProductCategory)
        {
            return _ProductCategorRepository.Add(ProductCategory);
        }

        public void Update(ProductCategory ProductCategory)
        {
            _ProductCategorRepository.Update(ProductCategory);
        }

        public ProductCategory Delete(int id)
        {
            return _ProductCategorRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _ProductCategorRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _ProductCategorRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _ProductCategorRepository.GetAll();
            }
        }
        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _ProductCategorRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public ProductCategory GetById(int id)
        {
            return _ProductCategorRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }


    }
}
