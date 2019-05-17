using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение CodeBlogFitness");
            Console.WriteLine(DateTime.Now);

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();
            //мес/день/год
            Console.WriteLine("Введите дату рождения");
            var birthday = DateTime.Parse(Console.ReadLine());//TODO: переписать TryParse

            Console.WriteLine("Введите вес");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthday, weight, height);
            userController.Save();
        }
    }
}