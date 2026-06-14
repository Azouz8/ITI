import 'package:day1_task/widgets/categories_list.dart';
import 'package:day1_task/widgets/critical_directives.dart';
import 'package:day1_task/widgets/custom_appbar.dart';
import 'package:day1_task/widgets/custom_header.dart';
import 'package:day1_task/widgets/progress_widget.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      debugShowCheckedModeBanner: false,
      home: HomeScreen(),
    );
  }
}

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      appBar: CustomAppBar(),
      body: SingleChildScrollView(
        physics: BouncingScrollPhysics(),
        child: Column(
          children: [
            CustomHeader(),
            CategoriesList(),
            ProgressWidget(),
            CriticalDirectives(),
          ],
        ),
      ),
    );
  }
}
