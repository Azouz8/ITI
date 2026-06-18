import 'package:flutter/material.dart';

class SignupScreen extends StatefulWidget {
  const SignupScreen({super.key});

  @override
  State<SignupScreen> createState() => _SignupScreenState();
}

class _SignupScreenState extends State<SignupScreen> {
  final emailController = TextEditingController();

  final nameController = TextEditingController();

  final passwordController = TextEditingController();

  final confirmPasswordController = TextEditingController();

  final birthDateController = TextEditingController();

  final formKey = GlobalKey<FormState>();

  String name = "";

  String email = "";

  String password = "";

  String confirmPassword = "";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: ConstrainedBox(
          constraints: BoxConstraints(
            minHeight: MediaQuery.sizeOf(context).height,
          ),
          child: Padding(
            padding: const EdgeInsets.all(24.0),
            child: Form(
              key: formKey,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text(
                    "Sign Up",
                    style: TextStyle(
                      fontSize: 28,
                      fontWeight: FontWeight.bold,
                      color: Colors.blueAccent,
                    ),
                  ),
                  const SizedBox(
                    height: 8,
                  ),
                  const Text(
                    "Let's Create Account Together",
                    style: TextStyle(fontSize: 18, color: Colors.grey),
                  ),
                  const SizedBox(
                    height: 16,
                  ),
                  Column(
                    spacing: 12,
                    children: [
                      TextFormField(
                        controller: nameController,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return "Name is required";
                          }
                          return null;
                        },
                        onTapOutside: (event) =>
                            FocusManager.instance.primaryFocus!.unfocus(),
                        style: const TextStyle(
                          color: Colors.black,
                          fontSize: 16,
                        ),
                        cursorColor: Colors.black45,
                        decoration: InputDecoration(
                          border: customOutlineInputBorder(),
                          enabledBorder: customOutlineInputBorderFocused(),
                          focusedBorder: customOutlineInputBorder(),
                          labelText: "Name",
                          labelStyle: const TextStyle(
                            color: Colors.grey,
                          ),
                          floatingLabelStyle: const TextStyle(
                            color: Colors.black54,
                          ),
                        ),
                      ),
                      TextFormField(
                        controller: emailController,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return "Email is required";
                          }
                          return null;
                        },
                        onTapOutside: (event) =>
                            FocusManager.instance.primaryFocus!.unfocus(),
                        style: const TextStyle(
                          color: Colors.black,
                          fontSize: 16,
                        ),
                        keyboardType: TextInputType.emailAddress,
                        cursorColor: Colors.black45,
                        decoration: InputDecoration(
                          border: customOutlineInputBorder(),
                          enabledBorder: customOutlineInputBorderFocused(),
                          focusedBorder: customOutlineInputBorder(),
                          labelText: "Email Address",
                          labelStyle: const TextStyle(
                            color: Colors.grey,
                          ),
                          floatingLabelStyle: const TextStyle(
                            color: Colors.black54,
                          ),
                        ),
                      ),
                      TextFormField(
                        controller: passwordController,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return "Password is required";
                          }
                          return null;
                        },
                        onTapOutside: (event) =>
                            FocusManager.instance.primaryFocus!.unfocus(),
                        style: const TextStyle(
                          color: Colors.black,
                          fontSize: 16,
                        ),
                        obscureText: true,
                        cursorColor: Colors.black45,
                        decoration: InputDecoration(
                          border: customOutlineInputBorder(),
                          enabledBorder: customOutlineInputBorderFocused(),
                          focusedBorder: customOutlineInputBorder(),
                          labelText: "Password",
                          labelStyle: const TextStyle(
                            color: Colors.grey,
                          ),
                          floatingLabelStyle: const TextStyle(
                            color: Colors.black54,
                          ),
                        ),
                      ),
                      TextFormField(
                        controller: confirmPasswordController,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return "Confirmed Password is required";
                          } else if (value != passwordController.text) {
                            return "Passwords Don't match";
                          }
                          return null;
                        },
                        onTapOutside: (event) =>
                            FocusManager.instance.primaryFocus!.unfocus(),
                        style: const TextStyle(
                          color: Colors.black,
                          fontSize: 16,
                        ),
                        obscureText: true,
                        cursorColor: Colors.black45,
                        decoration: InputDecoration(
                          border: customOutlineInputBorder(),
                          enabledBorder: customOutlineInputBorderFocused(),
                          focusedBorder: customOutlineInputBorder(),
                          labelText: "Confirm Password",
                          labelStyle: const TextStyle(
                            color: Colors.grey,
                          ),
                          floatingLabelStyle: const TextStyle(
                            color: Colors.black54,
                          ),
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(
                    height: 16,
                  ),
                  ElevatedButton(
                    onPressed: () {
                      if (formKey.currentState!.validate()) {
                        setState(() {
                          name = nameController.text;
                          email = emailController.text;
                          password = passwordController.text;
                          confirmPassword = confirmPasswordController.text;
                        });
                      }
                    },
                    style: ElevatedButton.styleFrom(
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadiusGeometry.circular(16),
                      ),
                      backgroundColor: Colors.blueAccent,
                      minimumSize: const Size(double.infinity, 48),
                    ),
                    child: const Text(
                      "Register",
                      style: TextStyle(color: Colors.white, fontSize: 18),
                    ),
                  ),
                  const SizedBox(
                    height: 8,
                  ),
                  ElevatedButton(
                    onPressed: () {
                      formKey.currentState!.reset();
                      nameController.clear();
                      emailController.clear();
                      passwordController.clear();
                      confirmPasswordController.clear();
                    },
                    style: ElevatedButton.styleFrom(
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadiusGeometry.circular(16),
                      ),
                      backgroundColor: Colors.blueAccent,
                      minimumSize: const Size(double.infinity, 48),
                    ),
                    child: const Text(
                      "Clear Form",
                      style: TextStyle(color: Colors.white, fontSize: 18),
                    ),
                  ),
                  const SizedBox(
                    height: 16,
                  ),

                  UserInfoWidget(
                    name: nameController.text,
                    email: emailController.text,
                    password: passwordController.text,
                    confirmPassword: confirmPasswordController.text,
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }

  OutlineInputBorder customOutlineInputBorder() {
    return const OutlineInputBorder(
      borderSide: BorderSide(color: Colors.blueAccent, width: 1.2),
      borderRadius: BorderRadius.all(
        Radius.circular(16),
      ),
    );
  }

  OutlineInputBorder customOutlineInputBorderFocused() {
    return const OutlineInputBorder(
      borderSide: BorderSide(color: Colors.black45, width: 1.2),
      borderRadius: BorderRadius.all(
        Radius.circular(16),
      ),
    );
  }
}

class UserInfoWidget extends StatelessWidget {
  const UserInfoWidget({
    super.key,
    required this.name,
    required this.email,
    required this.password,
    required this.confirmPassword,
  });

  final String name, email, password, confirmPassword;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      child: Card(
        elevation: 4,
        child: Padding(
          padding: const EdgeInsets.all(16),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "Name: $name",
                style: const TextStyle(
                  fontSize: 16,
                  fontWeight: FontWeight.w500,
                ),
              ),
              Text(
                "Email: $email",
                style: const TextStyle(
                  fontSize: 16,
                  fontWeight: FontWeight.w500,
                ),
              ),
              Text(
                "Password: $password",
                style: const TextStyle(
                  fontSize: 16,
                  fontWeight: FontWeight.w500,
                ),
              ),
              Text(
                "Confirmed Password: $confirmPassword",
                style: const TextStyle(
                  fontSize: 16,
                  fontWeight: FontWeight.w500,
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
