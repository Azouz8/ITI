// 8- Create a union type MaybeString = string | null | undefined.
//    create a new type without null or undefined.
//    Test by assigning a value of the new type.

type MaybeString = string | null | undefined;

type StringOnly = NonNullable<MaybeString>;

let str: StringOnly = "asd";
