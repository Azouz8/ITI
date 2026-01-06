onload = function () {
  let timerID;

  var custEvent = new Event("no_activity");

  function resetAvtivityTimer() {
    clearTimeout(timerID);
    timerID = setTimeout(function () {
      document.dispatchEvent(custEvent);
    }, 3000);
  }

  document.addEventListener("input", resetAvtivityTimer);

  document.addEventListener("no_activity", () => {
    alert("No input for 3 seconds");
  });

  resetAvtivityTimer();
};
