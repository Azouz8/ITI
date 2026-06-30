import 'package:flutter/foundation.dart';
import 'package:mvvm_task/repos/employee_repo.dart';
import '../models/employee.dart';

class EmployeeViewModel extends ChangeNotifier {
  final EmployeeRepo _repository = EmployeeRepo();

  List<Employee> _employees = [];
  bool _isLoading = false;
  String? _errorMessage;

  List<Employee> get employees => _employees;
  bool get isLoading => _isLoading;
  String? get errorMessage => _errorMessage;

  Future<void> loadEmployees() async {
    _isLoading = true;
    _errorMessage = null;
    notifyListeners();

    try {
      _employees = await _repository.getAllEmployees();
    } catch (e) {
      _errorMessage = 'Failed to load employees: $e';
    } finally {
      _isLoading = false;
      notifyListeners();
    }
  }
}
