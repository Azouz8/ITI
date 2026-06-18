import 'package:day1_task/data/critical_check_list.dart';
import 'package:day1_task/widgets/critical_item.dart';
import 'package:flutter/material.dart';

class CriticalDirectives extends StatelessWidget {
  const CriticalDirectives({super.key, required this.onChanged});

  final Function(int) onChanged;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 16),
      child: Card(
        elevation: 2,
        child: Padding(
          padding: const EdgeInsets.all(16),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const Text(
                "Critical Directives Queue",
                style: TextStyle(fontSize: 24, fontWeight: FontWeight.w600),
              ),
              const SizedBox(height: 16),
              ...criticalCheckList.map(
                (e) => CriticalItem(
                  id: e.id,
                  headerText: e.headerText,
                  descriptionText: e.descriptionText,
                  isChecked: e.isChecked,
                  onChanged: () => onChanged(e.id),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
