// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'route_item_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RouteItemResponse _$RouteItemResponseFromJson(Map<String, dynamic> json) =>
    RouteItemResponse(
      name: json['name'] as String,
      content: json['content'] as Map<String, dynamic>,
    );

Map<String, dynamic> _$RouteItemResponseToJson(RouteItemResponse instance) =>
    <String, dynamic>{
      'name': instance.name,
      'content': instance.content,
    };
