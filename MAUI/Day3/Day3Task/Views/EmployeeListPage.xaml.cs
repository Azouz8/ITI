using Day3Task.ViewModels;

namespace Day3Task.Views;

public partial class EmployeeListPage : ContentPage
{
    private readonly EmployeeListViewModel _vm;

    public EmployeeListPage(EmployeeListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadEmployeesAsync();
    }
}