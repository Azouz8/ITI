// Write a script to determine whether the entered string is
// palindrome or not. Request the string to be entered via prompt, ask the
// user whether to consider case sensitivity of the entered string or not via
// confirm, handle both cases in your script
// i.e. RADAR NOON MOOM are palindrome.

var message = prompt("Enter a message to check if it is Palindrome");
var isCheck = confirm("Click ok to Check Case Sensitivity");

var arr = message.split(" ");
var isPalindrome = true;

if (isCheck) {
  for (let i = 0; i < arr.length; i++) {
    var str = arr[i];
    let reversed = str.split("").reverse().join("");
    if (str != reversed) {
      isPalindrome = false;
      break;
    }
  }
  console.log(isPalindrome);
} else {
  arr = message.toLocaleLowerCase().split(" ");
  for (let i = 0; i < arr.length; i++) {
    var str = arr[i];
    let reversed = str.split("").reverse().join("");
    if (str != reversed) {
      isPalindrome = false;
      break;
    }
  }
  console.log(isPalindrome);
}
