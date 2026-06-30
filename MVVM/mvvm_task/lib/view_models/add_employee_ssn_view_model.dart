import 'package:flutter/foundation.dart';
import 'package:mvvm_task/repos/employee_repo.dart';
import '../models/employee.dart';

class AddEmployeeSsnViewModel extends ChangeNotifier {
  final EmployeeRepo _repository = EmployeeRepo();

  List<Employee> _employees = [];
  Employee? _selectedEmployee;
  bool _isLoading = false;
  bool _isSaving = false;
  String? _errorMessage;
  String? _successMessage;

  List<Employee> get employees => _employees;
  Employee? get selectedEmployee => _selectedEmployee;
  bool get isLoading => _isLoading;
  bool get isSaving => _isSaving;
  String? get errorMessage => _errorMessage;
  String? get successMessage => _successMessage;

  Future<void> loadEmployees() async {
    _isLoading = true;
    notifyListeners();
    try {
      _employees = await _repository.getEmployeesBasic();
      if (_employees.isNotEmpty) {
        _selectedEmployee = _employees.first;
      }
    } catch (e) {
      _errorMessage = 'Failed to load employees: $e';
    } finally {
      _isLoading = false;
      notifyListeners();
    }
  }

  void selectEmployee(Employee? employee) {
    _selectedEmployee = employee;
    notifyListeners();
  }

  Future<bool> saveSsn(String ssn) async {
    _errorMessage = null;
    _successMessage = null;

    if (_selectedEmployee == null) {
      _errorMessage = 'Please select an employee.';
      notifyListeners();
      return false;
    }
    if (ssn.trim().isEmpty) {
      _errorMessage = 'Please enter an SSN.';
      notifyListeners();
      return false;
    }

    _isSaving = true;
    notifyListeners();

    try {
      await _repository.updateEmployeeSSN(
        employeeId: _selectedEmployee!.id!,
        ssn: ssn.trim(),
      );
      _successMessage =
          'SSN updated successfully for ${_selectedEmployee!.name}.';
      _isSaving = false;
      notifyListeners();
      return true;
    } catch (e) {
      _errorMessage = 'Failed to update SSN: $e';
      _isSaving = false;
      notifyListeners();
      return false;
    }
  }
}
