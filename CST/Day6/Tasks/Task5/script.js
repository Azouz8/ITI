var offImg = "../TaskResources/marbels/marble1.jpg";
var lightImg = "../TaskResources/marbels/marble3.jpg";
var prevImg, img;
var imagesID = ["img1", "img2", "img3", "img4", "img5", "img6", "img7", "img8"];
let timerID;
let currentLightImageID = 0;
window.onload = function () {
  start();
};
function stop() {
  clearInterval(timerID);
}
function start() {
  timerID = setInterval(function () {
    var prevIndex = (currentLightImageID - 1 + 8) % 8;
    prevImg = document.getElementById(imagesID[prevIndex]);
    prevImg.src = offImg;

    img = document.getElementById(imagesID[currentLightImageID]);
    img.src = lightImg;

    currentLightImageID = (currentLightImageID + 1) % 8;
    console.log(currentLightImageID);
  }, 500);
}
