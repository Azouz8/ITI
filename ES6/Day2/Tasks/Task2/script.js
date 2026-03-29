function* fib1(n) {
  let a = 0,
    b = 1;

  for (let i = 0; i < n; i++) {
    yield a;
    [a, b] = [b, a + b];
  }
}

let str = "";
for (let num of fib1(3)) {
  str += num + " ";
}

console.log(`fib 1 iterate 3 times ${str}`);
function* fib2(max) {
  let a = 0,
    b = 1;

  while (a <= max) {
    yield a;
    [a, b] = [b, a + b];
  }
}
str = "";
for (let num of fib2(20)) {
  str += num + " ";
}
console.log(`fib less than 20 ${str}`);
