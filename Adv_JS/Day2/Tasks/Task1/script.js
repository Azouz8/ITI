var Sequence = function (start, end, step) {
  var seqList = [];
  var start = start;
  var end = end;
  var step = step;

  this.getList = function () {
    return seqList;
  };
  this.getStart = function () {
    return start;
  };
  this.getEnd = function () {
    return end;
  };
  this.getStep = function () {
    return step;
  };

  this.append = function (value) {
    try {
      if (seqList[seqList.length - 1] + step === value) {
        seqList.push(value);
      } else {
        throw "Value is not in sequence";
      }
    } catch (error) {
      console.log(error);
    }
  };

  this.prepend = function (value) {
    try {
      if (seqList[0] - step === value) {
        seqList.unshift(value);
      } else {
        throw "Value is not in sequence";
      }
    } catch (error) {
      console.log(error);
    }
  };

  this.pop = function () {
    try {
      if (seqList.length == 0) {
        throw "List is Empty";
      } else {
        seqList.pop();
      }
    } catch (error) {
      console.log(error);
    }
  };
  for (var i = start; i < end; i += step) {
    seqList.push(i);
  }
};

var seq = new Sequence(1, 10, 2);
console.log(seq.getList());
console.log("Insert Correct Value (11)");
seq.append(11);
console.log("Insert Wrong Value (12)");
seq.append(12);
console.log("Insert Correct Value (13)");
seq.append(13);
console.log("Prepend Correct Value (-1)");
seq.prepend(-1);
console.log(seq.getList());
console.log("Popping");
seq.pop();
console.log(seq.getList());
