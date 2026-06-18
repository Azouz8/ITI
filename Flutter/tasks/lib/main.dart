import 'package:day1_task/widgets/employee_list.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const CorporateResourceApp());
}

class CorporateResourceApp extends StatefulWidget {
  const CorporateResourceApp({super.key});

  @override
  State<CorporateResourceApp> createState() => _CorporateResourceAppState();
}

class _CorporateResourceAppState extends State<CorporateResourceApp> {
  bool isDark = false;

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Corporate Resource Manager',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
          seedColor: const Color(0xFF00838F),
          brightness: Brightness.light,
        ),
        useMaterial3: true,
      ),
      darkTheme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
          seedColor: const Color(0xFF00838F),
          brightness: Brightness.dark,
        ),
        useMaterial3: true,
      ),
      themeMode: isDark ? ThemeMode.dark : ThemeMode.light,
      home: EmployeeList(
        isDark: isDark,
        onThemeChanged: (value) => setState(() => isDark = value),
      ),
    );
  }
}
