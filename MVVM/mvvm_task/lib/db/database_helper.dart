import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';

class DatabaseHelper {
  DatabaseHelper._internal();
  static final DatabaseHelper instance = DatabaseHelper._internal();

  static Database? _database;

  Future<Database> get database async {
    if (_database != null) return _database!;
    _database = await _initDatabase();
    return _database!;
  }

  Future<Database> _initDatabase() async {
    final dbPath = await getDatabasesPath();
    final path = join(dbPath, 'employee_app.db');

    return openDatabase(
      path,
      version: 1,
      onCreate: _onCreate,
    );
  }

  Future<void> _onCreate(Database db, int version) async {
    await db.execute('''
      CREATE TABLE departments (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        name TEXT NOT NULL UNIQUE
      )
    ''');

    await db.execute('''
      CREATE TABLE employees (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        name TEXT NOT NULL,
        departmentId INTEGER NOT NULL,
        jobTitle TEXT NOT NULL,
        salary REAL NOT NULL,
        ssn TEXT,
        insertedBy TEXT NOT NULL,
        insertedDate TEXT NOT NULL,
        modifiedBy TEXT NOT NULL,
        modifiedDate TEXT NOT NULL,
        FOREIGN KEY (departmentId) REFERENCES departments (id)
      )
    ''');

    final staticDepartments = [
      'Human Resources',
      'Engineering',
      'Finance',
      'Marketing',
      'Sales',
    ];

    for (final name in staticDepartments) {
      await db.insert('departments', {'name': name});
    }
  }
}
