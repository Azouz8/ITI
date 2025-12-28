// Ask the user to enter three numerical values x, y and z. The script should
// check if x is divisible by y only or z only or both y and z.

var n1 = Number(prompt("Enter 1st Numerical Val"));
var n2 = Number(prompt("Enter 2nd Numerical Val"));
var n3 = Number(prompt("Enter 3rd Numerical Val"));

if (n1 % n2 == 0 && n1 % n3 == 0) {
  document.writeln("<p>" + n1 + " is Divisible by " + n2 + ", " + n3);
} else if (n1 % n2 == 0) {
  document.writeln("<p>" + n1 + " is Divisible by " + n2 + " only");
} else if (n1 % n3 == 0) {
  document.writeln("<p>" + n1 + " is Divisible by " + n3 + " only");
} else {
  document.writeln(
    "<p>" + n1 + " is not Divisible by either " + n2 + " or " + n3
  );
}
