// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'get_shop_products_response.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

GetShopProductsResponse _$GetShopProductsResponseFromJson(
    Map<String, dynamic> json) {
  return GetShopProductsResp.fromJson(json);
}

/// @nodoc
mixin _$GetShopProductsResponse {
  /// Список сущностей
  @JsonKey(name: "entities")
  List<GetShopProductsEntitiesResponse>? get entities =>
      throw _privateConstructorUsedError;

  /// Общее количество сущностей
  @JsonKey(name: "totalCount")
  int? get totalCount => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $GetShopProductsResponseCopyWith<GetShopProductsResponse> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $GetShopProductsResponseCopyWith<$Res> {
  factory $GetShopProductsResponseCopyWith(GetShopProductsResponse value,
          $Res Function(GetShopProductsResponse) then) =
      _$GetShopProductsResponseCopyWithImpl<$Res, GetShopProductsResponse>;
  @useResult
  $Res call(
      {@JsonKey(name: "entities")
          List<GetShopProductsEntitiesResponse>? entities,
      @JsonKey(name: "totalCount")
          int? totalCount});
}

/// @nodoc
class _$GetShopProductsResponseCopyWithImpl<$Res,
        $Val extends GetShopProductsResponse>
    implements $GetShopProductsResponseCopyWith<$Res> {
  _$GetShopProductsResponseCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? entities = freezed,
    Object? totalCount = freezed,
  }) {
    return _then(_value.copyWith(
      entities: freezed == entities
          ? _value.entities
          : entities // ignore: cast_nullable_to_non_nullable
              as List<GetShopProductsEntitiesResponse>?,
      totalCount: freezed == totalCount
          ? _value.totalCount
          : totalCount // ignore: cast_nullable_to_non_nullable
              as int?,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$GetShopProductsRespCopyWith<$Res>
    implements $GetShopProductsResponseCopyWith<$Res> {
  factory _$$GetShopProductsRespCopyWith(_$GetShopProductsResp value,
          $Res Function(_$GetShopProductsResp) then) =
      __$$GetShopProductsRespCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {@JsonKey(name: "entities")
          List<GetShopProductsEntitiesResponse>? entities,
      @JsonKey(name: "totalCount")
          int? totalCount});
}

/// @nodoc
class __$$GetShopProductsRespCopyWithImpl<$Res>
    extends _$GetShopProductsResponseCopyWithImpl<$Res, _$GetShopProductsResp>
    implements _$$GetShopProductsRespCopyWith<$Res> {
  __$$GetShopProductsRespCopyWithImpl(
      _$GetShopProductsResp _value, $Res Function(_$GetShopProductsResp) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? entities = freezed,
    Object? totalCount = freezed,
  }) {
    return _then(_$GetShopProductsResp(
      entities: freezed == entities
          ? _value._entities
          : entities // ignore: cast_nullable_to_non_nullable
              as List<GetShopProductsEntitiesResponse>?,
      totalCount: freezed == totalCount
          ? _value.totalCount
          : totalCount // ignore: cast_nullable_to_non_nullable
              as int?,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$GetShopProductsResp implements GetShopProductsResp {
  const _$GetShopProductsResp(
      {@JsonKey(name: "entities")
          final List<GetShopProductsEntitiesResponse>? entities,
      @JsonKey(name: "totalCount")
          this.totalCount})
      : _entities = entities;

  factory _$GetShopProductsResp.fromJson(Map<String, dynamic> json) =>
      _$$GetShopProductsRespFromJson(json);

  /// Список сущностей
  final List<GetShopProductsEntitiesResponse>? _entities;

  /// Список сущностей
  @override
  @JsonKey(name: "entities")
  List<GetShopProductsEntitiesResponse>? get entities {
    final value = _entities;
    if (value == null) return null;
    if (_entities is EqualUnmodifiableListView) return _entities;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(value);
  }

  /// Общее количество сущностей
  @override
  @JsonKey(name: "totalCount")
  final int? totalCount;

  @override
  String toString() {
    return 'GetShopProductsResponse(entities: $entities, totalCount: $totalCount)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$GetShopProductsResp &&
            const DeepCollectionEquality().equals(other._entities, _entities) &&
            (identical(other.totalCount, totalCount) ||
                other.totalCount == totalCount));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType, const DeepCollectionEquality().hash(_entities), totalCount);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$GetShopProductsRespCopyWith<_$GetShopProductsResp> get copyWith =>
      __$$GetShopProductsRespCopyWithImpl<_$GetShopProductsResp>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$GetShopProductsRespToJson(
      this,
    );
  }
}

abstract class GetShopProductsResp implements GetShopProductsResponse {
  const factory GetShopProductsResp(
      {@JsonKey(name: "entities")
          final List<GetShopProductsEntitiesResponse>? entities,
      @JsonKey(name: "totalCount")
          final int? totalCount}) = _$GetShopProductsResp;

  factory GetShopProductsResp.fromJson(Map<String, dynamic> json) =
      _$GetShopProductsResp.fromJson;

  @override

  /// Список сущностей
  @JsonKey(name: "entities")
  List<GetShopProductsEntitiesResponse>? get entities;
  @override

  /// Общее количество сущностей
  @JsonKey(name: "totalCount")
  int? get totalCount;
  @override
  @JsonKey(ignore: true)
  _$$GetShopProductsRespCopyWith<_$GetShopProductsResp> get copyWith =>
      throw _privateConstructorUsedError;
}
