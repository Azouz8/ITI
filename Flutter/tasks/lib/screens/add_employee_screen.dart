import 'package:day1_task/models/employee_model.dart';
import 'package:flutter/material.dart';

class AddEmployeeScreen extends StatefulWidget {
  const AddEmployeeScreen({
    super.key,
    required this.nextId,
    required this.isDark,
    required this.onThemeChanged,
  });

  final int nextId;
  final bool isDark;
  final ValueChanged<bool> onThemeChanged;

  @override
  State<AddEmployeeScreen> createState() => _AddEmployeeScreenState();
}

class _AddEmployeeScreenState extends State<AddEmployeeScreen> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  final TextEditingController _nameController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _hoursController = TextEditingController();

  final FocusNode _emailFocus = FocusNode();
  final FocusNode _hoursFocus = FocusNode();

  String? _selectedDepartment;
  EmployeeCategory _selectedCategory = EmployeeCategory.junior;

  static const List<String> _departments = [
    'Engineering',
    'Design',
    'Marketing',
    'Management',
    'HR',
    'Finance',
  ];

  @override
  void dispose() {
    _nameController.dispose();
    _emailController.dispose();
    _hoursController.dispose();
    _emailFocus.dispose();
    _hoursFocus.dispose();
    super.dispose();
  }

  String? _requiredText(String? value, String field) {
    if (value == null || value.trim().isEmpty) return '$field is required.';
    return null;
  }

  String? _validateEmail(String? value) {
    if (value == null || value.trim().isEmpty) return 'Email is required.';
    final emailRegex = RegExp(r'^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$');
    if (!emailRegex.hasMatch(value.trim())) {
      return 'Enter a valid email address.';
    }
    return null;
  }

  String? _validateHours(String? value) {
    if (value == null || value.trim().isEmpty) {
      return 'Required, must be a valid integer within logical range.';
    }
    final hours = int.tryParse(value.trim());
    if (hours == null) return 'Must be a whole number.';
    if (hours < 1 || hours > 60) return 'Hours must be between 1 and 60.';
    return null;
  }

  void _submit() {
    if (!_formKey.currentState!.validate()) return;

    final newEmployee = Employee(
      id: widget.nextId,
      fullName: _nameController.text.trim(),
      email: _emailController.text.trim(),
      weeklyHours: int.parse(_hoursController.text.trim()),
      department: _selectedDepartment!,
      category: _selectedCategory,
      isActive: false,
    );

    Navigator.of(context).pop(newEmployee);
  }

  Widget _categoryChips(ColorScheme cs) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        const _FieldLabel(label: 'Category'),
        const SizedBox(height: 8),
        Row(
          children: EmployeeCategory.values.map((cat) {
            final selected = _selectedCategory == cat;
            return Expanded(
              child: Padding(
                padding: const EdgeInsets.only(right: 8),
                child: GestureDetector(
                  onTap: () => setState(() => _selectedCategory = cat),
                  child: AnimatedContainer(
                    duration: const Duration(milliseconds: 180),
                    curve: Curves.easeOut,
                    padding: const EdgeInsets.symmetric(vertical: 12),
                    decoration: BoxDecoration(
                      color: selected ? cs.primary : cs.surfaceContainerHigh,
                      borderRadius: BorderRadius.circular(12),
                      border: Border.all(
                        color: selected ? cs.primary : Colors.transparent,
                        width: 1.5,
                      ),
                    ),
                    child: Column(
                      children: [
                        Icon(
                          _categoryIcon(cat),
                          size: 20,
                          color: selected ? cs.onPrimary : cs.onSurfaceVariant,
                        ),
                        const SizedBox(height: 4),
                        Text(
                          cat.label,
                          style: TextStyle(
                            fontSize: 12,
                            fontWeight: FontWeight.w600,
                            color: selected
                                ? cs.onPrimary
                                : cs.onSurfaceVariant,
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            );
          }).toList(),
        ),
      ],
    );
  }

  IconData _categoryIcon(EmployeeCategory cat) => switch (cat) {
    EmployeeCategory.junior => Icons.school_outlined,
    EmployeeCategory.midLevel => Icons.trending_up_outlined,
    EmployeeCategory.senior => Icons.workspace_premium_outlined,
  };

  @override
  Widget build(BuildContext context) {
    final colorScheme = Theme.of(context).colorScheme;

    return Scaffold(
      backgroundColor: colorScheme.surfaceContainerLowest,
      appBar: AppBar(
        backgroundColor: colorScheme.primary,
        foregroundColor: colorScheme.onPrimary,
        elevation: 0,
        leading: IconButton(
          icon: const Icon(Icons.arrow_back),
          onPressed: () => Navigator.of(context).pop(),
        ),
        title: const Text(
          'Add New Employee',
          style: TextStyle(fontWeight: FontWeight.w600),
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
        child: SingleChildScrollView(
          child: Column(
            children: [
              Padding(
                padding: const EdgeInsets.fromLTRB(16, 20, 16, 32),
                child: Form(
                  key: _formKey,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.stretch,
                    children: [
                      const _SectionHeading(label: 'Personal Info'),
                      const SizedBox(height: 12),

                      const _FieldLabel(label: 'Full Name'),
                      const SizedBox(height: 6),
                      TextFormField(
                        controller: _nameController,
                        decoration: _inputDeco(
                          hint: 'e.g. Ali Azouz',
                          icon: Icons.person_outline,
                          colorScheme: colorScheme,
                        ),
                        textInputAction: TextInputAction.next,
                        onFieldSubmitted: (_) =>
                            FocusScope.of(context).requestFocus(_emailFocus),
                        validator: (v) => _requiredText(v, 'Full Name'),
                      ),
                      const SizedBox(height: 16),

                      const _FieldLabel(label: 'Email Address'),
                      const SizedBox(height: 6),
                      TextFormField(
                        controller: _emailController,
                        focusNode: _emailFocus,
                        decoration: _inputDeco(
                          hint: 'example@gmail.com',
                          icon: Icons.email_outlined,
                          colorScheme: colorScheme,
                        ),
                        keyboardType: TextInputType.emailAddress,
                        textInputAction: TextInputAction.next,
                        onFieldSubmitted: (_) =>
                            FocusScope.of(context).requestFocus(_hoursFocus),
                        validator: _validateEmail,
                      ),
                      const SizedBox(height: 24),

                      const _SectionHeading(label: 'Work Details'),
                      const SizedBox(height: 12),

                      const _FieldLabel(label: 'Weekly Hours'),
                      const SizedBox(height: 6),
                      TextFormField(
                        controller: _hoursController,
                        focusNode: _hoursFocus,
                        decoration: _inputDeco(
                          hint: 'e.g. 40',
                          icon: Icons.schedule_outlined,
                          colorScheme: colorScheme,
                        ),
                        keyboardType: TextInputType.number,
                        textInputAction: TextInputAction.done,
                        validator: _validateHours,
                      ),
                      const SizedBox(height: 16),

                      const _FieldLabel(label: 'Department'),
                      const SizedBox(height: 6),
                      DropdownButtonFormField<String>(
                        initialValue: _selectedDepartment,
                        decoration: _inputDeco(
                          hint: 'Select department',
                          icon: Icons.business_outlined,
                          colorScheme: colorScheme,
                        ),
                        hint: const Text('Select department'),
                        items: _departments
                            .map(
                              (d) => DropdownMenuItem(value: d, child: Text(d)),
                            )
                            .toList(),
                        onChanged: (v) =>
                            setState(() => _selectedDepartment = v),
                        validator: (v) =>
                            v == null ? 'Please select a department.' : null,
                      ),
                      const SizedBox(height: 24),

                      _categoryChips(colorScheme),
                      const SizedBox(height: 32),

                      SizedBox(
                        height: 54,
                        child: ElevatedButton.icon(
                          onPressed: _submit,
                          icon: const Icon(Icons.check_circle_outline),
                          label: const Text(
                            'Add Employee',
                            style: TextStyle(
                              fontSize: 16,
                              fontWeight: FontWeight.w600,
                            ),
                          ),
                          style: ElevatedButton.styleFrom(
                            backgroundColor: colorScheme.primary,
                            foregroundColor: colorScheme.onPrimary,
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(14),
                            ),
                            elevation: 0,
                          ),
                        ),
                      ),
                      const SizedBox(height: 12),

                      SizedBox(
                        height: 54,
                        child: OutlinedButton.icon(
                          onPressed: () => Navigator.of(context).pop(),
                          icon: const Icon(Icons.close),
                          label: const Text(
                            'Cancel',
                            style: TextStyle(
                              fontSize: 16,
                              fontWeight: FontWeight.w600,
                            ),
                          ),
                          style: OutlinedButton.styleFrom(
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(14),
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  InputDecoration _inputDeco({
    required String hint,
    required IconData icon,
    required ColorScheme colorScheme,
  }) {
    return InputDecoration(
      hintText: hint,
      prefixIcon: Icon(icon, size: 20),
      filled: true,
      fillColor: colorScheme.surfaceContainerHigh,
      border: OutlineInputBorder(
        borderRadius: BorderRadius.circular(12),
        borderSide: BorderSide.none,
      ),
      enabledBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(12),
        borderSide: BorderSide.none,
      ),
      focusedBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(12),
        borderSide: BorderSide(color: colorScheme.primary, width: 2),
      ),
      errorBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(12),
        borderSide: BorderSide(color: colorScheme.error, width: 1.5),
      ),
      focusedErrorBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(12),
        borderSide: BorderSide(color: colorScheme.error, width: 2),
      ),
      contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
    );
  }
}

class _SectionHeading extends StatelessWidget {
  const _SectionHeading({required this.label});
  final String label;

  @override
  Widget build(BuildContext context) {
    final cs = Theme.of(context).colorScheme;
    return Row(
      children: [
        Container(
          width: 4,
          height: 18,
          decoration: BoxDecoration(
            color: cs.primary,
            borderRadius: BorderRadius.circular(2),
          ),
        ),
        const SizedBox(width: 8),
        Text(
          label,
          style: TextStyle(
            fontSize: 14,
            fontWeight: FontWeight.w700,
            color: cs.primary,
            letterSpacing: 0.5,
          ),
        ),
        const SizedBox(width: 8),
        Expanded(
          child: Divider(color: cs.outlineVariant, thickness: 1),
        ),
      ],
    );
  }
}

class _FieldLabel extends StatelessWidget {
  const _FieldLabel({required this.label});
  final String label;

  @override
  Widget build(BuildContext context) {
    return Text(
      label,
      style: TextStyle(
        fontSize: 13,
        fontWeight: FontWeight.w600,
        color: Theme.of(context).colorScheme.onSurfaceVariant,
      ),
    );
  }
}
