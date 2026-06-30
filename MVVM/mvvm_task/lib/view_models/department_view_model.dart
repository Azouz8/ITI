import 'package:flutter/foundation.dart';
import 'package:mvvm_task/repos/department_repo.dart';

import '../models/department.dart';

class DepartmentViewModel extends ChangeNotifier {
  final DepartmentRepo _repository = DepartmentRepo();

  List<Department> _departments = [];
  bool _isLoading = false;
  String? _errorMessage;

  List<Department> get departments => _departments;
  bool get isLoading => _isLoading;
  String? get errorMessage => _errorMessage;

  Future<void> loadDepartments() async {
    _isLoading = true;
    _errorMessage = null;
    notifyListeners();

    try {
      _departments = await _repository.getAllDepartments();
    } catch (e) {
      _errorMessage = 'Failed to load departments: $e';
    } finally {
      _isLoading = false;
      notifyListeners();
    }
  }
}
