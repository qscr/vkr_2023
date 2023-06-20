// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'post_product_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$PostProductReq _$$PostProductReqFromJson(Map<String, dynamic> json) =>
    _$PostProductReq(
      name: json['name'] as String?,
      description: json['description'] as String?,
      price: (json['price'] as num?)?.toDouble(),
      photoIds: (json['photoIds'] as List<dynamic>?)
          ?.map((e) => e as String)
          .toList(),
    );

Map<String, dynamic> _$$PostProductReqToJson(_$PostProductReq instance) =>
    <String, dynamic>{
      'name': instance.name,
      'description': instance.description,
      'price': instance.price,
      'photoIds': instance.photoIds,
    };
