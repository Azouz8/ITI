import 'package:day1_task/models/employee_model.dart';
import 'package:flutter/material.dart';

class FilterPanel extends StatelessWidget {
  const FilterPanel({
    super.key,
    required this.selectedCategory,
    required this.showActiveOnly,
    required this.onCategorySelected,
    required this.onShowActiveOnlyChanged,
  });

  final EmployeeCategory? selectedCategory;
  final bool showActiveOnly;
  final ValueChanged<EmployeeCategory> onCategorySelected;
  final ValueChanged<bool> onShowActiveOnlyChanged;

  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 0,
      margin: const EdgeInsets.fromLTRB(16, 16, 16, 0),
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Wrap(
              spacing: 8,
              children: EmployeeCategory.values.map((cat) {
                return FilterChip(
                  label: Text(cat.label),
                  selected: selectedCategory == cat,
                  onSelected: (_) => onCategorySelected(cat),
                );
              }).toList(),
            ),
            const SizedBox(height: 4),
            SwitchListTile(
              dense: true,
              contentPadding: EdgeInsets.zero,
              value: showActiveOnly,
              onChanged: onShowActiveOnlyChanged,
              title: const Text('Show Active Only'),
            ),
          ],
        ),
      ),
    );
  }
}
