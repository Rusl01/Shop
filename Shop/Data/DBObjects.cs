using Shop.Data.Models;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
        //    AppDBContent content;
        //    using (var scope = app.ApplicationServices.CreateScope())
        //    {
        //        AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
        //    }
       
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c=> c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new car
                    {
                        Name = "Tesla Plaid",
                        ShortDesc = "Не машина,а игрушка",
                        LongDesc = "",
                        Img = "",
                        Price = 4500,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Электромобиль"]
                    },
                    new car
                    {
                        Name = "BMW m5",
                        ShortDesc = "Бешеная табуретка",
                        LongDesc = "",
                        Img = "",
                        Price = 5300,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["ДВС"]
                    },
                    new car
                    {
                        Name = "Ford Focus",
                        ShortDesc = "для семьи и для себя",
                        LongDesc = "",
                        Img = "",
                        Price = 3000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["ДВС"]
                    },
                    new car
                    {
                        Name = "BMW i3",
                        ShortDesc = "Что-то из будущего",
                        LongDesc = "",
                        Img = "",
                        Price = 4500,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Электромобиль"]
                    }
                    );
            }

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "Электромобиль", Desc="За ними будщее"},
                        new Category { CategoryName = "ДВС", Desc = "Старая школа" }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName,el);
                }

                return category;
            }
        }

    }
}
