using Homework_08.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Homework_08.Services
{
    /// <summary>
    /// Класс загрузки и выгрузки данных из файла
    /// </summary>
    public static class FileIOService
    {
        /// <summary>
        /// Сохранить лист в файл формата JSON
        /// </summary>
        /// <param name="PathFile"> Путь к файлу </param>
        /// <param name="listSave"> Сохраняемый лист </param>
        public static void SaveAsJSON(string PathFile, List<Department> listSave)
        {
            using (StreamWriter writer = File.CreateText(PathFile))
            {
                string output = JsonConvert.SerializeObject(listSave, Formatting.Indented);
                writer.Write(output);
            }
        }

        /// <summary>
        /// Загрузить данные в лист из файла формата JSON
        /// </summary>
        /// <param name="PathFile"> Путь к файлу </param>        
        public static List<Department> OpenAsJSON(string PathFile)
        {
            var fileExists = File.Exists(PathFile);

            if (!fileExists)
            {
                File.CreateText(PathFile).Dispose();
                return new List<Department>();
            }

            using (var reader = File.OpenText(PathFile))
            {
                var fileTaxt = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Department>>(fileTaxt);
            }            
        }

        /// <summary>
        /// Сохранить лист в файл формата XML
        /// </summary>
        /// <param name="PathFile"> Путь к файлу </param>
        /// <param name="listSave"> Сохраняемый лист </param>
        public static void SaveAsXML(string PathFile, List<Department> listSave)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));

            using (Stream fStream = new FileStream(PathFile, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fStream, listSave);
            }
        }

        /// <summary>
        /// Загрузить данные в лист из файла формата XML
        /// </summary>
        /// <param name="PathFile"> Путь к файлу </param>        
        public static List<Department> OpenAsXML(string PathFile)
        {
            var fileExists = File.Exists(PathFile);

            if (!fileExists)
            {
                File.CreateText(PathFile).Dispose();
                return new List<Department>();
            }

            List<Department> Temp = new List<Department>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));

            using (Stream fStream = new FileStream(PathFile, FileMode.Open, FileAccess.Read))
            {
                Temp = xmlSerializer.Deserialize(fStream) as List<Department>;
            }

            return Temp;
        }
    }
}
