abstract class AuthStates {}

class AuthInitial extends AuthStates {}

class LoginLoadingState extends AuthStates {}

class LoginSuccessState extends AuthStates {}

class LoginFailState extends AuthStates {
  final String error;

  LoginFailState({required this.error});
}

class RegisterLoadingState extends AuthStates {}

class RegisterSuccessState extends AuthStates {}

class RegisterFailState extends AuthStates {
  final String error;

  RegisterFailState({required this.error});
}

class LogoutLoadingState extends AuthStates {}

class LogoutSuccessState extends AuthStates {}
