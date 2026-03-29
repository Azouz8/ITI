function getMinAndMax(...arr) {
  return [Math.min(...arr), Math.max(...arr)];
}

let min, max;
[min, max] = getMinAndMax(1, 2, 3, 4, 6, 7, 8, 9, 10, -99, 99);
console.log(` Max  is ${max}  \n Min  is ${min}`);
