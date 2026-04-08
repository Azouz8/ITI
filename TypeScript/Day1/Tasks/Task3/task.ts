// 3- Use Record to create an object where keys are "red", "green",
//    and "blue", and values are their corresponding hex color codes (strings). 
//    Test by accessing the red key.

type Colors = "red" | "green" | "blue";
const Hex: Record<Colors, string> = {
  red: "#FF0000",
  green: "#008000",
  blue: "#0000FF",
};

console.log(Hex.blue);
