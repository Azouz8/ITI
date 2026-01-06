document.addEventListener("keydown", function (event) {
  console.log(event.code);
  if (event.ctrlKey && event.key == "s") {
    event.preventDefault();
    console.log("Blocked Event");
  }
});
