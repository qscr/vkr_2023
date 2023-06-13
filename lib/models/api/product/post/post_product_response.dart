import 'package:freezed_annotation/freezed_annotation.dart';

part 'post_product_response.g.dart';
part 'post_product_response.freezed.dart';

@freezed
// ignore_for_file: invalid_annotation_target
class PostProductResponse with _$PostProductResponse {
  const factory PostProductResponse({
    /// Ид созданной записи
    @JsonKey(name: "id") String? id,
  }) = PostProductResp;

  factory PostProductResponse.fromJson(Map<String, dynamic> json) =>
      _$PostProductResponseFromJson(json);
}
