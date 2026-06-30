import 'package:flutter/material.dart';
import 'package:mvvm_task/view_models/add_emloyee_view_model.dart';
import 'package:mvvm_task/view_models/add_employee_ssn_view_model.dart';
import 'package:mvvm_task/view_models/department_view_model.dart';
import 'package:mvvm_task/view_models/employee_view_model.dart';
import 'package:provider/provider.dart';
import 'views/home_view.dart';

void main() {
  runApp(const EmployeeApp());
}

class EmployeeApp extends StatelessWidget {
  const EmployeeApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => EmployeeViewModel()),
        ChangeNotifierProvider(create: (_) => DepartmentViewModel()),
        ChangeNotifierProvider(create: (_) => AddEmployeeViewModel()),
        ChangeNotifierProvider(create: (_) => AddEmployeeSsnViewModel()),
      ],
      child: MaterialApp(
        title: 'Employee Management System',
        debugShowCheckedModeBanner: false,
        theme: ThemeData(
          colorScheme: ColorScheme.fromSeed(seedColor: Colors.indigo),
          useMaterial3: true,
        ),
        home: const HomeView(),
      ),
    );
  }
}
