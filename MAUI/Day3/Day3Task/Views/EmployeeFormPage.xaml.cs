using Day3Task.ViewModels;

namespace Day3Task.Views;

public partial class EmployeeFormPage : ContentPage
{
    private readonly EmployeeFormViewModel _vm;

    public EmployeeFormPage(EmployeeFormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadDepartmentsAsync();
    }
}