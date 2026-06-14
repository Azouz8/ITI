import 'package:flutter/material.dart';

class CriticalItem extends StatelessWidget {
  const CriticalItem({
    super.key,
    required this.headerText,
    required this.descriptionText,
  });

  final String headerText, descriptionText;
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Row(
          children: [
            const Icon(Icons.menu, size: 32),
            const SizedBox(width: 32),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(headerText, style: const TextStyle(fontSize: 20)),
                Text(descriptionText, style: const TextStyle(fontSize: 16)),
              ],
            ),
            const Spacer(),
            const Icon(Icons.keyboard_arrow_right_rounded, size: 32),
          ],
        ),
        const Divider(thickness: 1.5, indent: 60),
      ],
    );
  }
}
