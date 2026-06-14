import 'package:flutter/material.dart';

class CustomHeader extends StatelessWidget {
  const CustomHeader({super.key});

  @override
  Widget build(BuildContext context) {
    return const Padding(
      padding: EdgeInsetsGeometry.all(16),
      child: Card(
        elevation: 8,
        child: Padding(
          padding: EdgeInsetsGeometry.all(16),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    "OPERATOR ASSIGNMENT",
                    style: TextStyle(fontSize: 16, color: Colors.black54),
                  ),
                  Text(
                    "SENIOR ENGINEER",
                    style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
                  ),
                ],
              ),
              CircleAvatar(
                radius: 28,
                backgroundColor: Color(0xff4f5e6e),
                child: Icon(Icons.person, color: Colors.white, size: 36),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
