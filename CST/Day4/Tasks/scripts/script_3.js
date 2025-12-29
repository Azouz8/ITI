// Build your own function that takes a single string argument and
// returns the largest word in the string. If there are two or more words
// that are the same length, return the first word from the string with that
// length

var message = String(prompt("Enter a message"));
getLargest(message);
function getLargest(message = "") {
  arr = message.split(" ");
  var maxLength = 0;
  var maxIndex = 0;
  for (var i = 0; i < arr.length; i++) {
    if (arr[i].length > maxLength) {
      maxLength = arr[i].length;
      maxIndex = i;
    }
  }
  console.log(arr);
  console.log("Max Index: " + maxIndex);
  console.log(arr[maxIndex]);
//   this is a javascript string demo javascript
}
