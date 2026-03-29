window.onload = function () {
  let red = document.getElementById("red");
  let green = document.getElementById("green");
  let blue = document.getElementById("blue");
  let mytxt = document.getElementById("txt");
  red.addEventListener("change", function () {
    mytxt.style.color =
      "rgb(" + red.value + "," + green.value + "," + blue.value + ")";
  });

  green.addEventListener("change", function () {
    mytxt.style.color =
      "rgb(" + red.value + "," + green.value + "," + blue.value + ")";
  });
  blue.addEventListener("change", function () {
    mytxt.style.color =
      "rgb(" + red.value + "," + green.value + "," + blue.value + ")";
  });
};
