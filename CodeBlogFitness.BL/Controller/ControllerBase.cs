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
        protected void Save(string FileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        protected T Load<T>(string FileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else return default(T);
            }
        }
    }
}
