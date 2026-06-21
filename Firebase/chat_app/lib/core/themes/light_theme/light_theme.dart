import 'package:chat_app/core/themes/light_theme/app_colors_light.dart';
import 'package:chat_app/core/themes/light_theme/text_styles_light.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

ThemeData getLightTheme() => ThemeData(
  brightness: Brightness.light,
  scaffoldBackgroundColor: AppColorsLight.scaffoldBackgroundColor,
  cardColor: Colors.white,
  colorScheme: const ColorScheme.light(
    primary: AppColorsLight.primaryColor,
    secondary: AppColorsLight.primaryColor2,
    surface: AppColorsLight.scaffoldBackgroundColor,
    onPrimary: Colors.white,
    onSurface: AppColorsLight.secondaryColor,
  ),
  textTheme: TextTheme(
    // Display
    displayLarge: TextStylesLight.displayLarge,
    displayMedium: TextStylesLight.displayMedium,
    displaySmall: TextStylesLight.displaySmall,

    // Headlines
    headlineLarge: TextStylesLight.headlineLarge,
    headlineMedium: TextStylesLight.headlineMedium,
    headlineSmall: TextStylesLight.headlineSmall,

    // Titles
    titleLarge: TextStylesLight.titleLarge,
    titleMedium: TextStylesLight.titleMedium,
    titleSmall: TextStylesLight.titleSmall,

    // Body
    bodyLarge: TextStylesLight.bodyLarge,
    bodyMedium: TextStylesLight.bodyMedium,
    bodySmall: TextStylesLight.bodySmall,

    // Labels
    labelLarge: TextStylesLight.labelLarge,
    labelMedium: TextStylesLight.labelMedium,
    labelSmall: TextStylesLight.labelSmall,
  ),

  inputDecorationTheme: InputDecorationTheme(
    hintStyle: TextStylesLight.bodyMedium.copyWith(
      color: AppColorsLight.appBarCompsColor,
    ),
    border: OutlineInputBorder(
      borderSide: BorderSide(
        color: AppColorsLight.appBarCompsColor,
      ),
    ),
    enabledBorder: OutlineInputBorder(
      borderSide: BorderSide(
        color: AppColorsLight.appBarCompsColor,
      ),
    ),
    focusedBorder: const OutlineInputBorder(
      borderSide: BorderSide(
        color: AppColorsLight.primaryColor,
        width: 2,
      ),
    ),
  ),

  bottomNavigationBarTheme: BottomNavigationBarThemeData(
    backgroundColor: const Color(0xff5b9ee1),
    showUnselectedLabels: false,
    enableFeedback: false,
    selectedItemColor: Colors.white,
    selectedIconTheme: IconThemeData(
      color: Colors.white,
      size: 24.sp,
    ),
    selectedLabelStyle: TextStylesLight.labelSmall,
    unselectedLabelStyle: TextStylesLight.labelSmall,
    elevation: 0,
    unselectedItemColor: Colors.white54,
    type: BottomNavigationBarType.fixed,
  ),

  appBarTheme: AppBarTheme(
    backgroundColor: AppColorsLight.scaffoldBackgroundColor,
    titleTextStyle: TextStylesLight.titleLarge,
    iconTheme: const IconThemeData(
      color: AppColorsLight.secondaryColor,
    ),
    systemOverlayStyle: const SystemUiOverlayStyle(
      statusBarBrightness: Brightness.light,
      statusBarColor: AppColorsLight.scaffoldBackgroundColor,
    ),
  ),
  snackBarTheme: SnackBarThemeData(
    behavior: SnackBarBehavior.floating,
    shape: RoundedRectangleBorder(
      borderRadius: BorderRadius.circular(12),
    ),
    backgroundColor:
        AppColorsLight.primaryColor2, // optional, matches your theme file
  ),
);
