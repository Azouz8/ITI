// Create a parent a window that opens a scrollable advertising child
// window

var childWin;
function openWindow(child) {
  childWin = open(child, "", "height = 350 , width = 500");
  scrollInWindow();
}
let timerID;
function scrollInWindow() {
  timerID = setTimeout(function () {
    childWin.scrollBy(0, 1);
    scrollInWindow();
  }, 10);
}
