import 'package:day1_task/data/critical_check_list.dart';
import 'package:day1_task/widgets/categories_list.dart';
import 'package:day1_task/widgets/critical_directives.dart';
import 'package:day1_task/widgets/custom_appbar.dart';
import 'package:day1_task/widgets/custom_header.dart';
import 'package:day1_task/widgets/custom_submit_button.dart';
import 'package:day1_task/widgets/progress_widget.dart';
import 'package:flutter/material.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  void toggleCheckbox(int id) {
    setState(() {
      int index = criticalCheckList.indexWhere((e) => e.id == id);
      criticalCheckList[index].toggleState();
    });
  }

  @override
  Widget build(BuildContext context) {
    int checkedItemsLength = criticalCheckList.where((e) => e.isChecked).length;
    return Scaffold(
      appBar: const CustomAppBar(),
      body: Padding(
        padding: const EdgeInsets.only(bottom: 16),
        child: SingleChildScrollView(
          physics: const BouncingScrollPhysics(),
          child: Column(
            children: [
              const CustomHeader(),
              const CategoriesList(),
              ProgressWidget(
                checkListLength: criticalCheckList.length,
                checkedItemsLength: checkedItemsLength,
              ),
              CriticalDirectives(onChanged: toggleCheckbox),
              const CustomSubmitButton(),
            ],
          ),
        ),
      ),
    );
  }
}
