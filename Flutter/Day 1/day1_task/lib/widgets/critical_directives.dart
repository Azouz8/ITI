import 'package:day1_task/widgets/critical_item.dart';
import 'package:flutter/material.dart';

class CriticalDirectives extends StatelessWidget {
  const CriticalDirectives({super.key});

  @override
  Widget build(BuildContext context) {
    return const Padding(
      padding: EdgeInsets.symmetric(horizontal: 16),
      child: Card(
        elevation: 2,
        child: Padding(
          padding: EdgeInsets.all(16),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "Critical Directives Queue",
                style: TextStyle(fontSize: 24, fontWeight: FontWeight.w600),
              ),
              SizedBox(height: 16),
              CriticalItem(
                headerText: "Database Consolidation",
                descriptionText: "Optimization in Progress",
              ),
              CriticalItem(
                headerText: "Network Link Stability",
                descriptionText: "Monitoring connections",
              ),
              CriticalItem(
                headerText: "Firewall Rules Update",
                descriptionText: "Applying new Policies",
              ),
              CriticalItem(
                headerText: "Database Consolidation",
                descriptionText: "Optimization in Progress",
              ),
              CriticalItem(
                headerText: "Network Link Stability",
                descriptionText: "Monitoring connections",
              ),
              CriticalItem(
                headerText: "Firewall Rules Update",
                descriptionText: "Applying new Policies",
              ),
              CriticalItem(
                headerText: "Database Consolidation",
                descriptionText: "Optimization in Progress",
              ),
              CriticalItem(
                headerText: "Network Link Stability",
                descriptionText: "Monitoring connections",
              ),
              CriticalItem(
                headerText: "Firewall Rules Update",
                descriptionText: "Applying new Policies",
              ),
            ],
          ),
        ),
      ),
    );
  }
}
