using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    abstract public class ControllerBase
    {
        /// <summary>
        /// Записываем в файл.
        /// </summary>
        /// <param name="FileName">Имя файла.</param>
        /// <param name="item">То что нужно записать.</param>
        protected void Save(string FileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
        /// <summary>
        /// Получаем содержимое файла.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="FileName">Имя файла из которого надо получить данные.</param>
        /// <returns></returns>
        protected T Load<T>(string FileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                //defult - значение по умолчанию для типа T.
                else return default;
            }
        }
    }
}
