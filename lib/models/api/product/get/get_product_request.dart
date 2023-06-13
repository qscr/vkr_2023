import 'package:freezed_annotation/freezed_annotation.dart';

part 'get_product_request.g.dart';
part 'get_product_request.freezed.dart';

@freezed
// ignore_for_file: invalid_annotation_target
class GetProductRequest with _$GetProductRequest {
  const factory GetProductRequest({
    /// Номер страницы, начиная с 1
    @JsonKey(name: "pageNumber") int? pageNumber,

    /// Размер страницы
    @JsonKey(name: "pageSize") int? pageSize,

    /// Поле сортировки
    @JsonKey(name: "orderBy") String? orderBy,

    /// Сортировка по возрастанию
    @JsonKey(name: "isAscending") bool? isAscending,
  }) = GetProductReq;

  factory GetProductRequest.fromJson(Map<String, dynamic> json) =>
      _$GetProductRequestFromJson(json);
}
