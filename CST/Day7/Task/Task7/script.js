var inputField;
onload = function () {
  inputField = this.document.getElementById("txt1");
  // document.getElementById("aElem").onclick = function () {
  //   alert();
  //   return false;
  //   //
  //   // location.assign(this.href)
  // };
  // document.getElementById("diplayBtn").value = "ay 7aga";
  //   document.getElementById("displayBtn").onclick=function () {
  // console.log(this)
  //     var sel = document.getElementById("menu");
  //     console.log(sel.selectedIndex);
  //     console.log(sel.options[sel.selectedIndex].text);
  //     console.log(sel.options[sel.selectedIndex].value);
  //     //multiple selection (TASK)
  //   }
  // displayNum()
  //TASK

};
function displayNum(elem) {
  inputField.value += elem.value.trim();
}
var eraseVal = function () {
  inputField.value = inputField.value.substr(0, inputField.value.length - 1);
};
var clearField = function () {
  inputField.value = "";
};

// function displaOptions() {
//   var sel = document.getElementById("menu");
//   console.log(sel.selectedIndex);
//   console.log(sel.options[sel.selectedIndex].text);
//   console.log(sel.options[sel.selectedIndex].value);
// }
// function displayContent(txtField) {
//   var txt = txtField.value;
//   document.getElementById("div1id").innerHTML = txt;
// }