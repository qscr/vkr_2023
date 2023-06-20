import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/views/web_admin_panel/web_generator_view.dart';
import 'package:flutter_dynamic_store/widgets/web_admin_panel_widgets/custom_draggable.dart';
import 'package:flutter_dynamic_store/widgets/web_admin_panel_widgets/semantic_item_options.dart';
import 'package:uuid/uuid.dart';

class SemanticItem extends StatelessWidget {
  final String name;
  final Map<String, dynamic> json;
  final bool enableDrag;
  final bool isTemplate;
  final BaseSemanticItemOptions? options;
  final VoidCallback? updateFunc;
  final void Function({
    required Map<String, dynamic> elementToMove,
    required Map<String, dynamic> elementToPlace,
    required DirectionToMove direction,
  }) moveFunc;

  SemanticItem({
    required this.name,
    required this.json,
    this.enableDrag = true,
    this.isTemplate = true,
    required this.moveFunc,
    this.updateFunc,
    this.options,
    Key? key,
  }) : super(key: key) {
    if (!json.containsKey("id")) {
      json.addAll(
        {"id": const Uuid().v4()},
      );
    }

    if (!json.containsKey("name")) {
      json.addAll(
        {"name": name},
      );
    }

    options?.setOnPickedFunc((data) {
      json.addEntries(data.entries);
      updateFunc?.call();
    });
  }

  @override
  Widget build(BuildContext context) {
    return CustomDraggable<Map<String, dynamic>>(
      data: json,
      enableDrag: enableDrag,
      onDragStarted: () {
        if (isTemplate) {
          json["id"] = const Uuid().v4();
        }
      },
      child: GestureDetector(
        onTap: () async {
          await options?.showPicker(
            context: context,
            previousValues: json,
          );
        },
        child: Stack(
          children: [
            Container(
              height: 100,
              width: 100,
              alignment: Alignment.center,
              color: Colors.blue,
              child: Text(
                name,
                style: Theme.of(context).textTheme.labelMedium,
              ),
            ),
            DragTarget<Map<String, dynamic>>(
              builder: (context, candidate, rejected) => Container(
                height: 20,
                width: 100,
                color: candidate.isNotEmpty ? Colors.red : Colors.transparent,
              ),
              onAccept: (data) {
                moveFunc(elementToMove: data, elementToPlace: json, direction: DirectionToMove.up);
              },
            ),
            Positioned(
              bottom: 0,
              right: 0,
              left: 0,
              child: DragTarget<Map<String, dynamic>>(
                builder: (context, candidate, rejected) => Container(
                  height: 20,
                  width: 100,
                  color: candidate.isNotEmpty ? Colors.red : Colors.transparent,
                ),
                onAccept: (data) {
                  moveFunc(
                      elementToMove: data, elementToPlace: json, direction: DirectionToMove.down);
                },
              ),
            ),
          ],
        ),
      ),
    );
  }
}
