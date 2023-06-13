import 'package:flutter/material.dart';

class WidgetsProvider extends ChangeNotifier {
  Map<String, dynamic> get widgets => _widgets;

  set widgets(Map<String, dynamic> widgets) {
    _widgets = widgets;
  }

  Map<String, dynamic> _widgets = {};

  WidgetsProvider(this._widgets);
}
