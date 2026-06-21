import 'package:chat_app/features/authentication/data/repos/auth_repo.dart';
import 'package:chat_app/features/authentication/presentation/manager/auth_cubit/auth_states.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class AuthCubit extends Cubit<AuthStates> {
  AuthCubit(this.authRepo) : super(AuthInitial());

  static AuthCubit get(BuildContext context) =>
      BlocProvider.of<AuthCubit>(context);

  final AuthRepo authRepo;

  Future<void> loginUser({
    required String email,
    required String password,
  }) async {
    emit(LoginLoadingState());
    final result = await authRepo.login(email: email, password: password);
    result.fold(
      ifLeft: (error) => emit(LoginFailState(error: error)),
      ifRight: (user) => emit(LoginSuccessState()),
    );
  }

  Future<void> registerUser({
    required String email,
    required String password,
  }) async {
    emit(RegisterLoadingState());
    final result = await authRepo.register(email: email, password: password);
    result.fold(
      ifLeft: (error) => emit(RegisterFailState(error: error)),
      ifRight: (user) => emit(RegisterSuccessState()),
    );
  }

  Future<void> logoutUser() async {
    emit(LogoutLoadingState());
    await authRepo.logout();
    emit(LogoutSuccessState());
  }
}
