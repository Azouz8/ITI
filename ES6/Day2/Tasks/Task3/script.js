const myObj = {
  [Symbol.replace]: function (str) {
    if (str.length > 15) {
      return str.slice(0, 15) + "...";
    } else {
      return str;
    }
  },
};

console.log("1234567890ABCDEF".replace(myObj));

console.log("1234567890AB".replace(myObj));
