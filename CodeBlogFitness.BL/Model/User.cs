using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства класса пользователь
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// День рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        //        // Save today's date.
        //        var today = DateTime.Today;
        //        // Calculate the age.
        //        var age = today.Year - birthdate.Year;
        //        // Go back to the year the person was born in case of a leap year
        //        if (birthdate.Date > today.AddYears(-age)) age--;
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя. </param>
        /// <param name="gender">Пол. </param>
        /// <param name="birthDate">Дата рождения. </param>
        /// <param name="weight">Вес. </param>
        /// <param name="height">Рост. </param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Невозможная дата рождения.", nameof(birthDate));
            }
            Gender = gender ?? throw new ArgumentNullException("Пол не может быть пустым.", nameof(gender));
            if (weight <= 0)
            {
                throw new ArgumentNullException("Вес не может быть меньше либо равен нулю.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentNullException("Рост не может быть меньше либо равен нулю.", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " "+ Age;
        }
    }
}