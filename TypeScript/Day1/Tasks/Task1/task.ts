// 1- Create an interface User with properties name (string)
//    and age (number). and it is required not optional
//    required create an object with only the name property.

interface IUser {
  name: string;
  age: number;
}

let user: Partial<IUser> = {
  name: "Azouz",
};
