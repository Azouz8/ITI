import 'package:flutter/material.dart';

class CustomHeader extends StatefulWidget {
  const CustomHeader({super.key});

  @override
  State<CustomHeader> createState() => _CustomHeader();
}

class _CustomHeader extends State<CustomHeader> {
  final positionController = TextEditingController();

  @override
  void dispose() {
    super.dispose();
    positionController.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsetsGeometry.all(16),
      child: Card(
        elevation: 8,
        child: Padding(
          padding: const EdgeInsetsGeometry.all(16),
          child: Column(
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        "OPERATOR ASSIGNMENT",
                        style: TextStyle(fontSize: 16, color: Colors.black54),
                      ),
                      Text(
                        positionController.text.isEmpty
                            ? "Software Engineer"
                            : positionController.text,
                        style: const TextStyle(
                          fontSize: 24,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                  const CircleAvatar(
                    radius: 28,
                    backgroundColor: Color(0xff4f5e6e),
                    child: Icon(Icons.person, color: Colors.white, size: 36),
                  ),
                ],
              ),
              const SizedBox(height: 16),
              TextField(
                controller: positionController,
                onChanged: (value) {
                  setState(() {});
                },
                style: const TextStyle(color: Colors.black87),
                cursorColor: Colors.blueGrey,
                onTapOutside: (event) =>
                    FocusManager.instance.primaryFocus!.unfocus(),
                decoration: const InputDecoration(
                  labelText: "Enter Posistion",
                  labelStyle: TextStyle(color: Colors.blueGrey),
                  constraints: BoxConstraints(maxHeight: 44),

                  enabledBorder: OutlineInputBorder(
                    borderSide: BorderSide(color: Colors.blueGrey, width: 1.0),
                  ),

                  focusedBorder: OutlineInputBorder(
                    borderSide: BorderSide(color: Colors.blueGrey, width: 2.0),
                  ),
                  border: OutlineInputBorder(),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
