window.onload = function () {
  this.document
    .getElementById("buttonID")
    .addEventListener("contextmenu", function (event) {
      event.preventDefault();
    });
};
