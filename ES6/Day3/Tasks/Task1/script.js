class Polygon {
    dim1
    dim2
    constructor(dim1, dim2) {
        if (this.constructor == Polygon)
            throw new ReferenceError('wrong instance')
        this.dim1 = dim1
        this.dim2 = dim2
    }
}


class Rectangle extends Polygon {
    constructor(dim1, dim2) {
        super(dim1, dim2)
    }
    area() {
        return this.dim1 * this.dim2
    }
    perimeter() {
        return 2 * (this.dim1 + this.dim2)
    }
    toString() {
        return `rectangle  Area ${this.area()}  and parameter ${this.perimeter()}  `
    }
}


class Square extends Rectangle {
    constructor(l) {
        super(l, l)
    }
    toString() {
        return `Square  Area ${this.area()}  and parameter ${this.perimeter()}  `
    }
}

class Circle extends Polygon {
    constructor(radius) {
        super(radius, radius)

    }
    area() {
        return Math.PI * this.dim1 ** 2
    }
    perimeter() {
        return 2 * Math.PI * this.dim1
    }
    toString() {
        return `Circle  Area ${this.area()}  and parameter ${this.perimeter()}  `
    }
}


class Triangle extends Polygon {
    constructor(a, b, c) {
        super(a, b);
        this.c = c;
    }

    perimeter() {
        return this.dim1 + this.dim2 + this.c;
    }

    area() {
        return 0.5 * this.dim1 * this.dim2;
    }

    toString() {
        return `Triangle  Area: ${this.area()} , Perimeter: ${this.perimeter()}`
    }
}


const rec = new Rectangle(4, 2)
const sq = new Square(3)
const t = new Triangle(1, 2, 3);
const c = new Circle(2);
console.log(rec.toString())
console.log(sq.toString());
console.log(t.toString());
console.log(c.toString());