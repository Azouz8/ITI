class CriticalDataModel {
  CriticalDataModel({
    required this.id,
    required this.headerText,
    required this.descriptionText,
    required this.isChecked,
  });
  final int id;
  final String headerText, descriptionText;
  bool isChecked = false;

  void toggleState() {
    isChecked = !isChecked;
  }
}
