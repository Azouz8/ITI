class Book {
    constructor(title, pages) {
        this.title = title;
        this.pages = pages;
    }
    getPages() { return this.pages; }
    show(indent = "") {
        return `${indent}Book: "${this.title}" (${this.pages} pages)`;
    }
}

class Box {
    constructor(label) {
        this.label = label;
        this.children = [];
    }
    add(item) { this.children.push(item); return this; }
    getPages() {
        return this.children.reduce((sum, c) => sum + c.getPages(), 0);
    }
    show(indent = "") {
        const lines = [`${indent}Box: [${this.label}] → ${this.getPages()} pages total`];
        this.children.forEach(c => lines.push(c.show(indent + "  ")));
        return lines.join("\n");
    }
}

const classics = new Box("Classics")
    .add(new Book("Hamlet", 342))
    .add(new Book("Don Quixote", 863));

const scifi = new Box("Sci-Fi")
    .add(new Book("Dune", 688))
    .add(new Book("Foundation", 244));

const warehouse = new Box("Warehouse")
    .add(classics)
    .add(scifi)
    .add(new Book("Clean Code", 431));

console.log(warehouse.show());