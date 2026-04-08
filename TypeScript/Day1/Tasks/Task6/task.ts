// 6- Create a union type Colors = "red" | "green" | "blue" | "yellow".
//    create a new type without "yellow".
//    Test by assigning a value of the new type.

type Colors = "red" | "green" | "blue" | "yellow";

type ColorsWithoutYellow = Exclude<Colors, "yellow">;

let color: ColorsWithoutYellow = "green";
