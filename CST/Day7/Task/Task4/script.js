document.addEventListener("keydown", function (event) {
  console.log("KeyDown");
  console.log(event.key);
});
document.addEventListener("keypress", function (event) {
  console.log("KeyPress");
  console.log(event.key);
});
