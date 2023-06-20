import 'package:flutter/material.dart';

class WebModalContainer extends StatelessWidget {
  final Widget child;

  const WebModalContainer({required this.child, Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Material(
      color: Colors.transparent,
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Container(
            constraints: const BoxConstraints(
              minWidth: 300,
              minHeight: 300,
              maxWidth: 600,
              maxHeight: 600,
            ),
            // padding: const EdgeInsets.all(12),
            decoration: BoxDecoration(
              color: Theme.of(context).dialogBackgroundColor,
            ),
            child: SingleChildScrollView(
              child: Column(
                children: [
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        IconButton(
                          onPressed: () {
                            Navigator.of(context).pop();
                          },
                          icon: const Icon(Icons.close),
                        ),
                      ],
                    ),
                  ),
                  child,
                  const SizedBox(height: 30),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
