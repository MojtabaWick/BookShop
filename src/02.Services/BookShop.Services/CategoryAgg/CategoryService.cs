using BookShop.Domain._common;
using BookShop.Domain.CategoryAgg.Contracts;
using BookShop.Domain.CategoryAgg.Dtos;
using BookShop.Domain.FileAgg.Contracts;

namespace BookShop.Services.CategoryAgg
{
    public class CategoryService(ICategoryRepository _categoryRepository, IFileService _fileService) : ICategoryService
    {
        public List<CategorySummeryDto> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public void Create(string title)
        {
            _categoryRepository.Create(title);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }
        public UpdateGetCategoryDto GetUpdateCategoryDetails(int categoryId)
        {
            var category = _categoryRepository.GetUpdateCategoryDetails(categoryId);
            return category;
        }
        public Result<bool> Update(int categoryId, UpdateGetCategoryDto model)
        {
            if (model.Img is not null)
            {
                model.ImgAddress = _fileService.Upload(model.Img);
            }

            var result = _categoryRepository.Update(categoryId, model);

            if (result)
            {
                return Result<bool>.Success("اطلاعات دسته بندی با موفقیت به‌روزرسانی شد.");
            }
            else
            {
                return Result<bool>.Failure("به‌روزرسانی اطلاعات دسته بندی با خطا مواجه شد.");
            }
        }
    }
}
