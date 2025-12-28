// Write a script that takes from the user n values and returns their sum, stop
// receiving values from user when he enters 0 or sum exceeds 100, check that the
// entered data is numeric and inform the user with the total sum of the entered
// values in console.

var sum = 0;
while (sum < 100) {
  var num = Number(prompt("Enter a Number or Enter 0 to exit"));
  if (num == 0) {
    break;
  }
  if (!isNaN(num)) {
    sum += num;
    console.log(sum);
  } else {
    alert("Please enter a valid number.");
  }
}
