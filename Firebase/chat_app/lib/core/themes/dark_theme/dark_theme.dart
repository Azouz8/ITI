import 'package:chat_app/core/themes/dark_theme/app_colors_dark.dart';
import 'package:chat_app/core/themes/dark_theme/text_styles_dark.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

ThemeData getDarkTheme() => ThemeData(
  brightness: Brightness.dark,
  scaffoldBackgroundColor: AppColorsDark.scaffoldBackgroundColor,
  cardColor: AppColorsDark.cardColor,
  textTheme: TextTheme(
    // Display
    displayLarge: TextStylesDark.displayLarge,
    displayMedium: TextStylesDark.displayMedium,
    displaySmall: TextStylesDark.displaySmall,
    // Headlines
    headlineLarge: TextStylesDark.headlineLarge,
    headlineMedium: TextStylesDark.headlineMedium,
    headlineSmall: TextStylesDark.headlineSmall,
    // Titles
    titleLarge: TextStylesDark.titleLarge,
    titleMedium: TextStylesDark.titleMedium,
    titleSmall: TextStylesDark.titleSmall,
    // Body
    bodyLarge: TextStylesDark.bodyLarge,
    bodyMedium: TextStylesDark.bodyMedium,
    bodySmall: TextStylesDark.bodySmall,
    // Labels
    labelLarge: TextStylesDark.labelLarge,
    labelMedium: TextStylesDark.labelMedium,
    labelSmall: TextStylesDark.labelSmall,
  ),
  inputDecorationTheme: InputDecorationTheme(
    hintStyle: TextStylesDark.bodyMedium,
    border: OutlineInputBorder(
      borderSide: BorderSide(
        color: AppColorsDark.appBarCompsColor,
      ),
    ),
    enabledBorder: OutlineInputBorder(
      borderSide: BorderSide(
        color: AppColorsDark.appBarCompsColor,
      ),
    ),
    focusedBorder: const OutlineInputBorder(
      borderSide: BorderSide(
        color: AppColorsDark.primaryColor,
        width: 2,
      ),
    ),
  ),
  bottomNavigationBarTheme: BottomNavigationBarThemeData(
    backgroundColor: AppColorsDark.surfaceColor,
    showUnselectedLabels: false,
    enableFeedback: false,
    selectedItemColor: AppColorsDark.primaryColor,
    selectedIconTheme: IconThemeData(
      color: AppColorsDark.primaryColor,
      size: 24.sp,
    ),
    selectedLabelStyle: TextStylesDark.labelSmall,
    unselectedLabelStyle: TextStylesDark.labelSmall,
    elevation: 0,
    unselectedItemColor: AppColorsDark.bodyTextColor,
    type: BottomNavigationBarType.fixed,
  ),
  appBarTheme: AppBarTheme(
    backgroundColor: AppColorsDark.scaffoldBackgroundColor,
    titleTextStyle: TextStylesDark.titleLarge,
    iconTheme: const IconThemeData(
      color: AppColorsDark.secondaryColor,
    ),
    systemOverlayStyle: const SystemUiOverlayStyle(
      statusBarBrightness: Brightness.dark,
      statusBarColor: AppColorsDark.scaffoldBackgroundColor,
    ),
  ),
  snackBarTheme: SnackBarThemeData(
    behavior: SnackBarBehavior.floating,
    shape: RoundedRectangleBorder(
      borderRadius: BorderRadius.circular(12),
    ),
    backgroundColor: AppColorsDark.cardColor,
    contentTextStyle: TextStylesDark.bodyMedium.copyWith(
      color: AppColorsDark.secondaryColor,
    ),
  ),
  dropdownMenuTheme: DropdownMenuThemeData(
    menuStyle: MenuStyle(
      backgroundColor: WidgetStateProperty.all<Color>(
        AppColorsDark.surfaceColor,
      ),
    ),
  ),
  colorScheme: const ColorScheme.dark(
    primary: AppColorsDark.primaryColor,
    secondary: AppColorsDark.primaryColor2,
    surface: AppColorsDark.surfaceColor,
    error: AppColorsDark.errorColor,
  ),
);
