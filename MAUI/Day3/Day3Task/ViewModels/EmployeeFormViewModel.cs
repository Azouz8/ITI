using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Day3Task.Models;
using Day3Task.Services;
using System.Collections.ObjectModel;

namespace Day3Task.ViewModels
{
    public partial class EmployeeFormViewModel : ObservableObject
    {
        private readonly DatabaseService _db;

        [ObservableProperty]
        public partial string FullName { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string Email { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string Phone { get; set; } = string.Empty;

        [ObservableProperty]
        public partial Department? SelectedDepartment { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<Department> Departments { get; set; } = new();

        [ObservableProperty]
        public partial string FullNameError { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string EmailError { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string PhoneError { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string DepartmentError { get; set; } = string.Empty;

        public EmployeeFormViewModel(DatabaseService db)
        {
            _db = db;
        }

        public async Task LoadDepartmentsAsync()
        {
            var list = await _db.GetDepartmentsAsync();
            Departments.Clear();
            foreach (var d in list)
                Departments.Add(d);
        }

        private bool Validate()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(FullName))
            {
                FullNameError = "Full name is required.";
                isValid = false;
            }
            else if (FullName.Trim().Length < 3)
            {
                FullNameError = "Full name must be at least 3 characters.";
                isValid = false;
            }
            else
            {
                FullNameError = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                EmailError = "Email is required.";
                isValid = false;
            }
            else if (!Email.Contains('@') || !Email.Contains('.'))
            {
                EmailError = "Enter a valid email (e.g. user@example.com).";
                isValid = false;
            }
            else
            {
                EmailError = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(Phone))
            {
                PhoneError = "Phone number is required.";
                isValid = false;
            }
            else if (Phone.Trim().Length < 7)
            {
                PhoneError = "Phone number must be at least 7 digits.";
                isValid = false;
            }
            else if (!Phone.Trim().All(c => char.IsDigit(c) || c == '+' || c == '-'))
            {
                PhoneError = "Phone number can only contain digits, + or -.";
                isValid = false;
            }
            else
            {
                PhoneError = string.Empty;
            }

            if (SelectedDepartment == null)
            {
                DepartmentError = "Please select a department.";
                isValid = false;
            }
            else
            {
                DepartmentError = string.Empty;
            }

            return isValid;
        }

        private void ResetForm()
        {
            FullName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            SelectedDepartment = null;

            FullNameError = string.Empty;
            EmailError = string.Empty;
            PhoneError = string.Empty;
            DepartmentError = string.Empty;
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            if (!Validate()) return;

            var employee = new Employee
            {
                FullName = FullName.Trim(),
                Email = Email.Trim(),
                Phone = Phone.Trim(),
                DepartmentId = SelectedDepartment!.Id,
                DepartmentName = SelectedDepartment.Name,
            };

            await _db.AddEmployeeAsync(employee);

            ResetForm();

            await Shell.Current.GoToAsync("//EmployeeListPage");
        }
    }
}