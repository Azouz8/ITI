enum EmployeeCategory { junior, midLevel, senior }

extension EmployeeCategoryLabel on EmployeeCategory {
  String get label => switch (this) {
        EmployeeCategory.junior => 'Junior',
        EmployeeCategory.midLevel => 'Mid-Level',
        EmployeeCategory.senior => 'Senior',
      };
}

class Employee {
  const Employee({
    required this.id,
    required this.fullName,
    required this.email,
    required this.weeklyHours,
    required this.department,
    required this.category,
    this.isActive = false,
  });

  final int id;
  final String fullName;
  final String email;
  final int weeklyHours;
  final String department;
  final EmployeeCategory category;
  final bool isActive;

  Employee copyWith({bool? isActive}) {
    return Employee(
      id: id,
      fullName: fullName,
      email: email,
      weeklyHours: weeklyHours,
      department: department,
      category: category,
      isActive: isActive ?? this.isActive,
    );
  }
}