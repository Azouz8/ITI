import 'package:flutter/material.dart';

class CustomAppBar extends StatelessWidget implements PreferredSizeWidget {
  const CustomAppBar({super.key});

  @override
  Widget build(BuildContext context) {
    return AppBar(
      title: const Text(
        "Task Analytics Workspace",
        style: TextStyle(fontSize: 24, fontWeight: FontWeight.w400),
      ),
      centerTitle: true,
      backgroundColor: const Color(0xfffdfbfe),
      elevation: 4.0,
      shadowColor: Colors.black,
    );
  }

  @override
  Size get preferredSize => const Size.fromHeight(kToolbarHeight);
}
