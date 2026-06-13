enum Environment { development, staging, production }

void main() {
  const double maxRatio = 0.85;
  const String systemCode = """
                            THIS
                            IS
                            SYSTEM CODE
                            """;
  Runes structureSymbol = Runes("\u{1F3D7}");
  String structureString = String.fromCharCodes(structureSymbol);
  Set<int> uniqueInts = {1, 2, 3, 4, 5, 5};
  Map<String, dynamic> piplineConfig = {
    "env": Environment.production,
    "ratio": maxRatio,
    "badge": structureString,
    "nodeWights": uniqueInts.toList(),
  };

  print(piplineConfig);
}
