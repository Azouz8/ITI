onload = function () {
  custFn(1, 1, 1);
};

function custFn(p1, p2) {
  try {
    if (arguments.length != 2) throw "Paremeters Number not equal 2";
    else console.log("All GOOD");
  } catch (error) {
    console.log(error);
  }
}
