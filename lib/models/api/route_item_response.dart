import 'dart:convert';

import 'package:json_annotation/json_annotation.dart';

part 'route_item_response.g.dart';

@JsonSerializable()
class RouteItemResponse {
  final String name;

  final Map<String, dynamic> content;

  String get contentString => jsonEncode(content);

  RouteItemResponse({
    required this.name,
    required this.content,
  });

  factory RouteItemResponse.fromJson(Map<String, dynamic> json) =>
      _$RouteItemResponseFromJson(json);

  Map<String, dynamic> toJson() => _$RouteItemResponseToJson(this);
}
