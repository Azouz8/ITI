import 'package:chat_app/core/themes/dark_theme/dark_theme.dart';
import 'package:chat_app/core/themes/light_theme/light_theme.dart';
import 'package:chat_app/features/authentication/data/repos/auth_repo_impl.dart';
import 'package:chat_app/features/authentication/presentation/manager/auth_cubit/auth_cubit.dart';
import 'package:chat_app/features/authentication/presentation/views/auth_gate.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:firebase_core/firebase_core.dart';
import 'firebase_options.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp(
    options: DefaultFirebaseOptions.currentPlatform,
  );
  runApp(const ChatApp());
}

class ChatApp extends StatelessWidget {
  const ChatApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider(create: (context) => AuthCubit(AuthRepoImpl())),
      ],
      child: ScreenUtilInit(
        designSize: const Size(380, 700),
        minTextAdapt: true,
        splitScreenMode: true,
        builder: (context, child) {
          return MaterialApp(
            debugShowCheckedModeBanner: false,
            home: const AuthGate(),
            theme: getLightTheme(),
            darkTheme: getDarkTheme(),
            themeMode: ThemeMode.system,
          );
        },
      ),
    );
  }
}
