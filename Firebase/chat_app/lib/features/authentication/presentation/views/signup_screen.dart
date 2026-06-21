import 'package:chat_app/features/authentication/presentation/manager/auth_cubit/auth_cubit.dart';
import 'package:chat_app/features/authentication/presentation/manager/auth_cubit/auth_states.dart';
import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class SignupScreen extends StatelessWidget {
  SignupScreen({super.key});

  final emailController = TextEditingController();
  final passwordController = TextEditingController();
  final confirmPasswordController = TextEditingController();
  final formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    var cubit = AuthCubit.get(context);
    final colorScheme = Theme.of(context).colorScheme;
    final textTheme = Theme.of(context).textTheme;

    return BlocConsumer<AuthCubit, AuthStates>(
      listener: (context, state) {
        if (state is RegisterSuccessState) {
          ScaffoldMessenger.of(context).clearSnackBars();
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(
              content: Text(
                "Account Created Successfully!",
                textAlign: TextAlign.center,
              ),
            ),
          );
          Navigator.pop(context);
        } else if (state is RegisterFailState) {
          ScaffoldMessenger.of(context).clearSnackBars();
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text(state.error, textAlign: TextAlign.center),
            ),
          );
        }
      },
      builder: (context, state) {
        final isLoading = state is RegisterLoadingState;
        return GestureDetector(
          onTap: () => FocusManager.instance.primaryFocus?.unfocus(),
          behavior: HitTestBehavior.opaque,
          child: Scaffold(
            body: SingleChildScrollView(
              physics: const BouncingScrollPhysics(),
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
                        Text(
                          "SIGN UP",
                          style: textTheme.displayMedium!.copyWith(
                            color: colorScheme.primary,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        const SizedBox(height: 8),
                        Text(
                          "Hurry up and register for free!",
                          style: textTheme.bodyMedium!.copyWith(
                            fontSize: 18,
                            color: colorScheme.onSurface.withAlpha(150),
                          ),
                        ),
                        const SizedBox(height: 16),
                        Column(
                          spacing: 12,
                          children: [
                            TextFormField(
                              controller: emailController,
                              validator: (value) {
                                if (value == null ||
                                    value.isEmpty ||
                                    value.trim().length <= 1) {
                                  return "Email is required";
                                } else if (!EmailValidator.validate(
                                  emailController.text,
                                )) {
                                  return "Please Enter a Valid Email Address";
                                }
                                return null;
                              },
                              style: textTheme.bodyLarge!.copyWith(fontSize: 16),
                              keyboardType: TextInputType.emailAddress,
                              cursorColor: colorScheme.primary,
                              textCapitalization: TextCapitalization.none,
                              decoration: InputDecoration(
                                border: customOutlineInputBorder(context),
                                enabledBorder: customOutlineInputBorderUnfocused(
                                  context,
                                ),
                                focusedBorder: customOutlineInputBorder(context),
                                labelText: "Email Address",
                                labelStyle: textTheme.bodyMedium!.copyWith(
                                  color: colorScheme.onSurface.withAlpha(150),
                                ),
                                floatingLabelStyle: textTheme.bodyMedium!
                                    .copyWith(color: colorScheme.primary),
                              ),
                            ),
                            TextFormField(
                              controller: passwordController,
                              validator: (value) {
                                if (value == null ||
                                    value.isEmpty ||
                                    value.trim().length <= 1) {
                                  return "Password is required";
                                }
                                return null;
                              },
                              style: textTheme.bodyLarge!.copyWith(fontSize: 16),
                              obscureText: true,
                              cursorColor: colorScheme.primary,
                              decoration: InputDecoration(
                                border: customOutlineInputBorder(context),
                                enabledBorder: customOutlineInputBorderUnfocused(
                                  context,
                                ),
                                focusedBorder: customOutlineInputBorder(context),
                                labelText: "Password",
                                labelStyle: textTheme.bodyMedium!.copyWith(
                                  color: colorScheme.onSurface.withAlpha(150),
                                ),
                                floatingLabelStyle: textTheme.bodyMedium!
                                    .copyWith(color: colorScheme.primary),
                              ),
                            ),
                            TextFormField(
                              controller: confirmPasswordController,
                              validator: (value) {
                                if (value == null ||
                                    value.isEmpty ||
                                    value.trim().length <= 1) {
                                  return "Confirmed Password is required";
                                } else if (value != passwordController.text) {
                                  return "Passwords Don't match";
                                }
                                return null;
                              },
                              style: textTheme.bodyLarge!.copyWith(fontSize: 16),
                              obscureText: true,
                              cursorColor: colorScheme.primary,
                              decoration: InputDecoration(
                                border: customOutlineInputBorder(context),
                                enabledBorder: customOutlineInputBorderUnfocused(
                                  context,
                                ),
                                focusedBorder: customOutlineInputBorder(context),
                                labelText: "Confirm Password",
                                labelStyle: textTheme.bodyMedium!.copyWith(
                                  color: colorScheme.onSurface.withAlpha(150),
                                ),
                                floatingLabelStyle: textTheme.bodyMedium!
                                    .copyWith(color: colorScheme.primary),
                              ),
                            ),
                          ],
                        ),
                        const SizedBox(height: 16),
                        ElevatedButton(
                          onPressed: isLoading
                              ? null
                              : () {
                                  if (formKey.currentState!.validate()) {
                                    cubit.registerUser(
                                      email: emailController.text,
                                      password: passwordController.text,
                                    );
                                  }
                                },
                          style: ElevatedButton.styleFrom(
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(16),
                            ),
                            backgroundColor: colorScheme.primary,
                            minimumSize: const Size(double.infinity, 48),
                          ),
                          child: isLoading
                              ? SizedBox(
                                  height: 15,
                                  width: 15,
                                  child: CircularProgressIndicator(
                                    color: colorScheme.onPrimary,
                                    strokeWidth: 2,
                                  ),
                                )
                              : Text(
                                  "Register",
                                  style: textTheme.labelLarge!.copyWith(
                                    color: colorScheme.onPrimary,
                                  ),
                                ),
                        ),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Text(
                              'Already have an Account?',
                              style: textTheme.titleSmall!.copyWith(
                                fontWeight: FontWeight.w400,
                                color: colorScheme.onSurface.withAlpha(150),
                              ),
                            ),
                            InkWell(
                              onTap: () {
                                Navigator.pop(context);
                              },
                              borderRadius: BorderRadius.circular(15),
                              child: Padding(
                                padding: const EdgeInsets.only(
                                  top: 8,
                                  bottom: 8,
                                  right: 8,
                                ),
                                child: Text(
                                  ' Login!',
                                  style: textTheme.titleSmall!.copyWith(
                                    fontWeight: FontWeight.bold,
                                  ),
                                ),
                              ),
                            ),
                          ],
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            ),
          ),
        );
      },
    );
  }

  OutlineInputBorder customOutlineInputBorder(BuildContext context) {
    return OutlineInputBorder(
      borderSide: BorderSide(
        color: Theme.of(context).colorScheme.primary,
        width: 1.2,
      ),
      borderRadius: const BorderRadius.all(Radius.circular(16)),
    );
  }

  OutlineInputBorder customOutlineInputBorderUnfocused(BuildContext context) {
    return OutlineInputBorder(
      borderSide: BorderSide(
        color: Theme.of(context).colorScheme.onSurface.withAlpha(80),
        width: 1.2,
      ),
      borderRadius: const BorderRadius.all(Radius.circular(16)),
    );
  }
}