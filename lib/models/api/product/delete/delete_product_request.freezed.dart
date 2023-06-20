// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'delete_product_request.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

DeleteProductRequest _$DeleteProductRequestFromJson(Map<String, dynamic> json) {
  return DeleteProductReq.fromJson(json);
}

/// @nodoc
mixin _$DeleteProductRequest {
  /// Идшники товаров к удалению
  @JsonKey(name: "productIds")
  List<String> get productIds => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $DeleteProductRequestCopyWith<DeleteProductRequest> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $DeleteProductRequestCopyWith<$Res> {
  factory $DeleteProductRequestCopyWith(DeleteProductRequest value,
          $Res Function(DeleteProductRequest) then) =
      _$DeleteProductRequestCopyWithImpl<$Res, DeleteProductRequest>;
  @useResult
  $Res call({@JsonKey(name: "productIds") List<String> productIds});
}

/// @nodoc
class _$DeleteProductRequestCopyWithImpl<$Res,
        $Val extends DeleteProductRequest>
    implements $DeleteProductRequestCopyWith<$Res> {
  _$DeleteProductRequestCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? productIds = null,
  }) {
    return _then(_value.copyWith(
      productIds: null == productIds
          ? _value.productIds
          : productIds // ignore: cast_nullable_to_non_nullable
              as List<String>,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$DeleteProductReqCopyWith<$Res>
    implements $DeleteProductRequestCopyWith<$Res> {
  factory _$$DeleteProductReqCopyWith(
          _$DeleteProductReq value, $Res Function(_$DeleteProductReq) then) =
      __$$DeleteProductReqCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({@JsonKey(name: "productIds") List<String> productIds});
}

/// @nodoc
class __$$DeleteProductReqCopyWithImpl<$Res>
    extends _$DeleteProductRequestCopyWithImpl<$Res, _$DeleteProductReq>
    implements _$$DeleteProductReqCopyWith<$Res> {
  __$$DeleteProductReqCopyWithImpl(
      _$DeleteProductReq _value, $Res Function(_$DeleteProductReq) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? productIds = null,
  }) {
    return _then(_$DeleteProductReq(
      productIds: null == productIds
          ? _value._productIds
          : productIds // ignore: cast_nullable_to_non_nullable
              as List<String>,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$DeleteProductReq implements DeleteProductReq {
  const _$DeleteProductReq(
      {@JsonKey(name: "productIds") required final List<String> productIds})
      : _productIds = productIds;

  factory _$DeleteProductReq.fromJson(Map<String, dynamic> json) =>
      _$$DeleteProductReqFromJson(json);

  /// Идшники товаров к удалению
  final List<String> _productIds;

  /// Идшники товаров к удалению
  @override
  @JsonKey(name: "productIds")
  List<String> get productIds {
    if (_productIds is EqualUnmodifiableListView) return _productIds;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_productIds);
  }

  @override
  String toString() {
    return 'DeleteProductRequest(productIds: $productIds)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$DeleteProductReq &&
            const DeepCollectionEquality()
                .equals(other._productIds, _productIds));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType, const DeepCollectionEquality().hash(_productIds));

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$DeleteProductReqCopyWith<_$DeleteProductReq> get copyWith =>
      __$$DeleteProductReqCopyWithImpl<_$DeleteProductReq>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$DeleteProductReqToJson(
      this,
    );
  }
}

abstract class DeleteProductReq implements DeleteProductRequest {
  const factory DeleteProductReq(
      {@JsonKey(name: "productIds")
          required final List<String> productIds}) = _$DeleteProductReq;

  factory DeleteProductReq.fromJson(Map<String, dynamic> json) =
      _$DeleteProductReq.fromJson;

  @override

  /// Идшники товаров к удалению
  @JsonKey(name: "productIds")
  List<String> get productIds;
  @override
  @JsonKey(ignore: true)
  _$$DeleteProductReqCopyWith<_$DeleteProductReq> get copyWith =>
      throw _privateConstructorUsedError;
}
