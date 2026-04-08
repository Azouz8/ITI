// 7- Use the same Colors union type from the previous question.
//    create a new type with only "red" and "blue".
//    Test by assigning a value of the new type.

type Colors = "red" | "green" | "blue" | "yellow";

type RedAndBlueColorsOnly = Extract<Colors, "red" | "blue">;

let color: RedAndBlueColorsOnly = "blue";
