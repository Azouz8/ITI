// Implement wait5sec method.
function wait5sec() {
  let curTimeSec = new Date().getSeconds();
  while (true) {
    let newTimeSec = new Date().getSeconds();
    if (newTimeSec == (curTimeSec + 5) % 60) {
      console.log("HERREEE");
      break;
    }
  }
}

console.log("start");
wait5sec();
fun();
console.log("end");
setTimeout(function () {
  console.log("timeout after 1 sec");
}, 1000);
function fun() {
  setTimeout(function () {
    console.log("timeout immediately");
  }, 0);
}
