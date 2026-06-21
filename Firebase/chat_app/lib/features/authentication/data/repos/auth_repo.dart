import 'package:dart_either/dart_either.dart';
import 'package:firebase_auth/firebase_auth.dart';

abstract class AuthRepo {
  Future<Either<String, User>> login({
    required String email,
    required String password,
  });
  Future<Either<String, User>> register({
    required String email,
    required String password,
  });
  Future<void> logout();
}
