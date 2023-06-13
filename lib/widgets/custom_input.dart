import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

/// Базовый стилизованный инпут
class CustomInput extends StatefulWidget {
  const CustomInput({
    required this.controller,
    this.validator,
    this.height = 40,
    this.width = double.infinity,
    this.prefix,
    this.keyboardType,
    this.readOnly = false,
    this.suffix,
    this.onSuffixTap,
    this.errorText,
    this.hintText,
    this.enabled = true,
    this.onTap,
    this.focusNode,
    this.onSubmitted,
    this.maxLines = 1,
    this.formatters,
    this.hintTextStyle,
    this.initialValue,
    this.helperText,
    this.textAlign,
    this.textStyle,
    this.autoFocus = false,
    this.obscureText = false,
    this.textInputAction,
    Key? key,
  }) : super(key: key);

  final TextEditingController controller;
  final double height;
  final double width;
  final bool obscureText;
  final Widget? prefix;
  final TextInputType? keyboardType;
  final bool readOnly;
  final bool enabled;
  final int maxLines;
  final Widget? suffix;
  final String? Function(String?)? validator;
  final void Function()? onSuffixTap;
  final String? errorText;
  final String? hintText;
  final String? initialValue;
  final void Function()? onTap;
  final void Function(String text)? onSubmitted;
  final FocusNode? focusNode;
  final List<TextInputFormatter>? formatters;
  final TextStyle? hintTextStyle;
  final TextStyle? textStyle;
  final String? helperText;
  final TextAlign? textAlign;
  final bool autoFocus;
  final TextInputAction? textInputAction;

  @override
  _CustomInputState createState() => _CustomInputState();
}

class _CustomInputState extends State<CustomInput> {
  final _border = OutlineInputBorder(
    borderSide: const BorderSide(color: Colors.grey, width: 0.5),
    borderRadius: BorderRadius.circular(8),
  );

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: widget.onTap,
      child: SizedBox(
        width: widget.width,
        child: TextFormField(
          textInputAction: widget.textInputAction,
          initialValue: widget.initialValue,
          validator: widget.validator,
          controller: widget.controller,
          keyboardAppearance: Brightness.light,
          maxLines: widget.maxLines,
          cursorWidth: 2,
          cursorColor: Theme.of(context).primaryColor,
          cursorRadius: const Radius.circular(2),
          textAlignVertical: TextAlignVertical.center,
          textAlign: widget.textAlign ?? TextAlign.left,
          readOnly: widget.readOnly,
          showCursor: true,
          autofocus: widget.autoFocus,
          obscureText: widget.obscureText,
          enabled: widget.enabled,
          decoration: InputDecoration(
            isCollapsed: true,
            errorMaxLines: 3,
            enabled: widget.enabled,
            helperMaxLines: 3,
            prefixIcon: widget.prefix ?? const SizedBox(),
            prefixIconConstraints: widget.prefix == null
                ? BoxConstraints(
                    minWidth: widget.textAlign == TextAlign.center ? 0 : 10,
                  )
                : const BoxConstraints(minWidth: 0, minHeight: 0),
            suffixIcon: widget.suffix,
            suffixIconConstraints:
                widget.suffix != null ? const BoxConstraints(minWidth: 0, minHeight: 0) : null,
            hintText: widget.hintText,
            hintStyle: widget.hintTextStyle,
            contentPadding: const EdgeInsets.symmetric(vertical: 10),
            errorBorder: _border,
            enabledBorder: _border,
            focusedErrorBorder: _border,
            disabledBorder: _border,
            focusedBorder: _border,
            border: _border,
            fillColor: Colors.grey.shade50,
          ),
          inputFormatters: widget.formatters,
          keyboardType: widget.keyboardType,
          enableInteractiveSelection: true,
        ),
      ),
    );
  }
}
