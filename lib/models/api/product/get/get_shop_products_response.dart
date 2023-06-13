import 'package:flutter_dynamic_store/models/api/product/get/get_shop_products_entities_response.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'get_shop_products_response.g.dart';
part 'get_shop_products_response.freezed.dart';

@freezed
// ignore_for_file: invalid_annotation_target
class GetShopProductsResponse with _$GetShopProductsResponse {
  const factory GetShopProductsResponse({
    /// Список сущностей
    @JsonKey(name: "entities") List<GetShopProductsEntitiesResponse>? entities,

    /// Общее количество сущностей
    @JsonKey(name: "totalCount") int? totalCount,
  }) = GetShopProductsResp;

  factory GetShopProductsResponse.fromJson(Map<String, dynamic> json) =>
      _$GetShopProductsResponseFromJson(json);
}
