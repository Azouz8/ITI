class Employee {
  final int? id;
  final String name;
  final int departmentId;
  final String jobTitle;
  final double salary;
  final String? ssn;
  final String insertedBy;
  final DateTime insertedDate;
  final String modifiedBy;
  final DateTime modifiedDate;

  final String? departmentName;

  Employee({
    this.id,
    required this.name,
    required this.departmentId,
    required this.jobTitle,
    required this.salary,
    this.ssn,
    this.insertedBy = 'Admin',
    DateTime? insertedDate,
    this.modifiedBy = 'Admin',
    DateTime? modifiedDate,
    this.departmentName,
  })  : insertedDate = insertedDate ?? DateTime.now(),
        modifiedDate = modifiedDate ?? DateTime.now();

  Map<String, dynamic> toMap() {
    return {
      if (id != null) 'id': id,
      'name': name,
      'departmentId': departmentId,
      'jobTitle': jobTitle,
      'salary': salary,
      'ssn': ssn,
      'insertedBy': insertedBy,
      'insertedDate': insertedDate.toIso8601String(),
      'modifiedBy': modifiedBy,
      'modifiedDate': modifiedDate.toIso8601String(),
    };
  }

  factory Employee.fromMap(Map<String, dynamic> map, {String? departmentName}) {
    return Employee(
      id: map['id'] as int?,
      name: map['name'] as String,
      departmentId: map['departmentId'] as int,
      jobTitle: map['jobTitle'] as String,
      salary: (map['salary'] as num).toDouble(),
      ssn: map['ssn'] as String?,
      insertedBy: map['insertedBy'] as String? ?? 'Admin',
      insertedDate: DateTime.tryParse(map['insertedDate'] as String? ?? '') ?? DateTime.now(),
      modifiedBy: map['modifiedBy'] as String? ?? 'Admin',
      modifiedDate: DateTime.tryParse(map['modifiedDate'] as String? ?? '') ?? DateTime.now(),
      departmentName: departmentName,
    );
  }

  Employee copyWith({
    int? id,
    String? name,
    int? departmentId,
    String? jobTitle,
    double? salary,
    String? ssn,
    String? insertedBy,
    DateTime? insertedDate,
    String? modifiedBy,
    DateTime? modifiedDate,
    String? departmentName,
  }) {
    return Employee(
      id: id ?? this.id,
      name: name ?? this.name,
      departmentId: departmentId ?? this.departmentId,
      jobTitle: jobTitle ?? this.jobTitle,
      salary: salary ?? this.salary,
      ssn: ssn ?? this.ssn,
      insertedBy: insertedBy ?? this.insertedBy,
      insertedDate: insertedDate ?? this.insertedDate,
      modifiedBy: modifiedBy ?? 'Admin',
      modifiedDate: modifiedDate ?? DateTime.now(),
      departmentName: departmentName ?? this.departmentName,
    );
  }
}