var Book = function (
  title = "",
  numOfChapters = 0,
  author = "",
  numOfPages = 0,
  publisher = "",
  numOfCopies = 1,
) {
  var title = title;
  var numOfChapters = numOfChapters;
  var author = author;
  var numOfpages = numOfPages;
  var publisher = publisher;
  var numOfCopies = numOfCopies;

  this.getTitle = function () {
    return title;
  };
  this.getNumOfChapters = function () {
    return numOfChapters;
  };
  this.getAuthor = function () {
    return author;
  };
  this.getNumOfPages = function () {
    return numOfpages;
  };
  this.getPublisher = function () {
    return publisher;
  };
  this.getNumOfCopies = function () {
    return numOfCopies;
  };

  this.setTitle = function (t) {
    title = t;
  };
  this.setNumOfChapters = function (noc) {
    numOfChapters = noc;
  };
  this.setAuthor = function (a) {
    author = a;
  };
  this.setNumOfPages = function (nop) {
    numOfpages = nop;
  };
  this.setPublisher = function (p) {
    publisher = p;
  };
  this.setNumOfCopies = function (noco) {
    numOfCopies = noco;
  };
};

var Box = function (
  height = 0,
  width = 0,
  length = 0,
  material = "",
  content = [],
) {
  var height = height;
  var width = width;
  var length = length;
  var material = material;
  var content = content;
  var numOfBooks;
  var volume;

  this.getHeight = function () {
    return height;
  };
  this.getWidth = function () {
    return width;
  };
  this.getLength = function () {
    return length;
  };
  this.getNumOfBooks = function () {
    numOfBooks = 0;
    for (var b of content) {
      numOfBooks += b.getNumOfCopies();
    }
    return numOfBooks;
  };
  this.getVolume = function () {
    volume = height * width * length;
    return volume;
  };
  this.getMaterial = function () {
    return material;
  };
  this.getContent = function () {
    var result = [];
    for (var b of content)
      result.push(b.getTitle() + " : " + b.getNumOfCopies());
    return result;
  };

  this.setHeight = function (h) {
    height = h;
  };
  this.setWidth = function (w) {
    width = w;
  };
  this.setLength = function (l) {
    length = l;
  };
  this.setNumOfBooks = function (n) {
    numOfBooks = n;
  };
  this.setMaterial = function (m) {
    material = m;
  };

  this.addBook = function (book) {
    for (var b of content) {
      if (b.getTitle() == book.getTitle()) {
        b.setNumOfCopies(b.getNumOfCopies() + 1);
        return "Book Added Successfully";
      }
    }
    content.push(book);
    return "Book Added Successfully";
  };

  this.removeBook = function (book) {
    try {
      for (var b of content) {
        if (b.getTitle() == book.getTitle()) {
          if (b.getNumOfCopies() === 1) {
            content.splice(content.indexOf(b), 1);
            return "Book Removed Successfully";
          } else {
            b.setNumOfCopies(b.getNumOfCopies() - 1);
            return "Book Removed Successfully";
          }
        }
      }
      throw "Book not found";
    } catch (error) {
      console.log(error);
    }
  };
};

var b1 = new Book("B1", 10, "Ali", 100);
var b2 = new Book("B2", 22, "Azouz", 100);
var b3 = new Book("B3", 21, "Ahmed", 100);
var b4 = new Book("B1", 10, "Ali", 100);

var box = new Box(5, 5, 5, "Wood");

console.log(box.getContent());
box.addBook(b1);
box.addBook(b2);
box.addBook(b3);
box.addBook(b4);
console.log(box.getContent());
console.log("Remove a copy from Book 1");
box.removeBook(b4);
console.log(box.getContent());
