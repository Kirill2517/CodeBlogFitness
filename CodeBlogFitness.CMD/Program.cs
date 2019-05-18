﻿using CodeBlogFitness.BL.Controller;
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
            //Console.WriteLine(DateTime.Now);

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол");
                var gender = Console.ReadLine();

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
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите название продукта: ");
            var food = Console.ReadLine();
            var calories = ParseDouble("калорийность");
            var prot = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");

            return (Food: new Food(food, calories, prot, fats, carbs), Weight: weight);
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