import 'dart:async';

import 'package:blobs/blobs.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/theme/color_theme.dart';

class BlobsBackground extends StatefulWidget {
  const BlobsBackground({Key? key}) : super(key: key);

  @override
  State<BlobsBackground> createState() => _BlobsBackgroundState();
}

class _BlobsBackgroundState extends State<BlobsBackground> {
  final _blobControllers = [
    BlobController(),
    BlobController(),
    BlobController(),
    BlobController(),
  ];
  Timer? _blobTimer;

  final _animationDuration = const Duration(seconds: 1);

  @override
  void initState() {
    _blobTimer = Timer.periodic(const Duration(seconds: 3), (timer) {
      for (var blobController in _blobControllers) {
        blobController.change();
      }
    });
    super.initState();
  }

  @override
  void dispose() {
    _blobTimer?.cancel();
    for (var blobController in _blobControllers) {
      blobController.dispose();
    }
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final brightness = MediaQuery.platformBrightnessOf(context);
    final size = MediaQuery.of(context).size;

    return Column(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Blob.animatedRandom(
              size: size.height * 0.3,
              debug: false,
              controller: _blobControllers[0],
              duration: _animationDuration,
              styles: BlobStyles(
                color: brightness == Brightness.light
                    ? lightColorScheme.inversePrimary
                    : darkColorScheme.inversePrimary,
                fillType: BlobFillType.stroke,
              ),
            ),
            Padding(
              padding: const EdgeInsets.fromLTRB(50, 50, 0, 0),
              child: Blob.animatedRandom(
                size: size.height * 0.2,
                debug: false,
                duration: _animationDuration,
                controller: _blobControllers[1],
                styles: BlobStyles(
                  color: brightness == Brightness.light
                      ? lightColorScheme.surfaceTint
                      : darkColorScheme.surfaceTint,
                ),
              ),
            ),
          ],
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Blob.animatedRandom(
              size: size.height * 0.2,
              debug: false,
              duration: _animationDuration,
              controller: _blobControllers[2],
              styles: BlobStyles(
                color: brightness == Brightness.light
                    ? lightColorScheme.surfaceTint
                    : darkColorScheme.surfaceTint,
              ),
            ),
            Padding(
              padding: const EdgeInsets.fromLTRB(10, 100, 0, 0),
              child: Blob.animatedRandom(
                size: size.height * 0.3,
                debug: false,
                duration: _animationDuration,
                controller: _blobControllers[3],
                styles: BlobStyles(
                  color: brightness == Brightness.light
                      ? lightColorScheme.inversePrimary
                      : darkColorScheme.inversePrimary,
                  fillType: BlobFillType.stroke,
                ),
              ),
            ),
          ],
        ),
      ],
    );
  }
}
