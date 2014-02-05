using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Exceptions;
using Model.DomainModel;

namespace DataAccess.Helpers
{
    internal class BinaryHelper <T>
    {

        public bool FileExists(string fileName)
        {
            return File.Exists(fileName);
        }

        public T LoadObject(string fileName)
        {
           

            T loadedObject;
            try
            {
                using (FileStream fs = File.OpenRead(fileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    loadedObject = (T) formatter.Deserialize(fs);
                    return loadedObject;
                }
            }
            catch
            {
                throw new BimaryException("kunne ikke load filen : " + fileName);
            }
            
        }

        public void SaveObject(T objectToSave, string fileName)
        {
            if (!Directory.Exists("templates/"))
            {
                Directory.CreateDirectory("templates/");
            }

            using (FileStream fs = File.Create(fileName, 2048, FileOptions.None))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, objectToSave);
            }
        }
    }
}
