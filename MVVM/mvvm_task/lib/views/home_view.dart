import 'package:flutter/material.dart';

import 'add_employee_ssn_view.dart';
import 'departments_list_view.dart';
import 'employees_list_view.dart';

class HomeView extends StatefulWidget {
  const HomeView({super.key});

  @override
  State<HomeView> createState() => _HomeViewState();
}

class _HomeViewState extends State<HomeView> {
  int _currentIndex = 0;

  final _pages = const [
    EmployeesListView(),
    DepartmentsListView(),
    AddEmployeeSsnView(),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: IndexedStack(index: _currentIndex, children: _pages),
      bottomNavigationBar: NavigationBar(
        selectedIndex: _currentIndex,
        onDestinationSelected: (index) => setState(() => _currentIndex = index),
        destinations: const [
          NavigationDestination(icon: Icon(Icons.people), label: 'Employees'),
          NavigationDestination(
            icon: Icon(Icons.apartment),
            label: 'Departments',
          ),
          NavigationDestination(icon: Icon(Icons.badge), label: 'Set SSN'),
        ],
      ),
    );
  }
}
