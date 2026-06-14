import 'package:flutter/material.dart';

class ProgressWidget extends StatelessWidget {
  const ProgressWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return const Padding(
      padding: EdgeInsets.all(16),
      child: Card(
        elevation: 2,
        child: Padding(
          padding: EdgeInsets.symmetric(vertical: 20, horizontal: 16),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    spacing: 8,
                    children: [
                      Text("14 / 20", style: TextStyle(fontSize: 48)),
                      Icon(
                        Icons.arrow_upward_outlined,
                        color: Color(0xff558b5a),
                        size: 40,
                      ),
                    ],
                  ),
                  Row(
                    spacing: 8,
                    children: [
                      Text("Task Optimized", style: TextStyle(fontSize: 20)),
                      Icon(
                        Icons.check_circle,
                        color: Color(0xff558b5a),
                        size: 24,
                      ),
                    ],
                  ),
                ],
              ),
              Stack(
                alignment: Alignment.center,
                children: [
                  SizedBox(
                    width: 100,
                    height: 100,
                    child: CircularProgressIndicator(
                      value: 0.7,
                      strokeWidth: 8,
                      backgroundColor: Color(0xffc1cddb),
                      color: Color(0xff496583),
                    ),
                  ),
                  Text(
                    "70%",
                    style: TextStyle(
                      fontSize: 24,
                      fontWeight: FontWeight.w500,
                      color: Colors.black87,
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}
