// 4- Create an interface Person with properties name (string), age (number), and email (string).
//    create a new type with only the name and email properties.
//    Test by creating an object with these properties.

interface IPerson {
  name: string;
  age: number;
  email: string;
}

type NameEmailOnly = Pick<IPerson, "name" | "email">;

let person: NameEmailOnly = {
  email: "Ali@gmail.com",
  name: "Azouz",
};
