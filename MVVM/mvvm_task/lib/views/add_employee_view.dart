import 'package:flutter/material.dart';
import 'package:mvvm_task/view_models/add_emloyee_view_model.dart';
import 'package:mvvm_task/view_models/add_employee_ssn_view_model.dart';
import 'package:mvvm_task/view_models/department_view_model.dart';
import 'package:mvvm_task/view_models/employee_view_model.dart';
import 'package:provider/provider.dart';
import '../models/department.dart';

class AddEmployeeView extends StatefulWidget {
  const AddEmployeeView({super.key});

  @override
  State<AddEmployeeView> createState() => _AddEmployeeViewState();
}

class _AddEmployeeViewState extends State<AddEmployeeView> {
  final _firstNameController = TextEditingController();
  final _lastNameController = TextEditingController();
  final _jobTitleController = TextEditingController();
  final _salaryController = TextEditingController();

  @override
  void initState() {
    super.initState();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      context.read<AddEmployeeViewModel>().loadDepartments();
    });
  }

  @override
  void dispose() {
    _firstNameController.dispose();
    _lastNameController.dispose();
    _jobTitleController.dispose();
    _salaryController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Add Employee')),
      body: Consumer<AddEmployeeViewModel>(
        builder: (context, vm, _) {
          if (vm.isLoading) {
            return const Center(child: CircularProgressIndicator());
          }

          return SingleChildScrollView(
            padding: const EdgeInsets.all(16),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                TextField(
                  controller: _firstNameController,
                  decoration: const InputDecoration(
                    labelText: 'First Name',
                    border: OutlineInputBorder(),
                  ),
                ),
                const SizedBox(height: 12),
                TextField(
                  controller: _lastNameController,
                  decoration: const InputDecoration(
                    labelText: 'Last Name',
                    border: OutlineInputBorder(),
                  ),
                ),
                const SizedBox(height: 12),
                DropdownButtonFormField<Department>(
                  initialValue: vm.selectedDepartment,
                  decoration: const InputDecoration(
                    labelText: 'Department',
                    border: OutlineInputBorder(),
                  ),
                  items: vm.departments
                      .map(
                        (d) => DropdownMenuItem(value: d, child: Text(d.name)),
                      )
                      .toList(),
                  onChanged: vm.selectDepartment,
                ),
                const SizedBox(height: 12),
                TextField(
                  controller: _jobTitleController,
                  decoration: const InputDecoration(
                    labelText: 'Job Title',
                    border: OutlineInputBorder(),
                  ),
                ),
                const SizedBox(height: 12),
                TextField(
                  controller: _salaryController,
                  keyboardType: const TextInputType.numberWithOptions(
                    decimal: true,
                  ),
                  decoration: const InputDecoration(
                    labelText: 'Salary',
                    border: OutlineInputBorder(),
                  ),
                ),
                const SizedBox(height: 20),
                if (vm.errorMessage != null) ...[
                  Text(
                    vm.errorMessage!,
                    style: const TextStyle(color: Colors.red),
                  ),
                  const SizedBox(height: 12),
                ],
                ElevatedButton(
                  onPressed: vm.isSaving
                      ? null
                      : () async {
                          final success = await vm.addEmployee(
                            firstName: _firstNameController.text,
                            lastName: _lastNameController.text,
                            jobTitle: _jobTitleController.text,
                            salaryText: _salaryController.text,
                          );
                          if (success && context.mounted) {
                            context.read<EmployeeViewModel>().loadEmployees();
                            context.read<DepartmentViewModel>().loadDepartments();
                            context.read<AddEmployeeSsnViewModel>().loadEmployees();

                            ScaffoldMessenger.of(context).showSnackBar(
                              const SnackBar(
                                content: Text('Employee added successfully'),
                              ),
                            );
                            Navigator.pop(context);
                          }
                        },
                  child: vm.isSaving
                      ? const SizedBox(
                          height: 18,
                          width: 18,
                          child: CircularProgressIndicator(
                            strokeWidth: 2,
                            color: Colors.white,
                          ),
                        )
                      : const Text('Save Employee'),
                ),
              ],
            ),
          );
        },
      ),
    );
  }
}
