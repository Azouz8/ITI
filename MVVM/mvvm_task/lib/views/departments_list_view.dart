import 'package:flutter/material.dart';
import 'package:mvvm_task/view_models/department_view_model.dart';
import 'package:provider/provider.dart';
import 'widgets/department_card.dart';

class DepartmentsListView extends StatefulWidget {
  const DepartmentsListView({super.key});

  @override
  State<DepartmentsListView> createState() => _DepartmentsListViewState();
}

class _DepartmentsListViewState extends State<DepartmentsListView> {
  @override
  void initState() {
    super.initState();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      context.read<DepartmentViewModel>().loadDepartments();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Departments')),
      body: Consumer<DepartmentViewModel>(
        builder: (context, vm, _) {
          if (vm.isLoading) {
            return const Center(child: CircularProgressIndicator());
          }
          if (vm.errorMessage != null) {
            return Center(child: Text(vm.errorMessage!));
          }
          if (vm.departments.isEmpty) {
            return const Center(child: Text('No departments found.'));
          }
          return RefreshIndicator(
            onRefresh: vm.loadDepartments,
            child: ListView.builder(
              padding: const EdgeInsets.symmetric(vertical: 8),
              itemCount: vm.departments.length,
              itemBuilder: (context, index) =>
                  DepartmentCard(department: vm.departments[index]),
            ),
          );
        },
      ),
    );
  }
}
