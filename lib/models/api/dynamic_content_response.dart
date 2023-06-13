import 'package:flutter_dynamic_store/models/api/route_item_response.dart';
import 'package:flutter_dynamic_store/models/api/widget_item_response.dart';
import 'package:json_annotation/json_annotation.dart';

part 'dynamic_content_response.g.dart';

@JsonSerializable()
class DynamicContentResponse {
  final String initialRouteName;

  final List<RouteItemResponse> routes;

  final List<WidgetItemResponse> widgets;

  Map<String, dynamic> get widgetsMap {
    return {for (var item in widgets) item.name: item.content};
  }

  DynamicContentResponse({
    required this.initialRouteName,
    required this.routes,
    required this.widgets,
  });

  factory DynamicContentResponse.fromJson(Map<String, dynamic> json) =>
      _$DynamicContentResponseFromJson(json);

  Map<String, dynamic> toJson() => _$DynamicContentResponseToJson(this);
}
