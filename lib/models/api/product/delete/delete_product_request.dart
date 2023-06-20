import 'package:freezed_annotation/freezed_annotation.dart';

part 'delete_product_request.g.dart';
part 'delete_product_request.freezed.dart';

@freezed
// ignore_for_file: invalid_annotation_target
class DeleteProductRequest with _$DeleteProductRequest {
  const factory DeleteProductRequest({
    /// Идшники товаров к удалению
    @JsonKey(name: "productIds") required List<String> productIds,
  }) = DeleteProductReq;

  factory DeleteProductRequest.fromJson(Map<String, dynamic> json) =>
      _$DeleteProductRequestFromJson(json);
}
