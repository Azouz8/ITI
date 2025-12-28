// Ask the user to enter 3 values where x and y are two numeric values while z is
// a string value. The script should display the following:
// • The range of numbers between x and y depending on the value of z according
// to the following:
// o If z=”odd” the function will display only the odd values between x and y. x
// and/or y are included if any is odd.
// o If z=”even” the function will display only the even values between x and y. x
// and/or y are included if any is even.
// o If z=”no” the function will display all values between x and y. x and y are
// included.

var n1 = getValidNum("Enter 1st Numerical Value");
var n2 = getValidNum("Enter 2nd Numerical Value");
if (n1 > n2) {
  temp = n1;
  n1 = n2;
  n2 = temp;
}
var op = getValidOp();
var sum = 0;
var message = "";
if (op == "even") {
  for (let i = n1; i <= n2; i++) {
    if (i % 2 == 0) {
      message += i + ", ";
      sum += i;
    }
  }
} else if (op == "odd") {
  for (let i = n1; i <= n2; i++) {
    if (i % 2 != 0) {
      message += i + ", ";
      sum += i;
    }
  }
} else if (op == "no") {
  for (let i = n1; i <= n2; i++) {
    message += i + ", ";
    sum += i;
  }
} else {
  alert("Please enter a valid Opertaion.");
}

console.log(message);
console.log("Total Sum: " + "%c" + sum, "color:red;");

function getValidNum(message) {
  var n = Number(prompt(message));
  if (isNaN(n)) {
    while (true) {
      alert("please Enter a valid Num");
      n = Number(prompt(message));
      if (!isNaN(n)) {
        return n;
      }
    }
  }
  return n;
}

function getValidOp() {
  var op = prompt("Enter Operation");
  if (op != "even" && op != "odd" && op != "no") {
    while (true) {
      alert("please Enter a valid Operation");
      op = prompt("Enter Operation");
      if (op == "even" || op == "odd" || op == "no") return op;
    }
  }
  return op;
}
