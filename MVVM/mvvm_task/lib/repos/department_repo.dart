import '../db/database_helper.dart';
import '../models/department.dart';

class DepartmentRepo {
  final dbHelper = DatabaseHelper.instance;

  Future<List<Department>> getAllDepartments() async {
    final db = await dbHelper.database;

    final result = await db.rawQuery('''
      SELECT d.id as id, d.name as name,
             COUNT(e.id) as numberOfEmployees
      FROM departments d
      LEFT JOIN employees e ON e.departmentId = d.id
      GROUP BY d.id, d.name
      ORDER BY d.name
    ''');

    return result
        .map(
          (row) => Department.fromMap(
            {'id': row['id'], 'name': row['name']},
            numberOfEmployees: (row['numberOfEmployees'] as int?) ?? 0,
          ),
        )
        .toList();
  }

  Future<int> insertDepartment(Department department) async {
    final db = await dbHelper.database;
    return db.insert('departments', department.toMap());
  }
}
