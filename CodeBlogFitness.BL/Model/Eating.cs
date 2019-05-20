using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {

        /// <summary>
        /// Момент в который пользователь начал есть.
        /// </summary>
        public DateTime Moment { get; }
        /// <summary>
        /// Словарь еды(ключа) и веса, которую принимал пользователь.
        /// </summary>
        public Dictionary<Food, double> UserDiet { get; }
        /// <summary>
        /// Сам пользователь.
        /// </summary>
        public User User { get; }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Moment = DateTime.UtcNow;
            UserDiet = new Dictionary<Food, double>();
        }
        /// <summary>
        /// Добавляет продукт в список Foods, если такого продукта еще не было, иначе добавляет вес этому продукту.
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void Add(Food food, double weight)
        {
            var product = UserDiet.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
                UserDiet.Add(food, weight);
            else UserDiet[product] += weight;
        }
    }
}
