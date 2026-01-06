onload = function () {
  add(1,2);
};

function add() {
  try {
    if (checkValidity(arguments)) {
      let sum = 0;
      for (let i = 0; i < arguments.length; i++) {
        sum += arguments[i];
      }
      console.log("SUM = " + sum);
    } else {
      throw "Invalid Input";
    }
  } catch (error) {
    console.log(error);
  }
}

function checkValidity(args) {
  let isValid = true;
  if(args.length == 0) isValid = false  
  for (let i = 0; i < args.length; i++) {
    if (isNaN(args[i])) {
      isValid = false;
      break;
    }
  }
  return isValid;
}
