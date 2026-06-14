import 'dart:async';
import 'dart:convert' as convert;
import 'package:http/http.dart' as http;

// 1) ^2.4.5
//    - Minimum (inclusive): 2.4.5
//    - Maximum (exclusive): 3.0.0
//    - Range: >=2.4.5 <3.0.0
//
// 2) ^0.4.5  (Pre-1.0.0 package)
//    - Minimum (inclusive): 0.4.5
//    - Maximum (exclusive): 0.5.0
//    - Range: >=0.4.5 <0.5.0
//    Before 1.0.0 the package is unstable, so Dart treats the
//    minor digit "4" as the "major" digit
//
// 3) version lock
//        crypto: 3.0.3
//
//    Explicit mathematical range boundary:
//        dio: ">=5.0.0 <5.4.0"
//
//    Difference: "3.0.3" pins the dependency to that ONE single version.
//    ">=5.0.0 <5.4.0" lets pub pick ANY version inside that range
//
// ---- Task 2: Package Ecosystem Mechanics ----
//
// 1) dart pub add dio
//
// 2) dart pub get

// ---- Task 1: Execution Flow Chronology Analysis ----
//
// Given script:
//   import 'dart:async';
//   void main() {
//     print("Alpha");
//     Future(() { print("Beta"); });
//     scheduleMicrotask(() { print("Gamma"); });
//     Future.microtask(() { print("Delta"); });
//     print("Epsilon");
//   }
//
// Trace:
//   print("Alpha") -> immediately
//   Future(() => print("Beta")) -> last
//   scheduleMicrotask(...Gamma...) ->  Microtask queue   after sync code
//   Future.microtask(...Delta...) ->   Microtask queue   after Gamma
//   print("Epsilon")         ->         Sync call stack   immediately
//
// Predicted output:
//   Alpha
//   Epsilon
//   Gamma
//   Delta
//   Beta

Future<String> fetchUserProfile() {
  return Future.delayed(Duration(seconds: 2), () => "User Profile Loaded");
}

Future<String> fetchOrderHistory() {
  return Future.delayed(Duration(seconds: 3), () => "Order History Loaded");
}

Future<void> runWithFutureWait() async {
  try {
    final results = await Future.wait([
      fetchUserProfile().timeout(Duration(seconds: 5)),
      fetchOrderHistory().timeout(Duration(seconds: 5)),
    ]);
    print("Future.wait -> $results");
  } on TimeoutException catch (e) {
    print("Future.wait -> Request timed out: $e");
  } finally {
    print("Future.wait flow finished");
  }
}

Future<void> runWithRecordDestructuring() async {
  try {
    final (profile, history) = await (
      fetchUserProfile().timeout(Duration(seconds: 5)),
      fetchOrderHistory().timeout(Duration(seconds: 5)),
    ).wait;
    print("Record destructuring -> $profile | $history");
  } on TimeoutException catch (e) {
    print("Record destructuring -> Request timed out: $e");
  } finally {
    print("Record destructuring flow finished");
  }
}

Stream<int> trackMetrics() async* {
  int metric = 0;
  for (int i = 0; i < 4; i++) {
    await Future.delayed(Duration(seconds: 1));
    metric++;
    yield metric;
  }
}

Future<void> drainMetricsStream() async {
  await for (final metric in trackMetrics()) {
    print("Metric tick: $metric");
  }
}

// ---- Task 1: Immutability and State Computation ----
class InvoiceItem {
  final String descriptor;
  final double baseCost;
  final double markupFee;
  final double totalCost;

  InvoiceItem(this.descriptor, this.baseCost, this.markupFee)
    : totalCost = baseCost + markupFee;

  static double calculateVAT(double amount) {
    return amount * 0.14;
  }
}

// ---- Task 2: Polymorphic Factory Mapping ----
class Account {
  String username;
  String email;
  bool isLocked;

  Account(this.username, this.email, {this.isLocked = false});

  Account.locked(this.username, this.email) : isLocked = true;

  factory Account.fromMap(Map<String, Object?> map) {
    return Account(
      map["username"] as String,
      map["email"] as String,
      isLocked: map["isLocked"] as bool,
    );
  }
}

// ---- Task 3: Constant Memory Allocation ----
class Coordinates {
  final double x;
  final double y;

  const Coordinates(this.x, this.y);
}

// ---- Task 1: Library-Level Privacy Enforcement ----
class TransactionVault {
  double _balance;

  TransactionVault(this._balance);

  double get balance => _balance;

  set balance(double newBalance) {
    if (newBalance < 0) {
      throw ArgumentError("Balance cannot be negative");
    }
    print("[Audit] balance change: $_balance -> $newBalance");
    _balance = newBalance;
  }
}

// ---- Task 2: Behavioral Inheritance vs. Strict Structural Contracts ----

abstract class NotificationChannel {
  void send(String message);

  void log(String message) {
    print("[NotificationChannel] $message");
  }
}

class EmailChannel extends NotificationChannel {
  @override
  void send(String message) {
    print("Sending email: $message");
  }

  @override
  void log(String message) {
    print("[EmailChannel] $message");
  }
}

class ReportFormatter {
  void printReport() {
    print("Default report format");
  }
}

class InvoiceReport implements ReportFormatter {
  @override
  void printReport() {
    print("Invoice report (custom format)");
  }
}

// ---- Task 3: Mixins and Scope Rules ----

mixin AppLogger {
  void log(String message) {
    print("[LOG] $message");
  }
}

abstract class AuthService {
  String get currentUser;
}

mixin SecurityAudit on AuthService {
  void audit(String action) {
    print("[Audit] $currentUser performed: $action");
  }
}

class LoginService extends AuthService with SecurityAudit, AppLogger {
  @override
  String get currentUser => "Azouz";

  void login() {
    log("login attempt");
    audit("Login");
  }
}

// ---- Task 4: Extensions and Custom Types ----

extension EmailValidation on String {
  bool get isValidEmail => contains("@") && length >= 5;
}

class Coupon {
  final String code;
  final double value;

  Coupon(this.code, this.value);

  @override
  bool operator ==(Object other) {
    return other is Coupon && other.code == code && other.value == value;
  }

  @override
  int get hashCode => Object.hash(code, value);
}

// =====================================================================
// Q5: Class Modifiers and API Orchestration
// =====================================================================
//
// - interface class: outside code can only IMPLEMENT it (must rewrite
//   every member), forcing a clean external contract.
// - base class: outside code can only EXTEND it (cannot implement-only),
//   guaranteeing every subtype inherits the base implementation.
// - final class: completely closes the class outside its own file -
//   no extending, no implementing (still instantiable).
// - sealed class: implicitly abstract (no direct instances) AND all of
//   its direct subtypes must live in the SAME library/file.
//
// Sealed + switch exhaustiveness:
// Because the compiler can see every possible subtype of a sealed class
// a "switch" on a sealed type's
// instance can list a "case" for each subtype WITHOUT a "default" branch.
// If a new subtype is added later and a case is missing, the compiler
// raises a "non-exhaustive switch" error - catching the bug at compile
// time instead of at runtime.

// ---- Task 2: HTTP Integration and JSON Serialization ----
Future<void> fetchUsersFromApi() async {
  final url = Uri.parse("https://api.escuelajs.co/api/v1/users");
  try {
    final response = await http.get(url);

    if (response.statusCode == 200) {
      final List<dynamic> jsonResponse = convert.jsonDecode(response.body);

      for (final item in jsonResponse.take(3)) {
        final user = item as Map<String, dynamic>;
        print("User: ${user["email"]}");
      }
    } else {
      print("Request failed with status code: ${response.statusCode}");
    }
  } catch (e) {
    print("Connection error: $e");
  } finally {
    print("HTTP request flow finished");
  }
}

void main() async {
  print("===== Q2 Task 3: Stream =====");
  await drainMetricsStream();

  print("\n===== Q2 Task 2: Future.wait =====");
  await runWithFutureWait();

  print("\n===== Q2 Task 2: Record destructuring =====");
  await runWithRecordDestructuring();

  print("\n===== Q3: OOP =====");
  final item = InvoiceItem("Laptop", 800, 50);
  print("Total cost: ${item.totalCost}");
  print("VAT: ${InvoiceItem.calculateVAT(item.totalCost)}");

  final defaultAccount = Account("azouz", "azouz@mail.com");
  print("defaultAccount locked? ${defaultAccount.isLocked}");

  final lockedAccount = Account.locked("guest", "guest@mail.com");
  print("lockedAccount locked? ${lockedAccount.isLocked}");

  final mappedAccount = Account.fromMap({
    "username": "mona",
    "email": "mona@mail.com",
    "isLocked": false,
  });
  print("mappedAccount: ${mappedAccount.username}, ${mappedAccount.email}");

  const p1 = Coordinates(10, 20);
  const p2 = Coordinates(10, 20);
  print("identical(p1, p2) = ${identical(p1, p2)}");

  print("\n===== Q4: Encapsulation, Mixins, Extensions =====");
  final vault = TransactionVault(100);
  vault.balance = 250;
  print("Vault balance: ${vault.balance}");

  final emailChannel = EmailChannel();
  emailChannel.send("Welcome to the app!");
  emailChannel.log("Welcome email sent");

  final invoiceReport = InvoiceReport();
  invoiceReport.printReport();

  final login = LoginService();
  login.login();

  print('"test@mail.com".isValidEmail -> ${"test@mail.com".isValidEmail}');
  print('"bad".isValidEmail -> ${"bad".isValidEmail}');

  final couponA = Coupon("SAVE10", 10);
  final couponB = Coupon("SAVE10", 10);
  print("couponA == couponB -> ${couponA == couponB}");

  print("\n===== Q5: HTTP =====");
  await fetchUsersFromApi();
}


////////////// TASK OUTPUT
//PS D:\Programming\ITI> dart "d:\Programming\ITI\Dart\Day 3\tasks\lib\tasks.dart"
// ===== Q2 Task 3: Stream =====
// Metric tick: 1
// Metric tick: 2
// Metric tick: 3
// Metric tick: 4

// ===== Q2 Task 2: Future.wait =====
// Future.wait -> [User Profile Loaded, Order History Loaded]
// Future.wait flow finished

// ===== Q2 Task 2: Record destructuring =====
// Record destructuring -> User Profile Loaded | Order History Loaded
// Record destructuring flow finished

// ===== Q3: OOP =====
// Total cost: 850.0
// VAT: 119.00000000000001
// defaultAccount locked? false
// lockedAccount locked? true
// mappedAccount: mona, mona@mail.com
// identical(p1, p2) = true

// ===== Q4: Encapsulation, Mixins, Extensions =====
// [Audit] balance change: 100.0 -> 250.0
// Vault balance: 250.0
// Sending email: Welcome to the app!
// [EmailChannel] Welcome email sent
// Invoice report (custom format)
// [LOG] login attempt
// [Audit] Azouz performed: Login
// "test@mail.com".isValidEmail -> true
// "bad".isValidEmail -> false
// couponA == couponB -> true

// ===== Q5: HTTP =====
// User: john@mail.com
// User: maria@mail.com
// User: admin@mail.com
// HTTP request flow finished
// PS D:\Programming\ITI> 