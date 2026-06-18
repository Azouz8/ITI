import 'package:day1_task/widgets/category_item.dart';
import 'package:flutter/material.dart';

class CategoriesList extends StatelessWidget {
  const CategoriesList({super.key});

  @override
  Widget build(BuildContext context) {
    return const Padding(
      padding: EdgeInsets.only(left: 16),
      child: SingleChildScrollView(
        physics: BouncingScrollPhysics(),
        scrollDirection: Axis.horizontal,
        child: Row(
          spacing: 8,
          children: [
            CategoryItem(
              bgColor: Color(0xffd9dee9),
              borderColor: Color(0xff45566f),
              text: "All Tasks",
              textColor: Color(0xff45566f),
            ),
            CategoryItem(
              bgColor: Color(0xfffff0dd),
              borderColor: Color(0xff754d12),
              text: "In Progress",
              textColor: Color(0xff754d12),
            ),
            CategoryItem(
              bgColor: Color(0xffe1f4e1),
              borderColor: Color(0xff305d36),
              text: "Completed",
              textColor: Color(0xff305d36),
            ),
            CategoryItem(
              bgColor: Color(0xffeae4f0),
              borderColor: Color(0xff50345d),
              text: "Pending",
              textColor: Color(0xff50345d),
            ),
          ],
        ),
      ),
    );
  }
}
