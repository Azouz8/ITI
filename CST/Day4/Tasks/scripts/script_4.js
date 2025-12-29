var userName = prompt("Enter username");
var userNameRegExp = /^[a-zA-Z]+$/;
if (!userNameRegExp.test(userName)) {
  while (true) {
    alert("Username should only contain characters!");
    userName = prompt("Enter username");
    if (userNameRegExp.test(userName)) break;
  }
}

var phoneNo = prompt("Enter Phone Number");
var phoneNoRegExp = /^[0-9]{8}$/;
if (!phoneNoRegExp.test(phoneNo)) {
  while (true) {
    alert("Phone Number should be 8 numbers");
    phoneNo = prompt("Enter Phone Number");
    if (phoneNoRegExp.test(phoneNo)) break;
  }
}

var mobileNo = prompt("Enter Mobile Number");
var mobileNoRegExp = /^01[0-2][0-9]{8}$/;
if (!mobileNoRegExp.test(mobileNo)) {
  while (true) {
    alert(
      "Mobile Number should be 11 numbers and start with 010 or 011 or 012"
    );
    mobileNo = prompt("Enter Mobile Number");
    if (mobileNoRegExp.test(mobileNo)) break;
  }
}

var email = prompt("Enter Email Address");
var emailRegExp = /^[a-zA-Z0-9_]+@[a-zA-Z0-9_]+\.[a-zA-Z]{2,}$/;
if (!emailRegExp.test(email)) {
  while (true) {
    alert("Email Address should be in this format abc@abc.com");
    email = prompt("Enter Email Address");
    if (emailRegExp.test(email)) break;
  }
}

var colorFormat = prompt("Choose from these Colors: Red or Green or Blue");
colorFormat = colorFormat.toLocaleLowerCase();
if (colorFormat != "red" && colorFormat != "green" && colorFormat != "blue") {
  while (true) {
    alert("please Enter a valid Color");
    colorFormat = prompt("Choose from these Colors: red or green or blue");
    if (colorFormat == "red" || colorFormat == "green" || colorFormat == "blue")
      break;
  }
}
var currentDate = new Date().getDay();

console.log(
  "%cWelcome " + userName + " Day: " + currentDate,
  "color:" + colorFormat + ";"
);
console.log("%c" + userName, "color:" + colorFormat + ";");
console.log("%c" + phoneNo, "color:" + colorFormat + ";");
console.log("%c" + mobileNo, "color:" + colorFormat + ";");
console.log("%c" + email, "color:" + colorFormat + ";");
