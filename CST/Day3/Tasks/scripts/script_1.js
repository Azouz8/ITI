var message = prompt("Enter a message to display");

// 1.1. Ask the user to enter a message then display it using the different html
// heading tags (from <h1> to <h6>) using Loops. DO NOT write the header element
// explicitly in your script!
document.writeln("<h1>Heading</h1><hr>");
for (let i = 1; i <= 6; i++) {
  document.writeln("<h" + i + ">" + message + "</h" + i + ">");
}
