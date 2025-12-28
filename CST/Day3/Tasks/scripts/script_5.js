// Write a code snippet that counts the number of values that are multiples of 3
// and 5 within a specified range, based on two input values. The code should also
// display these values and their total sum

var n1 = Number(prompt("Enter range Start"));
var n2 = Number(prompt("Enter range End"));
if (n1 > n2) {
  temp = n1;
  n1 = n2;
  n2 = temp;
}
var mul3Message = "Number multiple of 3: ";
var mul5Message = "Number multiple of 5: ";
var totalSum = 0;
for (let i = n1; i <= n2; i++) {
  if (i % 3 == 0) {
    mul3Message += i + ", ";
    totalSum += i;
  }
  if (i % 5 == 0) {
    mul5Message += i + ", ";
    totalSum += i;
  }
}

document.writeln("<p>" + mul3Message + "</p>");
document.writeln("<p>" + mul5Message + "</p>");
document.writeln("<p>Total Sum: " + totalSum + "</p>");
