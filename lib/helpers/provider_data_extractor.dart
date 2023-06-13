import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/providers/data_provider.dart';
import 'package:provider/provider.dart';

String extractData(String data, BuildContext context) {
  final regex = RegExp("{([^}]+)}");
  final matches = regex.allMatches(data);
  if (matches.isEmpty) {
    return data;
  }
  try {
    final dataProvider = context.read<DataProvider>();
    String currentString = data;
    for (var match in matches) {
      final key = match.group(0);
      if (key == null || key.isEmpty) {
        break;
      }
      currentString =
          currentString.replaceFirst(key, dataProvider.data[key.substring(1, key.length - 1)]);
    }
    return currentString;
  } catch (e) {
    return data;
  }
}

String extractDataFromMap(String data, Map<String, dynamic> dataMap) {
  final regex = RegExp("{([^}]+)}");
  final matches = regex.allMatches(data);
  if (matches.isEmpty) {
    return data;
  }
  try {
    String currentString = data;
    for (var match in matches) {
      final key = match.group(0);
      if (key == null || key.isEmpty) {
        break;
      }
      currentString = currentString.replaceFirst(key, dataMap[key.substring(1, key.length - 1)]);
    }
    return currentString;
  } catch (e) {
    return data;
  }
}
