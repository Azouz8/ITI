var moonImagePath = "../TaskResources/memory Game/Moon.gif";
var images = [
  "../TaskResources/memory Game/1.gif",
  "../TaskResources/memory Game/2.gif",
  "../TaskResources/memory Game/3.gif",
  "../TaskResources/memory Game/4.gif",
  "../TaskResources/memory Game/5.gif",
  "../TaskResources/memory Game/6.gif",
  "../TaskResources/memory Game/1.gif",
  "../TaskResources/memory Game/2.gif",
  "../TaskResources/memory Game/3.gif",
  "../TaskResources/memory Game/4.gif",
  "../TaskResources/memory Game/5.gif",
  "../TaskResources/memory Game/6.gif",
];

for (let i = 0; i < images.length; i++) {
  let random = Math.floor(Math.random() * images.length);
  temp = images[random];
  images[random] = images[i];
  images[i] = temp;
}
var img1ID, img1Src, img2ID, img2Src;
let isSecond = false,
  isChecking = false;
window.onload = function () {};

function openImage(img) {
  if (!isChecking) {
    if (!isSecond) {
      img.src = images[img.id.replace("img", "") - 1];
      img1ID = img.id;
      img1Src = img.src;
      isSecond = true;
    } else {
      img.src = images[img.id.replace("img", "") - 1];
      img2ID = img.id;
      img2Src = img.src;
      isChecking = true;
      setTimeout(function () {
        if (img1Src == img2Src) {
          var img1 = document.getElementById(img1ID);
          img1.onclick = function () {};
          var img2 = document.getElementById(img2ID);
          img2.onclick = function () {};
        } else {
          var img1 = document.getElementById(img1ID);
          img1.src = moonImagePath;
          var img2 = document.getElementById(img2ID);
          img2.src = moonImagePath;
        }
        isChecking = false;
      }, 1000);
      isSecond = false;
    }
  }
}
