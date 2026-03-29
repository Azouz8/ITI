const symbolGen = {
  obj: {
    name: "Azouz",
    age: 23,
  },

  *[Symbol.iterator]() {
    for (let [key, val] of Object.entries(this.obj)) {
      yield `${key}: ${val}`;
    }
  },
};

let iter = symbolGen[Symbol.iterator]();
console.log(iter.next());
console.log(iter.next());
