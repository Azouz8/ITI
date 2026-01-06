let userName, userAge, userGender, favColor, visitsNo;
let childWin;
onload = function () {
  visitsNo = parseInt(getCookie("visitsNo")) || 0;
};

function openWelcomPage() {
  childWin = open("welcomePage.html", "", "width=500,height=500");
}

function loadDataToWelcomPage() {
  let expireDate = new Date();
  expireDate.setMonth(expireDate.getMonth() + 1);
  let visitsNo = parseInt(getCookie("visitsNo")) || 0;
  visitsNo++;
  setCookie("visitsNo", visitsNo, expireDate);
  this.document.getElementById("genderImgID").src = getCookie("userGender");
  console.log(getCookie("userName"));
  this.document.getElementById("nameTxtID").innerText = getCookie("userName");
  this.document.getElementById("nameTxtID").style.color = getCookie("favColor");
  this.document.getElementById("visitNoID").innerText = getCookie("visitsNo");
  this.document.getElementById("visitNoID").style.color = getCookie("favColor");
}

function saveUserData() {
  try {
    userName = document.getElementById("userNameID").value;
    if (userName === "") throw "Username is Required";
  } catch (error) {
    alert(error);
  }
  try {
    userAge = document.getElementById("userAgeID").value;
    if (isNaN(userAge) || userAge == "")
      throw "User Age is Required and it must be a number";
  } catch (error) {
    alert(error);
  }
  let isMale = document.getElementById("userGenderMale").checked;
  if (isMale) {
    userGender = "../Task Resources/cookies/1.jpg";
  } else {
    userGender = "../Task Resources/cookies/2.jpg";
  }
  favColor = document.getElementById("colorMenu").value;
  if (userName !== "" && userAge !== "" && !isNaN(userAge)) {
    let expireDate = new Date();
    expireDate.setMonth(expireDate.getMonth() + 1);
    setCookie("userName", userName, expireDate);
    setCookie("userAge", userAge, expireDate);
    setCookie("userGender", userGender, expireDate);
    setCookie("favColor", favColor, expireDate);
    setCookie("visitsNo", visitsNo, expireDate);
    openWelcomPage();
  }
}

function getCookie(cookieName) {
  try {
    if (arguments.length == 0 || typeof cookieName != "string") {
      throw "Cookie Name is invalid";
    } else {
      let cookiesLength = document.cookie.split(";").length;
      let cookies = document.cookie.split(";");
      let cookieValue;
      for (let i = 0; i < cookiesLength; i++) {
        let cookie = cookies[i].trim();
        if (cookieName == cookie.split("=")[0]) {
          cookieValue = cookie.split("=")[1];
          console.log(cookieValue);
          break;
        }
      }
      return cookieValue;
    }
  } catch (err) {
    console.log(err);
  }
}
function setCookie(cookieName, cookieValue, expiryDate = new Date().getDate()) {
  console.log("Cookie Created");
  document.cookie = cookieName + "=" + cookieValue + ";expires=" + expiryDate;
}
function deleteCookie(cookieName) {
  let expiryDate = new Date();
  expiryDate.setMonth(expiryDate.getMonth() - 1);
  document.cookie = cookieName + "=;expires=" + expiryDate;
  console.log("Cookie Deleted");
}
function hasCookie(cookieName) {
  let cookie = getCookie(cookieName);
  if (cookie) {
    console.log("Found");
    return true;
  } else {
    console.log("Not Found");
    return false;
  }
}
