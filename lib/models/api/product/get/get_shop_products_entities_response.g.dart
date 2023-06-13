// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'get_shop_products_entities_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$GetShopProductsEntitiesResp _$$GetShopProductsEntitiesRespFromJson(
        Map<String, dynamic> json) =>
    _$GetShopProductsEntitiesResp(
      id: json['id'] as String?,
      name: json['name'] as String?,
      description: json['description'] as String?,
      price: (json['price'] as num?)?.toDouble(),
      photoIds: (json['photoIds'] as List<dynamic>?)
          ?.map((e) => e as String)
          .toList(),
      categoryIds: (json['categoryIds'] as List<dynamic>?)
          ?.map((e) => e as String)
          .toList(),
    );

Map<String, dynamic> _$$GetShopProductsEntitiesRespToJson(
        _$GetShopProductsEntitiesResp instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'description': instance.description,
      'price': instance.price,
      'photoIds': instance.photoIds,
      'categoryIds': instance.categoryIds,
    };
