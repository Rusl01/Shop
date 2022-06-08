using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategory
        {
            get
            {
                return new List<Category> {
                new Category{CategoryName = "Электромобиль", Desc="За ними будщее"},
                new Category { CategoryName = "ДВС", Desc = "Старая школа" }
                };
            }
        }
    }
}
