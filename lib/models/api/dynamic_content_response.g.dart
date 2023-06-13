// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'dynamic_content_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DynamicContentResponse _$DynamicContentResponseFromJson(
        Map<String, dynamic> json) =>
    DynamicContentResponse(
      initialRouteName: json['initialRouteName'] as String,
      routes: (json['routes'] as List<dynamic>)
          .map((e) => RouteItemResponse.fromJson(e as Map<String, dynamic>))
          .toList(),
      widgets: (json['widgets'] as List<dynamic>)
          .map((e) => WidgetItemResponse.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$DynamicContentResponseToJson(
        DynamicContentResponse instance) =>
    <String, dynamic>{
      'initialRouteName': instance.initialRouteName,
      'routes': instance.routes,
      'widgets': instance.widgets,
    };
