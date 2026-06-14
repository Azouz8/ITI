void main() {
  print("-------- Q1 --------");
  final list1 = [1, 2, 3];
  list1.add(4);
  print(list1);

  const list2 = [1, 2, 3];

  /////////////////////////////////////

  print("-------- Q2 --------");
  var a1 = [10, 20, 30];
  var a2 = [10, 20, 30];
  print(identical(a1, a2));

  const b1 = [10, 20, 30];
  const b2 = [10, 20, 30];
  print(identical(b1, b2));

  /////////////////////////////////////

  print("-------- Q3 --------");
  Object var1 = "Hello";
  dynamic var2 = "Hello";

  var1 = 10;
  var2 = 10;
  print((var1 as int) + 5);
  print(var2 + 5);

  /////////////////////////////////////

  print("-------- Q4 --------");

  var (lat: lat, lon: lon) = processCoordinates();
  print("Lat: $lat, Lon: $lon");

  /////////////////////////////////////

  print("-------- Q5 --------");
  Object payload = ("Ali", 25);

  switch (payload) {
    case (String name, int age):
      print("User Name: $name, Age: $age");
    case [int x, int y]:
      print("Sum: ${x + y}");
    case int value when value % 5 == 0:
      print("Multiple of 5: $value");
    default:
      print("Unmatched structure");
  }

  /////////////////////////////////////

  print("-------- Q6 --------");
  String? companyName;
  print(companyName?.length);

  String finalName = companyName ?? "Default Corporate";
  print(finalName);

  String? branch;
  branch ??= "Main Branch";
  print(branch);

  /////////////////////////////////////

  print("-------- Q7 --------");
  int score = 50;
  int result = score++ + ++score;
  print(result);
  print(score);

  /////////////////////////////////////

  print("-------- Q8 --------");
  var baseline = ["Build", "Test", "Deploy"];
  bool isProduction = true;

  var pipeline = [
    "Initialize",
    ...baseline,
    if (isProduction) "Security Scan",
    "Clean",
  ];
  print(pipeline);

  var upperPipeline = [for (var step in pipeline) step.toUpperCase()];
  print(upperPipeline);

  /////////////////////////////////////

  print("-------- Q9 --------");
  List<int> values = [10, 55, 30, 70, 90, 40];
  var filtered = List.unmodifiable(values.where((v) => v >= 50).toList());
  print(filtered);

  var reversedValues = values.reversed.toList();
  print(reversedValues);

  /////////////////////////////////////

  print("-------- Q10 --------");
  Map<String, int> stock = {"P1": 100, "P2": 50};
  stock.putIfAbsent("P3", () => 0);
  print(stock);

  for (var key in stock.keys) {
    print(key);
  }

  for (var value in stock.values) {
    print(value);
  }

  /////////////////////////////////////

  print("-------- Q11 --------");
  configureAlert(message: "Disk space low");
  configureAlert(message: "System failure", level: "CRITICAL");

  /////////////////////////////////////

  print("-------- Q12 --------");
  var tracker = trackVelocity();
  tracker(5);
  tracker(10);
  tracker(2);

  /////////////////////////////////////

  print("-------- Q13 --------");
  var wrapped = profileExecution(executeDatabaseQuery);
  wrapped();
}

({double lat, double lon}) processCoordinates() {
  return (lat: 30.0444, lon: 31.2357);
}

void configureAlert({required String message, String level = "INFO"}) {
  print("[$level] $message");
}

Function trackVelocity() {
  int displacement = 0;

  void increment(int step) {
    displacement += step;
    print("Displacement: $displacement");
  }

  return increment;
}

void executeDatabaseQuery() {
  print("Query Executed");
}

Function profileExecution(Function originalFunction) {
  void wrapper() {
    print("Timer Started");
    originalFunction();
    print("Timer Stopped");
  }

  return wrapper;
}
