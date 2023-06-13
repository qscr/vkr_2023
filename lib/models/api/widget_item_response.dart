import 'dart:convert';

import 'package:json_annotation/json_annotation.dart';

part 'widget_item_response.g.dart';

@JsonSerializable()
class WidgetItemResponse {
  final String name;

  final Map<String, dynamic> content;

  String get contentString => jsonEncode(content);

  WidgetItemResponse({
    required this.name,
    required this.content,
  });

  factory WidgetItemResponse.fromJson(Map<String, dynamic> json) =>
      _$WidgetItemResponseFromJson(json);

  Map<String, dynamic> toJson() => _$WidgetItemResponseToJson(this);
}
