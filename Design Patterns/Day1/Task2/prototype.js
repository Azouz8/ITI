class Document {
    constructor(header, footer, pages, text) {
        this.header = header;
        this.footer = footer;
        this.pages = pages;
        this.text = text;
    }
    clone() {
        return new Document(
            this.header,
            this.footer,
            this.pages,
            this.text
        );
    }
    display() {
        console.log("Header:", this.header);
        console.log("Footer:", this.footer);
        console.log("Pages:", this.pages);
        console.log("Text:", this.text);
        console.log("-------------------");
    }
}

const originalDoc = new Document(
    "DOC 1 Header",
    "DOC 1 Footer",
    10,
    "DOC 1 content"
);

originalDoc.display();

const copiedDoc = originalDoc.clone();
copiedDoc.text = "Modified copied document";
copiedDoc.display();