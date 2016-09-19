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
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        PostCategory Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetById(int id);

        void Save();
    }

    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategorRepository;
        IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategory, IUnitOfWork unitOfWork)
        {
            this._postCategorRepository = postCategory;
            this._unitOfWork = unitOfWork;
        }



        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategorRepository.Add(postCategory);
        }

        public void Update(PostCategory postCategory)
        {
            _postCategorRepository.Update(postCategory);
        }

        public PostCategory Delete(int id)
        {
            return _postCategorRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategorRepository.GetAll();
        }
         
        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCategorRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCategorRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
