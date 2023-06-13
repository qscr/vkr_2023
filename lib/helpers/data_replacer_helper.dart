import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/providers/data_provider.dart';
import 'package:provider/provider.dart';

void dataReplacerHelper(Map<String, dynamic>? map, BuildContext? context) {
  if (map?.isEmpty ?? true) {
    return;
  }
  if (context == null) {
    return;
  }
  try {
    final dataProvider = context.read<DataProvider>();
  } catch (e) {
    return;
  }
}
