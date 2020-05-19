using Homework_08.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
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
        public static void SaveAsJSON(string PathFile, ObservableCollection<Department> listSave)
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
        public static ObservableCollection<Department> OpenAsJSON(string PathFile)
        {
            var fileExists = File.Exists(PathFile);

            if (!fileExists)
            {
                File.CreateText(PathFile).Dispose();
                return new ObservableCollection<Department>();
            }

            using (var reader = File.OpenText(PathFile))
            {
                var fileTaxt = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<Department>>(fileTaxt);
            }            
        }

        /// <summary>
        /// Сохранить лист в файл формата XML
        /// </summary>
        /// <param name="PathFile"> Путь к файлу </param>
        /// <param name="listSave"> Сохраняемый лист </param>
        public static void SaveAsXML(string PathFile, ObservableCollection<Department> listSave)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Department>));

            using (Stream fStream = new FileStream(PathFile, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fStream, listSave);
            }
        }

        /// <summary>
        /// Загрузить данные в лист из файла формата XML
        /// </summary>
        /// <param name="PathFile"> Путь к файлу </param>        
        public static ObservableCollection<Department> OpenAsXML(string PathFile)
        {
            var fileExists = File.Exists(PathFile);

            if (!fileExists)
            {
                File.CreateText(PathFile).Dispose();
                return new ObservableCollection<Department>();
            }

            ObservableCollection<Department> Temp = new ObservableCollection<Department>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Department>));

            using (Stream fStream = new FileStream(PathFile, FileMode.Open, FileAccess.Read))
            {
                Temp = xmlSerializer.Deserialize(fStream) as ObservableCollection<Department>;
            }

            return Temp;
        }
    }
}
