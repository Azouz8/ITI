var userName,
  email,
  gender,
  formObj = {};

window.onload = function () {
  if (document.location.search) {
    var form = document.location.search;
    console.log(form.substring(1, form.length - 1).split("&"));
    let length = form.substring(1, form.length - 1).split("&").length;
    for (i = 0; i < length; i++) {
      formObj[form.substring(1, form.length).split("&")[i].split("=")[0]] = form
        .substring(1, form.length)
        .split("&")
        [i].split("=")[1];
    }
    formObj.name = formObj.name.replace("+", " ");
    formObj.email = formObj.email.replace("%40", "@");
    console.log(formObj.email);
    var h1ID = document.getElementById("h1ID");
    var emailID = document.getElementById("emailID");
    var genderID = document.getElementById("genderID");
    h1ID.innerText += formObj.name;
    emailID.innerText += formObj.email;
    genderID.innerText += formObj.gender;
  }
};
