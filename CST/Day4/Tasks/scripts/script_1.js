// Write a script that accepts a string from user through prompt and
// count the number of a specific character that the user will define in
// another prompt. Ask the user whether to consider difference between
// letter cases or not then display the number of letter appearance.

var str = prompt("Enter a Message");
var chr = prompt("Enter a character to search for");
if (chr.length != 1) {
  while (true) {
    alert("Please enter only one character");
    chr = prompt("Enter a character to search for");
    if (chr.length == 1) break;
  }
}
var isCheck = confirm("Click ok to Check Case Sensitivity");
console.log(str.split(chr))
var count = isCheck
  ? str.split(chr).length - 1
  : str.toLowerCase().split(chr.toLowerCase()).length - 1;
console.log(count);
