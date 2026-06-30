import 'package:flutter/material.dart';

import '../../models/department.dart';

class DepartmentCard extends StatelessWidget {
  final Department department;

  const DepartmentCard({super.key, required this.department});

  @override
  Widget build(BuildContext context) {
    return Card(
      margin: const EdgeInsets.symmetric(horizontal: 12, vertical: 6),
      elevation: 2,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
      child: ListTile(
        leading: CircleAvatar(child: Text('${department.id}')),
        title: Text(department.name, style: const TextStyle(fontWeight: FontWeight.bold)),
        subtitle: Text('${department.numberOfEmployees} employee(s)'),
        trailing: const Icon(Icons.groups),
      ),
    );
  }
}