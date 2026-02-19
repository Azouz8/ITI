var pushFn = function (val) {
  if (lnkList.data.length == 0) {
    lnkList.data.push({ val: val });
  } else {
    try {
      if (lnkList.data[lnkList.data.length - 1].val >= val) {
        throw "Last value must be the biggest one";
      } else {
        lnkList.data.push({ val: val });
      }
    } catch (error) {
      console.log(error);
    }
  }
};

var enqFn = function (val) {
  if (lnkList.data.length == 0) {
    lnkList.data.push({ val: val });
  } else {
    try {
      if (lnkList.data[0].val <= val) {
        throw "First value must be the lowest one";
      } else {
        lnkList.data.unshift({ val: val });
      }
    } catch (error) {
      console.log(error);
    }
  }
};

var insertFn = function (val, index) {
  if (lnkList.data.length == 0) {
    lnkList.data.push({ val: val });
  } else {
    try {
      if (lnkList.data.length - 1 < index || index < 0) {
        throw "There is no such index";
      } else {
        if (lnkList.data[index].val < val) {
          throw "Entered data is not following the sequence";
        } else {
          lnkList.data.splice(index, 0, { val: val });
        }
      }
    } catch (error) {
      console.log(error);
    }
  }
};

var popFn = function () {
  try {
    if (lnkList.data.length == 0) {
      throw "Linked list is Empty";
    } else {
      lnkList.data.pop();
    }
  } catch (error) {
    console.log(error);
  }
};

var removeFn = function (val, index) {
  try {
    if (lnkList.data.length == 0) {
      throw "Linked list is Empty";
    } else {
      if (lnkList.data[index].val == val) {
        lnkList.data.splice(index, 1);
      } else {
        throw "Element Not Found";
      }
    }
  } catch (error) {
    console.log(error);
  }
};

var decFn = function () {
  try {
    if (lnkList.data.length == 0) {
      throw "Linked list is Empty";
    } else {
      lnkList.data.shift();
    }
  } catch (error) {
    console.log(error);
  }
};

var displayFn = function () {
  let data = "";
  for (let i = 0; i < lnkList.data.length; i++) {
    data += lnkList.data[i].val + "  ";
  }
  console.log(data);
};

lnkList = {
  data: [],
  enqueue: enqFn,
  push: pushFn,
  insert: insertFn,
  pop: popFn,
  remove: removeFn,
  decueue: decFn,
  display: displayFn,
};

lnkList.pop();
lnkList.push(2);
lnkList.display();
lnkList.push(1);
lnkList.display();
lnkList.push(5);
lnkList.display();
lnkList.enqueue(4);
lnkList.enqueue(0);
lnkList.display();
lnkList.push(10);
lnkList.display();
lnkList.insert(1, 0);
lnkList.pop();
lnkList.display();
lnkList.remove(1, 0);
lnkList.display();
lnkList.decueue();
lnkList.display();
