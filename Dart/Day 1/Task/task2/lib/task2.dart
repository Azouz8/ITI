void main() {
  String? incomingPayload = null;
  int? fallbackMetric = null;

  incomingPayload ??= "GUEST_STREAM";
  fallbackMetric ??= 404;

  String? userToken = null;
  String activeToken = userToken ?? incomingPayload;

  int finalSystemLength = incomingPayload!.length;

  print("incomingPayload: $incomingPayload");
  print("fallbackMetric: $fallbackMetric");
  print("activeToken: $activeToken");
  print("finalSystemLength: $finalSystemLength");
}
