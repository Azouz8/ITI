window.onload = function () {
  let vid = document.getElementById("vid");
  let play = document.getElementById("play");
  let stop = document.getElementById("stop");
  let mute = document.getElementById("mute");
  let vol = document.getElementById("vol");
  let speed = document.getElementById("speed");

  play.addEventListener("click", function () {
    vid.play();
  });

  stop.addEventListener("click", function () {
    vid.pause();
  });

  mute.addEventListener("click", function () {
    vid.muted = !vid.muted;
  });

  vol.addEventListener("input", function () {
    vid.volume = vol.value;
  });

  speed.addEventListener("input", function () {
    // console.log(speed.value)
    vid.playbackRate = speed.value;
  });

  let fb = document.getElementById("fb");
  let b = document.getElementById("b");
  let f = document.getElementById("f");
  let ff = document.getElementById("ff");

  fb.addEventListener("click", function () {
    vid.currentTime -= 10;
  });

  b.addEventListener("click", function () {
    vid.currentTime -= 5;
  });

  ff.addEventListener("click", function () {
    vid.currentTime += 10;
  });

  f.addEventListener("click", function () {
    vid.currentTime += 5;
  });

  let playback = document.getElementById("playback");
  let playbackLabel = document.getElementById("playback_label");
  playback.max = Math.floor(vid.duration);

  vid.addEventListener("timeupdate", function () {
    playback.value = Math.floor(vid.currentTime);
    let min = Math.floor(vid.currentTime / 60);
    let sec = Math.floor(vid.currentTime % 60);

    if (min < 10) {
      min = "0" + min;
    }
    if (sec < 10) sec = "0" + sec;
    playbackLabel.textContent = min + ":" + sec;
  });

  playback.addEventListener("input", function () {
    vid.currentTime = playback.value;
  });
};
