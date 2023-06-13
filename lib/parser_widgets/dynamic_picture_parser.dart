import 'package:dynamic_widget/dynamic_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/helpers/image_helper.dart';
import 'package:flutter_dynamic_store/helpers/provider_data_extractor.dart';

class DynamicPictureParser extends WidgetParser {
  @override
  Map<String, dynamic>? export(Widget? widget, BuildContext? buildContext) {
    throw UnimplementedError();
  }

  @override
  Widget parse(Map<String, dynamic> map, BuildContext buildContext, ClickListener? listener) {
    String? url = map["url"];
    if (url == null) {
      final imageId = extractData(map["imageId"] as String, buildContext);
      url = getImageUrlById(imageId);
    }
    final borderRadius = map["borderRadius"] ?? 0.0;
    final height = map["height"];
    final width = map["width"];
    return ClipRRect(
      borderRadius: BorderRadius.circular(borderRadius),
      child: SizedBox(
        height: height ?? 60,
        width: width ?? 60,
        child: Image.network(url),
      ),
    );
  }

  @override
  String get widgetName => "DynamicPicture";

  @override
  Type get widgetType => Image;
}
