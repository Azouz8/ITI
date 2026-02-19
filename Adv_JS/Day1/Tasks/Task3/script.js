var getSetGenFn = function () {
  let keys = Object.keys(this);
  for (let i = 0; i < keys.length; i++) {
    if (keys[i] != "getSetGen") {
      var getKey = "get" + keys[i];
      this[getKey] = function () {
        return this[keys[i]];
      };
      var setKey = "set" + keys[i];
      this[setKey] = function (val) {
        this[keys[i]] = val;
      };
    }
  }
};

custObj = {
  id: "123",
  name: "Azouz",
  getSetGen: getSetGenFn,
};

custObj2 = {
  usrName: "abc",
  password: "123",
};

custObj.getSetGen();
console.log(custObj.getid());
console.log(custObj.getname());
custObj.setid(111);
custObj.setname("Aliii");
console.log(custObj.getid());
console.log(custObj.getname());

console.log("--------------");

custObj.getSetGen.call(custObj2);
console.log(custObj2.getusrName());
console.log(custObj2.getpassword());
custObj2.setusrName("aaa");
custObj2.setpassword("000");
console.log(custObj2.getusrName());
console.log(custObj2.getpassword());
