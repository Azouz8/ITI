import 'package:flutter/material.dart';

class ProgressWidget extends StatelessWidget {
  const ProgressWidget({
    super.key,
    required this.checkListLength,
    required this.checkedItemsLength,
  });

  final int checkListLength;

  final int checkedItemsLength;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(16),
      child: Card(
        elevation: 2,
        child: Padding(
          padding: const EdgeInsets.symmetric(vertical: 20, horizontal: 16),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    spacing: 8,
                    children: [
                      Text(
                        "${checkedItemsLength.toString()} / ${checkListLength.toString()}",
                        style: const TextStyle(fontSize: 48),
                      ),
                      const Icon(
                        Icons.arrow_upward_outlined,
                        color: Color(0xff558b5a),
                        size: 40,
                      ),
                    ],
                  ),
                  const Row(
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
                      value: checkedItemsLength / checkListLength,
                      strokeWidth: 8,
                      backgroundColor: const Color(0xffc1cddb),
                      color: const Color(0xff496583),
                    ),
                  ),
                  Text(
                    "${((checkedItemsLength / checkListLength) * 100).toInt()}%",
                    style: const TextStyle(
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
