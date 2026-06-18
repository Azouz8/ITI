import 'package:day1_task/models/employee_model.dart';
import 'package:flutter/material.dart';

class EmployeeTile extends StatelessWidget {
  const EmployeeTile({
    super.key,
    required this.employee,
    required this.onToggleActive,
  });

  final Employee employee;
  final VoidCallback onToggleActive;

  @override
  Widget build(BuildContext context) {
    final colorScheme = Theme.of(context).colorScheme;

    return Card(
      elevation: 0,
      margin: const EdgeInsets.only(bottom: 8),
      child: ListTile(
        leading: CircleAvatar(
          backgroundColor: colorScheme.primaryContainer,
          child: Text(
            employee.fullName.characters.first.toUpperCase(),
            style: TextStyle(
              fontWeight: FontWeight.bold,
              color: colorScheme.onPrimaryContainer,
            ),
          ),
        ),
        title: Text(
          employee.fullName,
          style: const TextStyle(fontWeight: FontWeight.bold),
        ),
        subtitle: Text(
          '${employee.department} • ${employee.category.label}\n${employee.email}',
        ),
        isThreeLine: true,
        trailing: IconButton(
          tooltip: employee.isActive ? 'Mark inactive' : 'Mark active',
          icon: Icon(
            employee.isActive ? Icons.star : Icons.star_border,
            color: employee.isActive ? Colors.amber : null,
          ),
          onPressed: onToggleActive,
        ),
      ),
    );
  }
}
