import 'package:flutter/material.dart';

class CriticalItem extends StatelessWidget {
  const CriticalItem({
    super.key,
    required this.id,
    required this.headerText,
    required this.descriptionText,
    required this.isChecked,
    required this.onChanged,
  });

  final int id;
  final String headerText, descriptionText;
  final bool isChecked;
  final VoidCallback onChanged;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Row(
          children: [
            Checkbox(
              value: isChecked,
              activeColor: const Color(0xff4e677f),
              onChanged: (_) => onChanged(),
            ),
            const SizedBox(width: 32),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  headerText,
                  style: const TextStyle(fontSize: 18),
                  overflow: TextOverflow.ellipsis,
                ),
                Text(
                  descriptionText,
                  style: const TextStyle(fontSize: 16),
                  overflow: TextOverflow.ellipsis,
                ),
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
