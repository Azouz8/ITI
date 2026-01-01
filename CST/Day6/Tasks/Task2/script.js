// Write a script that shows a “typing message” appearing in a new 
// child window. The new window should close after few seconds of 
// displaying your message

var message = prompt("Enter a Message");

var childWin;
function openWindow() {
  childWin = open("child.html", "", "width = 300, height = 300");
  childWin.onload = function () {
    showMessage(message);
  };
}
let timerID;
let i = 0;
function showMessage(message) {
  var element = childWin.document.getElementById("childWinTextID");
  timerID = setInterval(function () {
    if (i < message.length) {
      element.innerText += message[i++];
    } else {
      console.log("Closing After 3 sec");
      setTimeout(function () {
        childWin.close();
        clearInterval(timerID);
      }, 3000);
    }
  }, 500);
}

openWindow();
