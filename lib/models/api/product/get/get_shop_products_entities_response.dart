import 'package:freezed_annotation/freezed_annotation.dart';

part 'get_shop_products_entities_response.g.dart';
part 'get_shop_products_entities_response.freezed.dart';

@freezed
// ignore_for_file: invalid_annotation_target
class GetShopProductsEntitiesResponse with _$GetShopProductsEntitiesResponse {
  const factory GetShopProductsEntitiesResponse({
    /// ИД сущности
    @JsonKey(name: "id") String? id,

    /// Наименование товара
    @JsonKey(name: "name") String? name,

    /// Описание товара
    @JsonKey(name: "description") String? description,

    /// Цена товара
    @JsonKey(name: "price") double? price,

    /// Ид фотографий товара
    @JsonKey(name: "photoIds") List<String>? photoIds,

    /// Ид категорий товара
    @JsonKey(name: "categoryIds") List<String>? categoryIds,
  }) = GetShopProductsEntitiesResp;

  factory GetShopProductsEntitiesResponse.fromJson(Map<String, dynamic> json) =>
      _$GetShopProductsEntitiesResponseFromJson(json);
}
