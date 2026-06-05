import { describe, it, expect } from "@jest/globals";
import { StringCalculator } from "./stringCalculator";

const calc = new StringCalculator();

describe("Add with empty or single values", () => {
  it("returns 0 for empty string", () => {
    expect(calc.Add("")).toBe(0);
  });

  it("returns the number itself for a single number", () => {
    expect(calc.Add("1")).toBe(1);
  });

  it("returns sum for two numbers", () => {
    expect(calc.Add("1,2")).toBe(3);
  });
});

describe("Add handles unknown amount of numbers", () => {
  it("returns sum of 10 numbers", () => {
    expect(calc.Add("1,2,3,4,5,6,7,8,9,10")).toBe(55);
  });
});

describe("Add handles newlines between numbers", () => {
  it("handles newline as delimiter", () => {
    expect(calc.Add("1\n2,3")).toBe(6);
  });

  it("handles multiple newlines", () => {
    expect(calc.Add("1\n2\n3")).toBe(6);
  });
});

describe("Add throws on negative numbers", () => {
  it("throws with single negative", () => {
    expect(() => calc.Add("1,-2,3")).toThrow("negatives not allowed: -2");
  });

  it("throws with multiple negatives showing all of them", () => {
    expect(() => calc.Add("1,-2,-5,3")).toThrow(
      "negatives not allowed: -2, -5"
    );
  });
});