// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'get_product_request.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

GetProductRequest _$GetProductRequestFromJson(Map<String, dynamic> json) {
  return GetProductReq.fromJson(json);
}

/// @nodoc
mixin _$GetProductRequest {
  /// Номер страницы, начиная с 1
  @JsonKey(name: "pageNumber")
  int? get pageNumber => throw _privateConstructorUsedError;

  /// Размер страницы
  @JsonKey(name: "pageSize")
  int? get pageSize => throw _privateConstructorUsedError;

  /// Поле сортировки
  @JsonKey(name: "orderBy")
  String? get orderBy => throw _privateConstructorUsedError;

  /// Сортировка по возрастанию
  @JsonKey(name: "isAscending")
  bool? get isAscending => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $GetProductRequestCopyWith<GetProductRequest> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $GetProductRequestCopyWith<$Res> {
  factory $GetProductRequestCopyWith(
          GetProductRequest value, $Res Function(GetProductRequest) then) =
      _$GetProductRequestCopyWithImpl<$Res, GetProductRequest>;
  @useResult
  $Res call(
      {@JsonKey(name: "pageNumber") int? pageNumber,
      @JsonKey(name: "pageSize") int? pageSize,
      @JsonKey(name: "orderBy") String? orderBy,
      @JsonKey(name: "isAscending") bool? isAscending});
}

/// @nodoc
class _$GetProductRequestCopyWithImpl<$Res, $Val extends GetProductRequest>
    implements $GetProductRequestCopyWith<$Res> {
  _$GetProductRequestCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? pageNumber = freezed,
    Object? pageSize = freezed,
    Object? orderBy = freezed,
    Object? isAscending = freezed,
  }) {
    return _then(_value.copyWith(
      pageNumber: freezed == pageNumber
          ? _value.pageNumber
          : pageNumber // ignore: cast_nullable_to_non_nullable
              as int?,
      pageSize: freezed == pageSize
          ? _value.pageSize
          : pageSize // ignore: cast_nullable_to_non_nullable
              as int?,
      orderBy: freezed == orderBy
          ? _value.orderBy
          : orderBy // ignore: cast_nullable_to_non_nullable
              as String?,
      isAscending: freezed == isAscending
          ? _value.isAscending
          : isAscending // ignore: cast_nullable_to_non_nullable
              as bool?,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$GetProductReqCopyWith<$Res>
    implements $GetProductRequestCopyWith<$Res> {
  factory _$$GetProductReqCopyWith(
          _$GetProductReq value, $Res Function(_$GetProductReq) then) =
      __$$GetProductReqCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {@JsonKey(name: "pageNumber") int? pageNumber,
      @JsonKey(name: "pageSize") int? pageSize,
      @JsonKey(name: "orderBy") String? orderBy,
      @JsonKey(name: "isAscending") bool? isAscending});
}

/// @nodoc
class __$$GetProductReqCopyWithImpl<$Res>
    extends _$GetProductRequestCopyWithImpl<$Res, _$GetProductReq>
    implements _$$GetProductReqCopyWith<$Res> {
  __$$GetProductReqCopyWithImpl(
      _$GetProductReq _value, $Res Function(_$GetProductReq) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? pageNumber = freezed,
    Object? pageSize = freezed,
    Object? orderBy = freezed,
    Object? isAscending = freezed,
  }) {
    return _then(_$GetProductReq(
      pageNumber: freezed == pageNumber
          ? _value.pageNumber
          : pageNumber // ignore: cast_nullable_to_non_nullable
              as int?,
      pageSize: freezed == pageSize
          ? _value.pageSize
          : pageSize // ignore: cast_nullable_to_non_nullable
              as int?,
      orderBy: freezed == orderBy
          ? _value.orderBy
          : orderBy // ignore: cast_nullable_to_non_nullable
              as String?,
      isAscending: freezed == isAscending
          ? _value.isAscending
          : isAscending // ignore: cast_nullable_to_non_nullable
              as bool?,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$GetProductReq implements GetProductReq {
  const _$GetProductReq(
      {@JsonKey(name: "pageNumber") this.pageNumber,
      @JsonKey(name: "pageSize") this.pageSize,
      @JsonKey(name: "orderBy") this.orderBy,
      @JsonKey(name: "isAscending") this.isAscending});

  factory _$GetProductReq.fromJson(Map<String, dynamic> json) =>
      _$$GetProductReqFromJson(json);

  /// Номер страницы, начиная с 1
  @override
  @JsonKey(name: "pageNumber")
  final int? pageNumber;

  /// Размер страницы
  @override
  @JsonKey(name: "pageSize")
  final int? pageSize;

  /// Поле сортировки
  @override
  @JsonKey(name: "orderBy")
  final String? orderBy;

  /// Сортировка по возрастанию
  @override
  @JsonKey(name: "isAscending")
  final bool? isAscending;

  @override
  String toString() {
    return 'GetProductRequest(pageNumber: $pageNumber, pageSize: $pageSize, orderBy: $orderBy, isAscending: $isAscending)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$GetProductReq &&
            (identical(other.pageNumber, pageNumber) ||
                other.pageNumber == pageNumber) &&
            (identical(other.pageSize, pageSize) ||
                other.pageSize == pageSize) &&
            (identical(other.orderBy, orderBy) || other.orderBy == orderBy) &&
            (identical(other.isAscending, isAscending) ||
                other.isAscending == isAscending));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode =>
      Object.hash(runtimeType, pageNumber, pageSize, orderBy, isAscending);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$GetProductReqCopyWith<_$GetProductReq> get copyWith =>
      __$$GetProductReqCopyWithImpl<_$GetProductReq>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$GetProductReqToJson(
      this,
    );
  }
}

abstract class GetProductReq implements GetProductRequest {
  const factory GetProductReq(
      {@JsonKey(name: "pageNumber") final int? pageNumber,
      @JsonKey(name: "pageSize") final int? pageSize,
      @JsonKey(name: "orderBy") final String? orderBy,
      @JsonKey(name: "isAscending") final bool? isAscending}) = _$GetProductReq;

  factory GetProductReq.fromJson(Map<String, dynamic> json) =
      _$GetProductReq.fromJson;

  @override

  /// Номер страницы, начиная с 1
  @JsonKey(name: "pageNumber")
  int? get pageNumber;
  @override

  /// Размер страницы
  @JsonKey(name: "pageSize")
  int? get pageSize;
  @override

  /// Поле сортировки
  @JsonKey(name: "orderBy")
  String? get orderBy;
  @override

  /// Сортировка по возрастанию
  @JsonKey(name: "isAscending")
  bool? get isAscending;
  @override
  @JsonKey(ignore: true)
  _$$GetProductReqCopyWith<_$GetProductReq> get copyWith =>
      throw _privateConstructorUsedError;
}
