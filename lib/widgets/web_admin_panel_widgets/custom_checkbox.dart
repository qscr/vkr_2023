import 'package:flutter/material.dart';

class CustomCheckbox extends StatelessWidget {
  final bool value;
  final void Function(bool?)? onChanged;

  const CustomCheckbox({
    required this.value,
    required this.onChanged,
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Checkbox.adaptive(
      value: value,
      onChanged: onChanged,
    );
  }
}
