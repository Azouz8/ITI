var fruits = ["apple", "strawberry", "banana", "orange", "mango"];
let pointA = fruits.every((el) => {
  return typeof el === "string";
});

console.log(`A : ${pointA}`);
let pointB = fruits.some((el) => {
  return el.startsWith("a");
});

console.log(`B : ${pointB}`);
let pointC = fruits.filter((el) => {
  return el.startsWith("b") || el.startsWith("s");
});

console.log(pointC);
let pointD = fruits.map((el) => `i like ${el}`);

pointD.forEach((val, i) => {
  console.log(` ${i + 1}  " element is ${val} " `);
});
