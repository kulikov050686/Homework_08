using Homework_08.Models;
using Homework_08.ViewModels;
using Homework_08.Views;

namespace Homework_08.Services
{
    public static class EditDepartmentDialog
    {
        /// <summary>
        /// Диалоговое окно для редактирования департамента
        /// </summary>
        public static Department Show(Department department)
        {
            if (department != null)
            {
                WindowAddDepartament addDepartment = new WindowAddDepartament();
                AddDepartmentViewModel addDepartamentViewModel = new AddDepartmentViewModel();

                addDepartamentViewModel.Title = "Редактировать депортамент";
                addDepartamentViewModel.AddText = "Изменить";
                addDepartamentViewModel.NameDepartament = department.NameDepartment;                
                addDepartment.DataContext = addDepartamentViewModel;

                addDepartment.ShowDialog();

                if(addDepartamentViewModel.Department != null)
                {
                    department.NameDepartment = addDepartamentViewModel.Department.NameDepartment;
                }                
            }

            return department;
        }
    }
}
