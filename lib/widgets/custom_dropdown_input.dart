import 'package:flutter/material.dart';

class DropdownItem<T> {
  final T value;
  final String name;

  DropdownItem({
    required this.value,
    required this.name,
  });
}

class CustomDropdownInput<T> extends StatefulWidget {
  final T? currentValue;
  final List<DropdownItem<T>> items;
  final String Function(dynamic value) valueConverter;
  final TextEditingController controller;

  const CustomDropdownInput({
    required this.controller,
    this.currentValue,
    required this.items,
    required this.valueConverter,
    Key? key,
  }) : super(key: key);

  @override
  State<CustomDropdownInput> createState() => _CustomDropdownInputState();
}

class _CustomDropdownInputState<T> extends State<CustomDropdownInput<T>> {
  late T? currentValue = widget.currentValue;
  @override
  Widget build(BuildContext context) {
    return DropdownButton<T>(
      isExpanded: true,
      value: currentValue,
      onChanged: (newValue) {
        if (newValue != null) {
          setState(() {
            currentValue = newValue;
          });
          widget.controller.text = widget.valueConverter(newValue);
          print(widget.controller.text);
        }
      },
      items: widget.items
          .map(
            (e) => DropdownMenuItem<T>(
              value: e.value,
              child: Text(e.name),
            ),
          )
          .toList(),
    );
  }
}
