import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/views/modals/web/web_modal_container.dart';
import 'package:flutter_dynamic_store/widgets/custom_input.dart';

class CarouselPickerModal extends StatefulWidget {
  final Map<String, dynamic> data;
  final Map<String, dynamic>? previousValues;

  const CarouselPickerModal({
    required this.data,
    this.previousValues,
    Key? key,
  }) : super(key: key);

  @override
  State<CarouselPickerModal> createState() => _CarouselPickerModalState();
}

class _CarouselPickerModalState extends State<CarouselPickerModal> {
  final List<TextEditingController> _urlControllers = [];

  @override
  void initState() {
    if (widget.previousValues?['items'] != null) {
      final List<dynamic> items = widget.previousValues!['items'];
      for (var item in items) {
        _urlControllers.add(TextEditingController(text: item['url']));
      }
    }
    if (_urlControllers.isEmpty) {
      _urlControllers.add(TextEditingController());
    }
    setState(() {});
    super.initState();
  }

  @override
  void dispose() {
    for (var controller in _urlControllers) {
      controller.dispose();
    }
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return WebModalContainer(
      child: Column(
        children: [
          ..._urlControllers
              .mapIndexed(
                (index, element) => Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text("url"),
                      const SizedBox(height: 10),
                      CustomInput(
                        controller: element,
                        keyboardType: TextInputType.text,
                      ),
                    ],
                  ),
                ),
              )
              .toList(),
          const SizedBox(height: 40),
          ElevatedButton.icon(
            onPressed: () {
              setState(() {
                _urlControllers.add(TextEditingController());
              });
            },
            icon: const Icon(Icons.add),
            label: const Text("Добавить URL"),
          ),
          const SizedBox(height: 40),
          ElevatedButton.icon(
            onPressed: () {
              final map = {"items": []};
              for (var controller in _urlControllers) {
                map["items"]!.add({"url": controller.text});
              }
              widget.data.addAll(map);
              Navigator.of(context).pop();
            },
            icon: const Icon(Icons.check),
            label: const Text("Готово"),
          ),
        ],
      ),
    );
  }
}
