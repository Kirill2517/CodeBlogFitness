using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public class EatingController : ControllerBase
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Файл для записи всей пищи.
        /// </summary>
        private const string FOOD_FILE_NAME = "foods.dat";

        /// <summary>
        /// Файл для записи того, что съел пользователь.
        /// </summary>
        private const string EATINGS_FILE_NAME = "eatings.dat";

        /// <summary>
        /// Справочник продуктов питания.
        /// </summary>
        public List<Food> FoodGuid { get; }
        /// <summary>
        /// То что съел пользователь.
        /// </summary>
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));

            FoodGuid = GetAllFoods();

            Eating = GetEatings();
        }
        /// <summary>
        /// Добавляем еду, если такой еще не было.
        /// А если была, то добавляем вес этому продукту.
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void Add(Food food, double weight)
        {
            var product = FoodGuid.SingleOrDefault(f => f.Name == food.Name);
            
            if (product == null)
            {
                //Добавляем продукт в справочник
                FoodGuid.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                //Добавляем вес этому продукту
                Eating.Add(product, weight);
                Save();
            }
        }

        /// <summary>
        /// Получаем продукты, которые съел пользователь.
        /// </summary>
        /// <returns></returns>
        private Eating GetEatings()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        /// <summary>
        /// Получаем справочник продуктов.
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOOD_FILE_NAME, FoodGuid);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}