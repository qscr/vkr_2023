// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'delete_product_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$DeleteProductReq _$$DeleteProductReqFromJson(Map<String, dynamic> json) =>
    _$DeleteProductReq(
      productIds: (json['productIds'] as List<dynamic>)
          .map((e) => e as String)
          .toList(),
    );

Map<String, dynamic> _$$DeleteProductReqToJson(_$DeleteProductReq instance) =>
    <String, dynamic>{
      'productIds': instance.productIds,
    };
