const operators = {
  "+": (a, b) => a + b,
  "-": (a, b) => a - b,
  "*": (a, b) => a * b,
  "/": (a, b) => a / b,
};
let ans;
onload = function () {
  ans = this.document.getElementById("ans");
};
function EnterEqual() {
  let lastPMIndex = -1,
    i = 0,
    isMulDivFinished = false,
    answerValue = ans.value;
  while (isNaN(answerValue)) {
    if (answerValue[i] == "/" || answerValue[i] == "*") {
      var op = answerValue[i];
      var splitNum1 = answerValue.split(op)[0];
      var splitNum2 = answerValue.split(op)[1];
      var num1 = splitNum1.substr(lastPMIndex + 1, splitNum1.length);
      var num2 = parseFloat(splitNum2);
      var res = operators[op](parseFloat(num1), parseFloat(num2));
      answerValue = answerValue.replace(num1 + op + num2, res);
      i = 0;
      lastPMIndex = -1;
    }
    if (answerValue[i] == "+" || answerValue[i] == "-" && i>0) {
      if (isMulDivFinished) {
        var op = answerValue[i];
        if(answerValue.split(op)[0] != ""){
          var splitNum1 = answerValue.split(op)[0];
          var splitNum2 = answerValue.split(op)[1];
        }
        else{
          var splitNum1 = "-" + answerValue.split(op)[1];
          var splitNum2 = answerValue.split(op)[2];
        }
        var num1 = splitNum1.substr(lastPMIndex + 1, splitNum1.length);
        var num2 = parseFloat(splitNum2);
        var res = operators[op](parseFloat(num1), parseFloat(num2));
        answerValue = answerValue.replace(num1 + op + num2, res);
        i = 0;
        lastPMIndex = -1;
      }
    }
    if (answerValue[i] == "+" || answerValue[i] == "-" && i>0) {
      lastPMIndex = i;
    }
    if (i == answerValue.length) {
      isMulDivFinished = true;
      lastPMIndex = -1;
      i = 0;
    }
    i++;
  }
  ans.value = answerValue
}

// function EnterEqual() {
//   let lastPMIndex = -1,
//     i = 0,
//     isMulDivFinished = false;
//   answerValue = ans.value;
//   while (isNaN(answerValue)) {
//     console.log(i);
//     if (answerValue[i] == "/" || answerValue[i] == "*") {
//       var op = answerValue[i];
//       let num1 = parseFloat(answerValue.substr(lastPMIndex + 1, i)).toFixed(2);
//       let num2 = parseFloat(answerValue.substr(i + 1, answerValue.length)).toFixed(2);
//       let res = operators[op](parseFloat(num1), parseFloat(num2));
//       answerValue = answerValue.substr(0,i);
//       answerValue += answerValue.substr(lastPMIndex + 1, i);
//       answerValue = answerValue.replace(
//           answerValue.substr(num1.length + 1, num2.length),
//           num2
//         );
//       console.log("lastI" + lastPMIndex);
//       console.log("i" + i);
//       console.log(num1);
//       console.log(num2);
//       console.log(res);
//       answerValue = answerValue.replace(num1 + op + num2, res);
//       //   5-2*7*2
//       i = 0;
//       lastPMIndex = 0;
//     }

//     // 30*4-5/6*2
//     if (answerValue[i] == "+" || answerValue[i] == "-") {
//       if (isMulDivFinished) {
//         var op = answerValue[i];
//         let num1 = parseFloat(answerValue.substr(0, i)).toFixed(2);
//         let num2 = parseFloat(
//           answerValue.substr(i + 1, answerValue.length)
//         ).toFixed(2);
//         answerValue = answerValue.replace(answerValue.substr(0, i), num1);
//         var x = answerValue;
//         answerValue = answerValue.replace(
//           answerValue.substr(num1.length + 1, num2.length),
//           num2
//         );
//         var x = answerValue;
//         let res = operators[op](parseFloat(num1), parseFloat(num2));

//         console.log("HEREEEE" + i);
//         console.log("i" + i);
//         console.log(num1);
//         console.log(num2);
//         console.log(res);
//         answerValue = answerValue.replace(num1 + op + num2, res);
//         i = 0;
//       }
//     }
//     if (i == answerValue.length) {
//       console.log("UDONEE");
//       isMulDivFinished = true;
//       lastPMIndex = -1;
//       i = 0;
//     }
//     if (answerValue[i] == "+" || answerValue[i] == "-") {
//       lastPMIndex = i;
//     }
//     console.log(answerValue);
//     i++;
//   }
//   ans.value = answerValue;
// }

function EnterNumber(num) {
  ans.value += num;
}
function EnterOperator(op) {
  let lastChar = ans.value.substr(ans.value.length - 1, 1);
  if (ans.value.length != 0) {
    if (
      lastChar != "+" &&
      lastChar != "-" &&
      lastChar != "/" &&
      lastChar != "*"
    ) {
      ans.value += op;
    } else {
      ans.value = ans.value.substr(0, ans.value.length - 1) + op;
    }
  }
}
function EnterClear() {
  ans.value = "";
}
