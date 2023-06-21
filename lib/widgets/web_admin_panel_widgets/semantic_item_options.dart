import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/views/modals/web/web_modal_container.dart';
import 'package:flutter_dynamic_store/widgets/custom_dropdown_input.dart';
import 'package:flutter_dynamic_store/widgets/custom_input.dart';
import 'package:flutter_dynamic_store/widgets/web_admin_panel_widgets/custom_picker_modals/carousel_picker_modal.dart';

enum PickingType {
  string,
  int,
  double,
  bool,
  enumerate,
}

extension PickingKeyboardType on SemanticOption {
  Widget getPicker(TextEditingController controller) {
    switch (type) {
      case PickingType.string:
        return CustomInput(
          controller: controller,
          keyboardType: TextInputType.text,
        );
      case PickingType.int:
        return CustomInput(
          controller: controller,
          keyboardType: TextInputType.number,
        );
      case PickingType.double:
        return CustomInput(
          controller: controller,
          keyboardType: const TextInputType.numberWithOptions(decimal: true),
        );
      case PickingType.bool:
        return CustomDropdownInput(
          controller: controller,
          items: [
            DropdownItem(value: false, name: "False"),
            DropdownItem(value: true, name: "True"),
          ],
          valueConverter: (value) => value ? 'true' : 'false',
        );
      case PickingType.enumerate:
        return CustomDropdownInput<String>(
          controller: controller,
          items: variants?.map((e) => DropdownItem<String>(value: e, name: e)).toList() ?? [],
          valueConverter: (value) => value,
        );
      default:
        return const SizedBox();
    }
  }
}

class SemanticOption<T> {
  final String name;

  final PickingType type;

  final T? defaultValue;

  final List<String>? variants;

  SemanticOption({
    required this.name,
    required this.type,
    this.defaultValue,
    this.variants,
  });
}

class BaseSemanticItemOptions {
  Map<String, dynamic> data = <String, dynamic>{};

  final List<SemanticOption> options;

  void Function(Map<String, dynamic> data)? onPicked;

  void setOnPickedFunc(Function(Map<String, dynamic> data)? onPicked) {
    this.onPicked = onPicked;
  }

  BaseSemanticItemOptions({
    required this.options,
    this.onPicked,
  });

  Future<void> showPicker({
    required BuildContext context,
    Map<String, dynamic>? previousValues,
  }) async {
    data = <String, dynamic>{};

    await showDialog(
      context: context,
      builder: (context) => SemanticOptionsPicker(
        data: data,
        options: options,
        previousValues: previousValues,
      ),
    );
    onPicked?.call(data);
  }
}

dynamic castToOptionType(PickingType type, String value) {
  if (value.isEmpty) {
    return '';
  }
  switch (type) {
    case PickingType.string:
      return value;
    case PickingType.int:
      return int.parse(value);
    case PickingType.double:
      return double.parse(value);
    case PickingType.bool:
      return value;
    case PickingType.enumerate:
      return value;
  }
}

class SemanticOptionsPicker extends StatefulWidget {
  final Map<String, dynamic> data;

  final List<SemanticOption> options;

  final Map<String, dynamic>? previousValues;

  const SemanticOptionsPicker({
    required this.data,
    required this.options,
    this.previousValues,
    Key? key,
  }) : super(key: key);

  @override
  State<SemanticOptionsPicker> createState() => _SemanticOptionsPickerState();
}

class _SemanticOptionsPickerState extends State<SemanticOptionsPicker> {
  final List<TextEditingController> controllers = [];

  @override
  void initState() {
    for (var _ in widget.options) {
      controllers.add(TextEditingController());
    }
    for (var i = 0; i < widget.options.length; i++) {
      if (widget.previousValues?[widget.options[i].name] != null) {
        controllers[i].text = widget.previousValues?[widget.options[i].name]?.toString() ?? '';
      }
    }
    super.initState();
  }

  @override
  void dispose() {
    for (var controller in controllers) {
      controller.dispose();
    }
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return WebModalContainer(
      child: Column(
        children: [
          ...widget.options
              .mapIndexed(
                (index, element) => Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(element.name),
                      const SizedBox(height: 10),
                      element.getPicker(controllers[index]),
                    ],
                  ),
                ),
              )
              .toList(),
          const SizedBox(height: 40),
          ElevatedButton.icon(
            onPressed: () {
              final List<MapEntry<String, dynamic>> entries = [];
              for (var index = 0; index < widget.options.length; index++) {
                final element = widget.options[index];
                if (controllers[index].text.isEmpty) {
                  continue;
                }
                entries.add(
                  MapEntry(
                    widget.options[index].name,
                    castToOptionType(element.type, controllers[index].text),
                  ),
                );
              }
              widget.data.addEntries(entries);
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

class TextSemanticOptions extends BaseSemanticItemOptions {
  TextSemanticOptions()
      : super(
          options: [
            SemanticOption(name: "data", type: PickingType.string),
            SemanticOption(name: "maxLines", type: PickingType.int),
            SemanticOption(name: "textScaleFactor", type: PickingType.double),
            SemanticOption(name: "active", type: PickingType.bool),
            SemanticOption(
              name: "textAlign",
              type: PickingType.enumerate,
              variants: [
                "start",
                "end",
                "center",
              ],
            )
          ],
        );
}

class PictureSemanticOptions extends BaseSemanticItemOptions {
  PictureSemanticOptions()
      : super(
          options: [
            SemanticOption(name: "url", type: PickingType.string),
            SemanticOption(name: "borderRadius", type: PickingType.double),
            SemanticOption(name: "height", type: PickingType.double),
            SemanticOption(name: "width", type: PickingType.double),
          ],
        );
}

class SizedBoxOptions extends BaseSemanticItemOptions {
  SizedBoxOptions()
      : super(
          options: [
            SemanticOption(name: "height", type: PickingType.double),
            SemanticOption(name: "width", type: PickingType.double),
          ],
        );
}

class CarouselOptions extends BaseSemanticItemOptions {
  CarouselOptions() : super(options: []);

  @override
  Future<void> showPicker({
    required BuildContext context,
    Map<String, dynamic>? previousValues,
  }) async {
    data = <String, dynamic>{};
    await showDialog(
      context: context,
      builder: (context) => CarouselPickerModal(
        data: data,
        previousValues: previousValues,
      ),
    );
    onPicked?.call(data);
  }
}
