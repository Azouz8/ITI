function fn1() {
  var arr = Array.from(arguments);
  arr.reverse();
  return arr;
}
function fn2(...params) {
  return params.reverse();
}

console.log(fn1(1, 2, 3));
console.log(fn2(1, 2, 3));
