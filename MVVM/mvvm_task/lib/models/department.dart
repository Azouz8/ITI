class Department {
  final int? id;
  final String name;
  final int numberOfEmployees;

  Department({
    this.id,
    required this.name,
    this.numberOfEmployees = 0,
  });

  Map<String, dynamic> toMap() {
    return {
      if (id != null) 'id': id,
      'name': name,
    };
  }

  factory Department.fromMap(
    Map<String, dynamic> map, {
    int numberOfEmployees = 0,
  }) {
    return Department(
      id: map['id'] as int?,
      name: map['name'] as String,
      numberOfEmployees: numberOfEmployees,
    );
  }

  Department copyWith({int? id, String? name, int? numberOfEmployees}) {
    return Department(
      id: id ?? this.id,
      name: name ?? this.name,
      numberOfEmployees: numberOfEmployees ?? this.numberOfEmployees,
    );
  }
}
