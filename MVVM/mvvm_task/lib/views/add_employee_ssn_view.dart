import 'package:flutter/material.dart';
import 'package:mvvm_task/view_models/add_employee_ssn_view_model.dart';
import 'package:mvvm_task/view_models/employee_view_model.dart';
import 'package:provider/provider.dart';
import '../models/employee.dart';

class AddEmployeeSsnView extends StatefulWidget {
  const AddEmployeeSsnView({super.key});

  @override
  State<AddEmployeeSsnView> createState() => _AddEmployeeSsnViewState();
}

class _AddEmployeeSsnViewState extends State<AddEmployeeSsnView> {
  final _ssnController = TextEditingController();

  @override
  void initState() {
    super.initState();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      context.read<AddEmployeeSsnViewModel>().loadEmployees();
    });
  }

  @override
  void dispose() {
    _ssnController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Add Employee SSN')),
      body: Consumer<AddEmployeeSsnViewModel>(
        builder: (context, vm, _) {
          if (vm.isLoading) {
            return const Center(child: CircularProgressIndicator());
          }
          if (vm.employees.isEmpty) {
            return const Center(
              child: Text('No employees available. Add an employee first.'),
            );
          }

          return SingleChildScrollView(
            padding: const EdgeInsets.all(16),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                DropdownButtonFormField<Employee>(
                  initialValue: vm.selectedEmployee,
                  decoration: const InputDecoration(
                    labelText: 'Select Employee',
                    border: OutlineInputBorder(),
                  ),
                  items: vm.employees
                      .map(
                        (e) => DropdownMenuItem(
                          value: e,
                          child: Text('${e.id} - ${e.name}'),
                        ),
                      )
                      .toList(),
                  onChanged: vm.selectEmployee,
                ),
                const SizedBox(height: 12),
                TextField(
                  controller: _ssnController,
                  decoration: const InputDecoration(
                    labelText: 'SSN',
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
                if (vm.successMessage != null) ...[
                  Text(
                    vm.successMessage!,
                    style: const TextStyle(color: Colors.green),
                  ),
                  const SizedBox(height: 12),
                ],
                ElevatedButton(
                  onPressed: vm.isSaving
                      ? null
                      : () async {
                          final success = await vm.saveSsn(_ssnController.text);
                          if (success) {
                            _ssnController.clear();
                            if (context.mounted) {
                              context.read<EmployeeViewModel>().loadEmployees();
                            }
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
                      : const Text('Save SSN'),
                ),
              ],
            ),
          );
        },
      ),
    );
  }
}
