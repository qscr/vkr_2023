import 'package:flutter/material.dart';

class CustomDraggable<T extends Object> extends StatelessWidget {
  final Widget child;
  final T? data;
  final bool enableDrag;
  final void Function()? onDragStarted;

  const CustomDraggable({
    required this.child,
    this.data,
    this.enableDrag = true,
    this.onDragStarted,
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return enableDrag
        ? LongPressDraggable<T>(
            data: data,
            dragAnchorStrategy: pointerDragAnchorStrategy,
            feedback: child,
            onDragStarted: onDragStarted,
            child: child,
          )
        : child;
  }
}
