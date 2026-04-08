// 5- Use the same Person interface from the previous question.
//    create a new type without the age property.
//    Test by creating an object with only name and email.

interface IPerson {
  name: string;
  age: number;
  email: string;
}

type NameEmailOnly = Omit<IPerson, "age">;

let person: NameEmailOnly = {
  email: "Ali@gmail.com",
  name: "Azouz",
};
