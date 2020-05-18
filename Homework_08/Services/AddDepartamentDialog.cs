using Homework_08.Models;
using Homework_08.ViewModels;
using Homework_08.Views;

namespace Homework_08.Services
{
    /// <summary>
    /// Открытие диалогового окна добавить департамент
    /// </summary>
    public static class AddDepartamentDialog
    {
        /// <summary>
        /// Диалоговое окно для добавления департамента
        /// </summary>
        public static Department Show()
        {
            WindowAddDepartament addDepartament = new WindowAddDepartament();
            AddDepartamentViewModel addDepartamentViewModel = new AddDepartamentViewModel();

            addDepartamentViewModel.Title = "Добавить депортамент";
            addDepartament.DataContext = addDepartamentViewModel;

            addDepartament.ShowDialog();

            return addDepartamentViewModel.Department;
        }
    }
}
