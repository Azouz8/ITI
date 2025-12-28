// Using ternery operator, write a script that accepts 2 numbers from the user
// and display the maximum value of the entered data

var n1 = Number(prompt("Enter the first Num"));
var n2 = Number(prompt("Enter the Second Num"));
n1 > n2
  ? document.writeln("<p>The max is: " + n1 + "</p>")
  : document.writeln("<p>The max is: " + n2 + "</p>");
