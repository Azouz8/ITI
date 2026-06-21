import 'package:chat_app/features/authentication/data/repos/auth_repo.dart';
import 'package:dart_either/src/dart_either.dart';
import 'package:firebase_auth/firebase_auth.dart';

class AuthRepoImpl extends AuthRepo {
  final FirebaseAuth firebaseAuth;
  AuthRepoImpl({FirebaseAuth? firebaseAuth})
    : firebaseAuth = firebaseAuth ?? FirebaseAuth.instance;

  @override
  Future<Either<String, User>> login({
    required String email,
    required String password,
  }) async {
    try {
      final credentials = await firebaseAuth.signInWithEmailAndPassword(
        email: email,
        password: password,
      );
      return Right(credentials.user!);
    } on FirebaseAuthException catch (e) {
      return Left(_mapAuthError(e));
    }
  }

  @override
  Future<Either<String, User>> register({
    required String email,
    required String password,
  }) async {
    try {
      final credentials = await firebaseAuth.createUserWithEmailAndPassword(
        email: email,
        password: password,
      );
      return Right(credentials.user!);
    } on FirebaseAuthException catch (e) {
      return Left(_mapAuthError(e));
    }
  }

  String _mapAuthError(FirebaseAuthException ex) {
    switch (ex.code) {
      case 'user-not-found':
        return 'No user found for that email.';
      case 'wrong-password':
        return 'Incorrect password.';
      default:
        return ex.message ?? 'Something went wrong.';
    }
  }

  @override
  Future<void> logout() async {
    await firebaseAuth.signOut();
  }
}
