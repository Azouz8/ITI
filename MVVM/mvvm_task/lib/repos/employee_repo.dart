import '../db/database_helper.dart';
import '../models/employee.dart';

class EmployeeRepo {
  final dbHelper = DatabaseHelper.instance;

  Future<List<Employee>> getAllEmployees() async {
    final db = await dbHelper.database;

    final result = await db.rawQuery('''
      SELECT e.*, d.name as departmentName
      FROM employees e
      INNER JOIN departments d ON d.id = e.departmentId
      ORDER BY e.id DESC
    ''');

    return result
        .map(
          (row) => Employee.fromMap(
            row,
            departmentName: row['departmentName'] as String?,
          ),
        )
        .toList();
  }

  Future<List<Employee>> getEmployeesBasic() async {
    final db = await dbHelper.database;
    final result = await db.query(
      'employees',
      columns: [
        'id',
        'name',
        'departmentId',
        'jobTitle',
        'salary',
        'ssn',
        'insertedBy',
        'insertedDate',
        'modifiedBy',
        'modifiedDate',
      ],
    );
    return result.map((row) => Employee.fromMap(row)).toList();
  }

  Future<int> insertEmployee(Employee employee) async {
    final db = await dbHelper.database;
    return db.insert('employees', employee.toMap());
  }

  Future<int> updateEmployeeSSN({
    required int employeeId,
    required String ssn,
  }) async {
    final db = await dbHelper.database;
    return db.update(
      'employees',
      {
        'ssn': ssn,
        'modifiedBy': 'Admin',
        'modifiedDate': DateTime.now().toIso8601String(),
      },
      where: 'id = ?',
      whereArgs: [employeeId],
    );
  }
}
