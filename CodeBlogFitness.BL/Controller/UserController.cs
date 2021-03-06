﻿using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";

        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }
 
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user">Пользователь приложения.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        public void SetNewUserDara(string genderName, DateTime birthDay, double weight = 1, double height = 1)
        {
            //Проверка
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Save();
        }

        /// <summary>
        /// Получить сохраненные данные пользователей.
        /// </summary>
        /// <returns>Сохраненные данные пользователей.</returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }
    }
}