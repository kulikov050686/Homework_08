using Homework_08.Models;
using Homework_08.ViewModels;
using Homework_08.Views;

namespace Homework_08.Services
{
    /// <summary>
    /// Открытие диалогового окна добавить департамент
    /// </summary>
    public static class AddDepartmentDialog
    {
        /// <summary>
        /// Диалоговое окно для добавления департамента
        /// </summary>
        public static Department Show()
        {
            WindowAddDepartament addDepartment = new WindowAddDepartament();
            AddDepartmentViewModel addDepartamentViewModel = new AddDepartmentViewModel();

            addDepartamentViewModel.Title = "Добавить депортамент";
            addDepartment.DataContext = addDepartamentViewModel;

            addDepartment.ShowDialog();

            return addDepartamentViewModel.Department;
        }
    }
}
