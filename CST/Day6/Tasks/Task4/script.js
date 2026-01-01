var images = [
  "../TaskResources/SlideShow/1.jpg",
  "../TaskResources/SlideShow/2.jpg",
  "../TaskResources/SlideShow/3.jpg",
  "../TaskResources/SlideShow/4.jpg",
  "../TaskResources/SlideShow/5.jpg",
  "../TaskResources/SlideShow/6.jpg",
];

var img;
let currentImageIndex = 0;
window.onload = function () {
  img = document.getElementById("imgID");
  img.src = images[currentImageIndex];
};

function next() {
  if (currentImageIndex < images.length - 1) {
    img.src = images[++currentImageIndex];
    console.log(currentImageIndex);
  }
}
function previous() {
  if (currentImageIndex > 0) {
    img.src = images[--currentImageIndex];
  }
}
let timerID
function slideShow(){
    timerID = setInterval(function(){
        img.src = images[++currentImageIndex%6]
    },1000)
}

function stopSlideShow(){
    clearInterval(timerID)
}
