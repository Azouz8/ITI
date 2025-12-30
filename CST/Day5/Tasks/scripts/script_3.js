// Write a function called dispVal that takes an object with two properties
// and a string as arguments. It should return the value of the property with key
// equal to the value of the string
// Example: if obj={nm:”ali”,age:10} then calling dispVal(obj,”age”) will return “10
// years old

let obj = {
  name: "Ali",
  age: 23,
};

dispVal(obj, "name");
dispVal(obj, "nam");

function dispVal(obj, str) {
  if (obj[str] != undefined) {
    console.log(obj[str]);
  } else {
    console.log("Property Not Found");
  }
}
