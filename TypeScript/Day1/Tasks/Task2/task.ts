// 2- Create an interface Profile with optional properties
//    username (string) and email (string).
//    required create an object with both properties.

interface IProfile {
  username?: string;
  email?: string;
}

let profile: IProfile = {
  email: "Ali@gmail.com",
  username: "Azouz",
};
