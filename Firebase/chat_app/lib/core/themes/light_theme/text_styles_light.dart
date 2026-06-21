import 'package:chat_app/core/themes/light_theme/app_colors_light.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

class TextStylesLight {
  static const _color = AppColorsLight.secondaryColor;

  // Display
  static final displayLarge = GoogleFonts.manrope(
    fontSize: 57.sp,
    fontWeight: FontWeight.w700,
    color: _color,
  );

  static final displayMedium = GoogleFonts.manrope(
    fontSize: 45.sp,
    fontWeight: FontWeight.w700,
    color: _color,
  );

  static final displaySmall = GoogleFonts.manrope(
    fontSize: 36.sp,
    fontWeight: FontWeight.w700,
    color: _color,
  );

  // Headline
  static final headlineLarge = GoogleFonts.manrope(
    fontSize: 32.sp,
    fontWeight: FontWeight.w700,
    color: _color,
  );

  static final headlineMedium = GoogleFonts.manrope(
    fontSize: 28.sp,
    fontWeight: FontWeight.w700,
    color: _color,
  );

  static final headlineSmall = GoogleFonts.manrope(
    fontSize: 24.sp,
    fontWeight: FontWeight.w700,
    color: _color,
  );

  // Title
  static final titleLarge = GoogleFonts.manrope(
    fontSize: 22.sp,
    fontWeight: FontWeight.w700,
    color: _color,
  );

  static final titleMedium = GoogleFonts.manrope(
    fontSize: 16.sp,
    fontWeight: FontWeight.w600,
    color: _color,
  );

  static final titleSmall = GoogleFonts.manrope(
    fontSize: 14.sp,
    fontWeight: FontWeight.w600,
    color: _color,
  );

  // Body
  static final bodyLarge = GoogleFonts.manrope(
    fontSize: 16.sp,
    fontWeight: FontWeight.w400,
    color: _color,
  );

  static final bodyMedium = GoogleFonts.manrope(
    fontSize: 14.sp,
    fontWeight: FontWeight.w400,
    color: _color,
  );

  static final bodySmall = GoogleFonts.manrope(
    fontSize: 12.sp,
    fontWeight: FontWeight.w400,
    color: _color,
  );

  // Label
  static final labelLarge = GoogleFonts.manrope(
    fontSize: 14.sp,
    fontWeight: FontWeight.w500,
    color: _color,
  );

  static final labelMedium = GoogleFonts.manrope(
    fontSize: 12.sp,
    fontWeight: FontWeight.w500,
    color: _color,
  );

  static final labelSmall = GoogleFonts.manrope(
    fontSize: 11.sp,
    fontWeight: FontWeight.w500,
    color: _color,
  );
}