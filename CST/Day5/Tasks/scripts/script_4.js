// Create a parent window that opens a flying child window. Hint: Start by
// creating a parent window that opens a child window.
// Child window should always be on top view and moves up and down within
// boundaries of user screen.
// Parent window should contain a button that stops child window movement.
var childWin;
function openWindow(child) {
  childWin = open(child, "", "height = 250 , width = 250");
  moveWindow();
}
var downFlag = false;
var upFlag = false;
let timerID
function moveWindow() {
  console.log(screen.availHeight);
  timerID = setInterval(function () {
    if (childWin.screenTop + 250 >= screen.availHeight - 100) {
      upFlag = true;
      downFlag = false;
    } else if (childWin.screenTop == 0) {
      upFlag = false;
      downFlag = true;
    }
    if (upFlag) {
      childWin.moveBy(-2, -2);
    }
    if (downFlag) {
      childWin.moveBy(2, 2);
    }
    childWin.focus();
  }, 10);
}

function stopMovingWindow() {
  clearInterval(timerID);
}
