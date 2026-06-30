import 'package:flutter/material.dart';
import 'package:mvvm_task/view_models/employee_view_model.dart';
import 'package:mvvm_task/views/add_employee_view.dart';
import 'package:provider/provider.dart';
import 'widgets/employee_card.dart';

class EmployeesListView extends StatefulWidget {
  const EmployeesListView({super.key});

  @override
  State<EmployeesListView> createState() => _EmployeesListViewState();
}

class _EmployeesListViewState extends State<EmployeesListView> {
  @override
  void initState() {
    super.initState();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      context.read<EmployeeViewModel>().loadEmployees();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Employees')),
      floatingActionButton: FloatingActionButton(
        onPressed: () async {
          await Navigator.push(
            context,
            MaterialPageRoute(builder: (_) => const AddEmployeeView()),
          );
          if (context.mounted) {
            context.read<EmployeeViewModel>().loadEmployees();
          }
        },
        child: const Icon(Icons.add),
      ),
      body: Consumer<EmployeeViewModel>(
        builder: (context, vm, _) {
          if (vm.isLoading) {
            return const Center(child: CircularProgressIndicator());
          }
          if (vm.errorMessage != null) {
            return Center(child: Text(vm.errorMessage!));
          }
          if (vm.employees.isEmpty) {
            return const Center(
              child: Text('No employees yet. Tap + to add one.'),
            );
          }
          return RefreshIndicator(
            onRefresh: vm.loadEmployees,
            child: ListView.builder(
              padding: const EdgeInsets.symmetric(vertical: 8),
              itemCount: vm.employees.length,
              itemBuilder: (context, index) =>
                  EmployeeCard(employee: vm.employees[index]),
            ),
          );
        },
      ),
    );
  }
}
