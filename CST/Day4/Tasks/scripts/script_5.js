// Write a script that ask the user to
// • Enter the value of a circle’s radius in order to calculate its area
// • Enter another value to calculate its square root and alert the result
// • Enter an angle to calculate its cos value then display the output in
// the console
var radius = prompt("Enter Circle Radius");
var area = Math.PI * Math.pow(radius, 2);
console.log("Area: " + area)

var value = prompt("Enter value to get its square root");
var sqroot = Math.sqrt(value) 
console.log("Square root: " + sqroot)

var angle = prompt("Enter angle to get its cos value");
var radian = angle *(Math.PI/180)
var cos = Math.cos(radian)
console.log("Cosine: " + cos)
