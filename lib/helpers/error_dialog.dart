import 'package:adaptive_dialog/adaptive_dialog.dart';
import 'package:flutter/material.dart';

Future<void> showErrorDialog({
  required BuildContext context,
  required String message,
}) async {
  await showAlertDialog(
    context: context,
    message: message,
    actions: [
      const AlertDialogAction(key: 'OK', label: 'OK'),
    ],
  );
}
