// Fill an array (n numerical values) from the user, the n is determined by the user.
// Use sort method to sort the array’s values in descending and ascending orders
// Display the output in the console.
var noOfElements = getValidNum("Enter number of Elements");

var arr = [];
while (noOfElements--) {
  var num = getValidNum("Enter a Number");
  arr.push(num);
}
console.log("Ascending");
arr.sort(function (a, b) {
  return a - b;
});
console.log(arr);
console.log("Descending");
arr.sort(function (a, b) {
  return b - a;
});
console.log(arr);

function getValidNum(message) {
  var n = Number(prompt(message));
  if (isNaN(n)) {
    while (true) {
      alert("Please Enter a valid Number");
      n = Number(prompt(message));
      if (!isNaN(n)) {
        return n;
      }
    }
  }
  return n;
}
