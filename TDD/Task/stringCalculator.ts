export class StringCalculator {
  Add(numbers: string): number {
    if (numbers === "") return 0;

    const delimiter = /,|\n/;
    const nums = numbers.split(delimiter).map(Number);

    const negatives = nums.filter(n => n < 0);
    if (negatives.length > 0) {
      throw new Error(`negatives not allowed: ${negatives.join(", ")}`);
    }

    return nums.reduce((sum, n) => sum + n, 0);
  }
}