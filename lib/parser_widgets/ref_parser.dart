import 'package:dynamic_widget/dynamic_widget.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'package:flutter_dynamic_store/providers/widgets_provider.dart';

class RefParser extends WidgetParser {
  @override
  Map<String, dynamic>? export(Widget? widget, BuildContext? buildContext) {
    throw UnimplementedError();
  }

  @override
  Widget parse(Map<String, dynamic> map, BuildContext buildContext, ClickListener? listener) {
    final provider = buildContext.read<WidgetsProvider>().widgets;
    return Builder(
      builder: (context) =>
          DynamicWidgetBuilder.buildFromMap(
            provider[map['data']],
            context,
            listener,
          ) ??
          const SizedBox(),
    );
  }

  @override
  String get widgetName => "Ref";

  @override
  Type get widgetType => Object;
}
