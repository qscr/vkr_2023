import 'package:dynamic_widget/dynamic_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/providers/data_fetcher.dart';
import 'package:flutter_dynamic_store/providers/data_provider.dart';
import 'package:provider/provider.dart';

class DynamicGridParser extends WidgetParser {
  @override
  Map<String, dynamic>? export(Widget? widget, BuildContext? buildContext) {
    throw UnimplementedError();
  }

  @override
  Widget parse(Map<String, dynamic> map, BuildContext buildContext, ClickListener? listener) {
    final key = map["key"] as String;
    final itemsCount = map["itemsCount"] ?? 2;
    final listOfItems = buildContext.read<DataFetcher>().data[key] as List<dynamic>;
    return GridView.builder(
      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: itemsCount),
      itemBuilder: (context, index) => Provider(
        create: (context) => DataProvider(
          listOfItems[index],
        ),
        child: Builder(
          builder: (context) =>
              DynamicWidgetBuilder.buildFromMap(map["child"], context, listener) ??
              const SizedBox(),
        ),
      ),
      itemCount: listOfItems.length,
    );
  }

  @override
  String get widgetName => "DynamicGrid";

  @override
  Type get widgetType => GridView;
}
