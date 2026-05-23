import { MathUtils } from "../index.js";

describe("Test MathUtils With Jasmine", () => {
    let math;
    beforeEach(() => {
        math = new MathUtils();
    });

    it("add two numbers", () => {
        expect(math.sum(5, 5)).toEqual(10);
        expect(math.sum(-3, 3)).toEqual(0);
        expect(math.sum(1, 2)).toEqual(jasmine.any(Number));
    });

    it("subtract two numbers", () => {
        expect(math.substract(10, 4)).toEqual(6);
        expect(math.substract(0, 5)).toEqual(-5);
    });

    it("multiply two numbers", () => {
        expect(math.multiply(3, 4)).toEqual(12);
        expect(math.multiply(5, 0)).toEqual(0);
    });

    it("divide two numbers", () => {
        expect(math.divide(10, 2)).toEqual(5);
        expect(math.divide(5, 2)).toEqual(2.5);
    });

    it("the average of two numbers", () => {
        expect(math.average(10, 20)).toEqual(15);
        expect(math.average(0, 5)).toEqual(2.5);
    });

    describe("factorial", () => {
        it("should return 1 for 0 and 1", () => {
            expect(math.factorial(0)).toEqual(1);
            expect(math.factorial(1)).toEqual(1);
        });

        it("calculate factorial for positive numbers", () => {
            expect(math.factorial(4)).toEqual(24);
            expect(math.factorial(5)).toEqual(120);
        });

        it("should throw an error when given a negative number", () => {
            expect(() => {
                math.factorial(-5);
            }).toThrowError("There is no factorial for negative numbers");
        });
    });

    describe("checkPositivity", () => {
        it("should return true for positive numbers and zero", () => {
            expect(math.checkPositivity(5)).toBe(true);
            expect(math.checkPositivity(0)).toBe(true);
        });

        it("should return false for negative numbers", () => {
            expect(math.checkPositivity(-1)).toBe(false);
            expect(math.checkPositivity(-100)).toBe(false);
        });
    });
});