using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent _appDBContent)
        {
            appDBContent = _appDBContent;
        }

        public IEnumerable<Category> AllCategory => appDBContent.Category;
    }
}
