// Write a function called showAddr that accepts an address object with the
// following properties: street, buildingNum, and city. It should return the
// complete address of the user with the registered date.
// Example: if the addrObj={street:”abc st.”,buildingNum:15,city:”xyz”}, calling
// showAddr(addrObj) will return “15 abc st., xyz city registered in 15/10/2024”.
var today = new Date().toLocaleDateString();
let addrObj = {
  street: "abc st.",
  buildingNo: 10,
  city: "Cairo",
  date: today,
};

showAddr(addrObj);
function showAddr(addrObj) {
  console.log(
    addrObj.buildingNo +
      " " +
      addrObj.street +
      ", " +
      addrObj.city +
      " city registered in " +
      addrObj.date
  );
}
