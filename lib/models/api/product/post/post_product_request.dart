import 'package:freezed_annotation/freezed_annotation.dart';

part 'post_product_request.g.dart';
part 'post_product_request.freezed.dart';

@freezed
// ignore_for_file: invalid_annotation_target
class PostProductRequest with _$PostProductRequest {
  const factory PostProductRequest({
    /// Наименование товара
    @JsonKey(name: "name") String? name,

    /// Описание товара
    @JsonKey(name: "description") String? description,

    /// Цена товара
    @JsonKey(name: "price") double? price,

    /// Ид фотографий товара
    @JsonKey(name: "photoIds") List<String>? photoIds,
  }) = PostProductReq;

  factory PostProductRequest.fromJson(Map<String, dynamic> json) =>
      _$PostProductRequestFromJson(json);
}
