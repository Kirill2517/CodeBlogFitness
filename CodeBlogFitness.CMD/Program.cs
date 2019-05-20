using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CurrentCulture;
            culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messege", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine(); name = ParseString(ref name, "имя пользователя");

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол");
                var gender = Console.ReadLine(); gender = ParseString(ref gender, "пол");

                DateTime birthDate;

                birthDate = ParseDateTime();

                var weight = ParseDouble("вес");

                var height = ParseDouble("рост");

                userController.SetNewUserDara(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что Вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.UserDiet)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
                Console.WriteLine();
                foreach (var item in eatingController.FoodGuid)
                {
                    Console.WriteLine($"{item.Name} - {item.Calorie} - {item.Fats}");
                }
            }
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите название продукта: ");
            var food = Console.ReadLine();food =  ParseString(ref food, "название продукта");
            var calories = ParseDouble("калорийность");
            var prot = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");

            return (Food: new Food(food, calories, prot, fats, carbs), Weight: weight);
        }

        private static string ParseString(ref string namePole, string name)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(namePole))
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                    namePole = Console.ReadLine();
                }
                else
                {
                    return namePole;
                    
                }
            }
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd/mm/yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                    break;
                else Console.WriteLine("неверный формат даты рождения");
            }
            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                else Console.WriteLine($"неверный формат поля {name}");
            }
        }
    }
}