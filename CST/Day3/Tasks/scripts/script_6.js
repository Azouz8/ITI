// Write a code snippet that takes a number of rows as input and prints a
// pattern of stars. Each row should contain a number of stars equal to the row
// number.

var numOfRows = Number(prompt("Enter no. of Rows"));

for(let i=0; i<numOfRows; i++){
    for(let j=0; j<=i; j++){
        document.writeln("*")
    }
    document.writeln("<hr>")
}
