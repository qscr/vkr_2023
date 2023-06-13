// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'get_shop_products_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$GetShopProductsResp _$$GetShopProductsRespFromJson(
        Map<String, dynamic> json) =>
    _$GetShopProductsResp(
      entities: (json['entities'] as List<dynamic>?)
          ?.map((e) => GetShopProductsEntitiesResponse.fromJson(
              e as Map<String, dynamic>))
          .toList(),
      totalCount: json['totalCount'] as int?,
    );

Map<String, dynamic> _$$GetShopProductsRespToJson(
        _$GetShopProductsResp instance) =>
    <String, dynamic>{
      'entities': instance.entities,
      'totalCount': instance.totalCount,
    };
