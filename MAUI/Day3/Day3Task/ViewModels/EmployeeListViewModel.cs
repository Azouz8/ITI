using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Day3Task.Models;
using Day3Task.Services;
using System.Collections.ObjectModel;

namespace Day3Task.ViewModels
{
    public partial class EmployeeListViewModel : ObservableObject
    {
        private readonly DatabaseService _db;

        [ObservableProperty]
        public partial ObservableCollection<Employee> Employees { get; set; } = new();

        public EmployeeListViewModel(DatabaseService db)
        {
            _db = db;
        }

        public async Task LoadEmployeesAsync()
        {
            var list = await _db.GetEmployeesAsync();
            Employees.Clear();
            foreach (var e in list)
                Employees.Add(e);
        }

        [RelayCommand]
        private async Task GoToFormAsync()
        {
            await Shell.Current.GoToAsync("//EmployeeFormPage");
        }
    }
}