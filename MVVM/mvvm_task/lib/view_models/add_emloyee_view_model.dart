import 'package:flutter/foundation.dart';
import 'package:mvvm_task/repos/department_repo.dart';
import 'package:mvvm_task/repos/employee_repo.dart';
import '../models/department.dart';
import '../models/employee.dart';

class AddEmployeeViewModel extends ChangeNotifier {
  final EmployeeRepo _employeeRepository = EmployeeRepo();
  final DepartmentRepo _departmentRepository = DepartmentRepo();

  List<Department> _departments = [];
  Department? _selectedDepartment;
  bool _isLoading = false;
  bool _isSaving = false;
  String? _errorMessage;

  List<Department> get departments => _departments;
  Department? get selectedDepartment => _selectedDepartment;
  bool get isLoading => _isLoading;
  bool get isSaving => _isSaving;
  String? get errorMessage => _errorMessage;

  Future<void> loadDepartments() async {
    _isLoading = true;
    notifyListeners();
    try {
      _departments = await _departmentRepository.getAllDepartments();
      if (_departments.isNotEmpty) {
        _selectedDepartment = _departments.first;
      }
    } catch (e) {
      _errorMessage = 'Failed to load departments: $e';
    } finally {
      _isLoading = false;
      notifyListeners();
    }
  }

  void selectDepartment(Department? department) {
    _selectedDepartment = department;
    notifyListeners();
  }

  Future<bool> addEmployee({
    required String firstName,
    required String lastName,
    required String jobTitle,
    required String salaryText,
  }) async {
    _errorMessage = null;

    if (firstName.trim().isEmpty || lastName.trim().isEmpty) {
      _errorMessage = 'First name and last name are required.';
      notifyListeners();
      return false;
    }
    if (_selectedDepartment == null) {
      _errorMessage = 'Please select a department.';
      notifyListeners();
      return false;
    }
    if (jobTitle.trim().isEmpty) {
      _errorMessage = 'Job title is required.';
      notifyListeners();
      return false;
    }
    final salary = double.tryParse(salaryText.trim());
    if (salary == null || salary < 0) {
      _errorMessage = 'Please enter a valid salary.';
      notifyListeners();
      return false;
    }

    _isSaving = true;
    notifyListeners();

    try {
      final employee = Employee(
        name: '${firstName.trim()} ${lastName.trim()}',
        departmentId: _selectedDepartment!.id!,
        jobTitle: jobTitle.trim(),
        salary: salary,
        ssn: null,
        insertedBy: 'Admin',
        modifiedBy: 'Admin',
      );
      await _employeeRepository.insertEmployee(employee);
      _isSaving = false;
      notifyListeners();
      return true;
    } catch (e) {
      _errorMessage = 'Failed to save employee: $e';
      _isSaving = false;
      notifyListeners();
      return false;
    }
  }
}
