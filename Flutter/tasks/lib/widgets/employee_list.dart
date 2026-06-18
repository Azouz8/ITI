import 'package:day1_task/models/employee_model.dart';
import 'package:day1_task/screens/add_employee_screen.dart';
import 'package:day1_task/widgets/employee_empty_state.dart';
import 'package:day1_task/widgets/employee_tile.dart';
import 'package:day1_task/widgets/filter_panel.dart';
import 'package:flutter/material.dart';

class EmployeeList extends StatefulWidget {
  const EmployeeList({
    super.key,
    required this.isDark,
    required this.onThemeChanged,
  });

  final bool isDark;
  final ValueChanged<bool> onThemeChanged;

  @override
  State<EmployeeList> createState() => _EmployeeListState();
}

class _EmployeeListState extends State<EmployeeList> {
  final TextEditingController _searchController = TextEditingController();
  String _searchQuery = '';
  EmployeeCategory? _selectedCategory;
  bool _showActiveOnly = false;

  List<Employee> _employees = [];

  @override
  void initState() {
    super.initState();
    _searchController.addListener(() {
      setState(() => _searchQuery = _searchController.text);
    });
  }

  @override
  void dispose() {
    _searchController.dispose();
    super.dispose();
  }

  List<Employee> get _filteredEmployees {
    final query = _searchQuery.trim().toLowerCase();
    return _employees.where((emp) {
      final matchesSearch =
          query.isEmpty ||
          emp.fullName.toLowerCase().contains(query) ||
          emp.email.toLowerCase().contains(query) ||
          emp.department.toLowerCase().contains(query);
      final matchesCategory =
          _selectedCategory == null || emp.category == _selectedCategory;
      final matchesActive = !_showActiveOnly || emp.isActive;
      return matchesSearch && matchesCategory && matchesActive;
    }).toList();
  }

  void _clearFilters() {
    _searchController.clear();
    setState(() {
      _selectedCategory = null;
      _showActiveOnly = false;
    });
  }

  void _toggleCategory(EmployeeCategory cat) {
    setState(() {
      _selectedCategory = _selectedCategory == cat ? null : cat;
    });
  }

  void _toggleActive(int id) {
    setState(() {
      _employees = [
        for (final e in _employees)
          if (e.id == id) e.copyWith(isActive: !e.isActive) else e,
      ];
    });
  }

  Future<void> _openAddEmployeeForm() async {
    final newEmployee = await Navigator.of(context).push<Employee>(
      MaterialPageRoute(
        builder: (context) => AddEmployeeScreen(
          nextId: _employees.length + 1,
          isDark: widget.isDark,
          onThemeChanged: widget.onThemeChanged,
        ),
      ),
    );

    if (!mounted || newEmployee == null) return;

    setState(() {
      _employees = [newEmployee, ..._employees]; // add at the top
    });

    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Text('${newEmployee.fullName} added successfully!'),
        backgroundColor: Theme.of(context).colorScheme.primary,
        behavior: SnackBarBehavior.floating,
      ),
    );
  }

  bool get _hasActiveFilters =>
      _selectedCategory != null || _showActiveOnly || _searchQuery.isNotEmpty;

  @override
  Widget build(BuildContext context) {
    final colorScheme = Theme.of(context).colorScheme;
    final filtered = _filteredEmployees;

    return Scaffold(
      backgroundColor: colorScheme.surfaceContainerLowest,
      appBar: AppBar(
        backgroundColor: colorScheme.primary,
        foregroundColor: colorScheme.onPrimary,
        title: TextField(
          controller: _searchController,
          onTapOutside: (event) =>
              FocusManager.instance.primaryFocus!.unfocus(),
          style: TextStyle(color: colorScheme.onPrimary),
          cursorColor: colorScheme.onPrimary,
          decoration: InputDecoration(
            hintText: 'Search Employees...',
            hintStyle: TextStyle(
              color: colorScheme.onPrimary.withValues(alpha: 0.6),
            ),
            prefixIcon: Icon(Icons.search, color: colorScheme.onPrimary),
            suffixIcon: _searchQuery.isNotEmpty
                ? IconButton(
                    icon: Icon(Icons.clear, color: colorScheme.onPrimary),
                    onPressed: () => _searchController.clear(),
                  )
                : null,
            border: InputBorder.none,
          ),
        ),
        actions: [
          Icon(Icons.light_mode, color: colorScheme.onPrimary, size: 18),
          Switch(
            value: widget.isDark,
            onChanged: widget.onThemeChanged,
            activeThumbColor: colorScheme.onPrimary,
          ),
          Icon(Icons.dark_mode, color: colorScheme.onPrimary, size: 18),
          const SizedBox(width: 8),
        ],
      ),
      body: SafeArea(
        child: Column(
          children: [
            FilterPanel(
              selectedCategory: _selectedCategory,
              showActiveOnly: _showActiveOnly,
              onCategorySelected: _toggleCategory,
              onShowActiveOnlyChanged: (v) =>
                  setState(() => _showActiveOnly = v),
            ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 8),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Text(
                    'Employees (${filtered.length})',
                    style: const TextStyle(fontWeight: FontWeight.bold),
                  ),
                  if (_hasActiveFilters)
                    TextButton.icon(
                      onPressed: _clearFilters,
                      icon: const Icon(Icons.clear, size: 16),
                      label: const Text('Clear filters'),
                    ),
                ],
              ),
            ),
            Expanded(
              child: filtered.isEmpty
                  ? EmptyState(onClearFilters: _clearFilters)
                  : ListView.builder(
                      padding: const EdgeInsets.fromLTRB(16, 0, 16, 80),
                      itemCount: filtered.length,
                      itemBuilder: (context, index) {
                        final emp = filtered[index];
                        return EmployeeTile(
                          employee: emp,
                          onToggleActive: () => _toggleActive(emp.id),
                        );
                      },
                    ),
            ),
          ],
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _openAddEmployeeForm,
        backgroundColor: colorScheme.primary,
        foregroundColor: colorScheme.onPrimary,
        child: const Icon(Icons.add),
      ),
    );
  }
}
