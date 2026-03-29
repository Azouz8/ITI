const fs = require("fs");

const readProducts = () =>
  fs.readFileSync("NodeJS/Day1/Tasks/product.json", "utf-8");

function writeIntoProducts(products) {
  fs.writeFileSync("NodeJS/Day1/Tasks/product.json", products, "utf-8");
}

function listProducts() {
  var products = readProducts();
  console.log(products);
}

function addProduct(args) {
  var products = JSON.parse(readProducts());
  var newProd = { id: Date.now(), name: args[1], price: args[2] };
  products.push(newProd);
  writeIntoProducts(JSON.stringify(products));
}

function updateProduct(args) {
  var products = JSON.parse(readProducts());
  var product = products.findIndex((p) => p.id == args[1]);
  if (product != -1) {
    switch (args[2]) {
      case "--price":
        products[product].price = args[3];
        break;
      case "--name":
        products[product].name = args[3];
        break;
      default:
        break;
    }
    switch (args[4]) {
      case "--price":
        products[product].price = args[5];
        break;
      case "--name":
        products[product].name = args[5];
        break;
      default:
        break;
    }
    writeIntoProducts(JSON.stringify(products));
  }
}

function deleteProduct(args) {
  var products = JSON.parse(readProducts());
  var product = products.findIndex((p) => p.id == args[1]);
  if (product != -1) {
    products.splice(product, 1);
    writeIntoProducts(JSON.stringify(products));
  }
}

const [, , ...args] = process.argv;

switch (args[0]) {
  case "read":
    listProducts();
    break;
  case "add":
    addProduct(args);
    break;
  case "update":
    updateProduct(args);
    break;
  case "delete":
    deleteProduct(args);
    break;

  default:
    break;
}
