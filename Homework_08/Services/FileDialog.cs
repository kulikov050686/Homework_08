using Homework_08.Models;
using System;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;

namespace Homework_08.Services
{
    /// <summary>
    /// Диалоговые окона для открытия и сохранения файла
    /// </summary>
    public static class FileDialog
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private static string PathFile;

        /// <summary>
        /// Открывает диалоговое окно для сохранения в файл
        /// </summary>
        public static void SaveFileDialog(List<Department> listSave)
        {
            SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            saveFileDialog.Title = "Сохранить файл";
            saveFileDialog.Filter = "files (*.json)|*.json|files (*.xml)|*.xml";
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (saveFileDialog.ShowDialog() == true)
            {
                PathFile = saveFileDialog.FileName;   
                
                if (Path.GetExtension(PathFile) == ".json")
                {
                    FileIOService.SaveAsJSON(PathFile, listSave);                    
                }

                if (Path.GetExtension(PathFile) == ".xml")
                {
                    FileIOService.SaveAsXML(PathFile, listSave);                    
                }
            }
        }

        /// <summary>
        /// Открывает диалоговое окно для чтения из файла
        /// </summary>        
        public static List<Department> OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();            

            openFileDialog.Title = "Открыть файл";
            openFileDialog.Filter = "files (*.json)|*.json|files (*.xml)|*.xml";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == true)
            {
                PathFile = openFileDialog.FileName;

                if (Path.GetExtension(PathFile) == ".json")
                {                    
                    return FileIOService.OpenAsJSON(PathFile);
                }

                if (Path.GetExtension(PathFile) == ".xml")
                {
                    return FileIOService.OpenAsXML(PathFile);
                }
            }

            return null;
        }
    }
}
