onload = function () {
  var form = document.getElementById("regForm");
  form.addEventListener("submit", function (event) {
    var cont = confirm("Cont. Submitting?");
    if (!cont) {
      event.preventDefault();
    }
  });
};
