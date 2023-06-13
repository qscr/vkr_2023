// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'get_shop_products_entities_response.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

GetShopProductsEntitiesResponse _$GetShopProductsEntitiesResponseFromJson(
    Map<String, dynamic> json) {
  return GetShopProductsEntitiesResp.fromJson(json);
}

/// @nodoc
mixin _$GetShopProductsEntitiesResponse {
  /// ИД сущности
  @JsonKey(name: "id")
  String? get id => throw _privateConstructorUsedError;

  /// Наименование товара
  @JsonKey(name: "name")
  String? get name => throw _privateConstructorUsedError;

  /// Описание товара
  @JsonKey(name: "description")
  String? get description => throw _privateConstructorUsedError;

  /// Цена товара
  @JsonKey(name: "price")
  double? get price => throw _privateConstructorUsedError;

  /// Ид фотографий товара
  @JsonKey(name: "photoIds")
  List<String>? get photoIds => throw _privateConstructorUsedError;

  /// Ид категорий товара
  @JsonKey(name: "categoryIds")
  List<String>? get categoryIds => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $GetShopProductsEntitiesResponseCopyWith<GetShopProductsEntitiesResponse>
      get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $GetShopProductsEntitiesResponseCopyWith<$Res> {
  factory $GetShopProductsEntitiesResponseCopyWith(
          GetShopProductsEntitiesResponse value,
          $Res Function(GetShopProductsEntitiesResponse) then) =
      _$GetShopProductsEntitiesResponseCopyWithImpl<$Res,
          GetShopProductsEntitiesResponse>;
  @useResult
  $Res call(
      {@JsonKey(name: "id") String? id,
      @JsonKey(name: "name") String? name,
      @JsonKey(name: "description") String? description,
      @JsonKey(name: "price") double? price,
      @JsonKey(name: "photoIds") List<String>? photoIds,
      @JsonKey(name: "categoryIds") List<String>? categoryIds});
}

/// @nodoc
class _$GetShopProductsEntitiesResponseCopyWithImpl<$Res,
        $Val extends GetShopProductsEntitiesResponse>
    implements $GetShopProductsEntitiesResponseCopyWith<$Res> {
  _$GetShopProductsEntitiesResponseCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = freezed,
    Object? name = freezed,
    Object? description = freezed,
    Object? price = freezed,
    Object? photoIds = freezed,
    Object? categoryIds = freezed,
  }) {
    return _then(_value.copyWith(
      id: freezed == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String?,
      name: freezed == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String?,
      description: freezed == description
          ? _value.description
          : description // ignore: cast_nullable_to_non_nullable
              as String?,
      price: freezed == price
          ? _value.price
          : price // ignore: cast_nullable_to_non_nullable
              as double?,
      photoIds: freezed == photoIds
          ? _value.photoIds
          : photoIds // ignore: cast_nullable_to_non_nullable
              as List<String>?,
      categoryIds: freezed == categoryIds
          ? _value.categoryIds
          : categoryIds // ignore: cast_nullable_to_non_nullable
              as List<String>?,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$GetShopProductsEntitiesRespCopyWith<$Res>
    implements $GetShopProductsEntitiesResponseCopyWith<$Res> {
  factory _$$GetShopProductsEntitiesRespCopyWith(
          _$GetShopProductsEntitiesResp value,
          $Res Function(_$GetShopProductsEntitiesResp) then) =
      __$$GetShopProductsEntitiesRespCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {@JsonKey(name: "id") String? id,
      @JsonKey(name: "name") String? name,
      @JsonKey(name: "description") String? description,
      @JsonKey(name: "price") double? price,
      @JsonKey(name: "photoIds") List<String>? photoIds,
      @JsonKey(name: "categoryIds") List<String>? categoryIds});
}

/// @nodoc
class __$$GetShopProductsEntitiesRespCopyWithImpl<$Res>
    extends _$GetShopProductsEntitiesResponseCopyWithImpl<$Res,
        _$GetShopProductsEntitiesResp>
    implements _$$GetShopProductsEntitiesRespCopyWith<$Res> {
  __$$GetShopProductsEntitiesRespCopyWithImpl(
      _$GetShopProductsEntitiesResp _value,
      $Res Function(_$GetShopProductsEntitiesResp) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = freezed,
    Object? name = freezed,
    Object? description = freezed,
    Object? price = freezed,
    Object? photoIds = freezed,
    Object? categoryIds = freezed,
  }) {
    return _then(_$GetShopProductsEntitiesResp(
      id: freezed == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String?,
      name: freezed == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String?,
      description: freezed == description
          ? _value.description
          : description // ignore: cast_nullable_to_non_nullable
              as String?,
      price: freezed == price
          ? _value.price
          : price // ignore: cast_nullable_to_non_nullable
              as double?,
      photoIds: freezed == photoIds
          ? _value._photoIds
          : photoIds // ignore: cast_nullable_to_non_nullable
              as List<String>?,
      categoryIds: freezed == categoryIds
          ? _value._categoryIds
          : categoryIds // ignore: cast_nullable_to_non_nullable
              as List<String>?,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$GetShopProductsEntitiesResp implements GetShopProductsEntitiesResp {
  const _$GetShopProductsEntitiesResp(
      {@JsonKey(name: "id") this.id,
      @JsonKey(name: "name") this.name,
      @JsonKey(name: "description") this.description,
      @JsonKey(name: "price") this.price,
      @JsonKey(name: "photoIds") final List<String>? photoIds,
      @JsonKey(name: "categoryIds") final List<String>? categoryIds})
      : _photoIds = photoIds,
        _categoryIds = categoryIds;

  factory _$GetShopProductsEntitiesResp.fromJson(Map<String, dynamic> json) =>
      _$$GetShopProductsEntitiesRespFromJson(json);

  /// ИД сущности
  @override
  @JsonKey(name: "id")
  final String? id;

  /// Наименование товара
  @override
  @JsonKey(name: "name")
  final String? name;

  /// Описание товара
  @override
  @JsonKey(name: "description")
  final String? description;

  /// Цена товара
  @override
  @JsonKey(name: "price")
  final double? price;

  /// Ид фотографий товара
  final List<String>? _photoIds;

  /// Ид фотографий товара
  @override
  @JsonKey(name: "photoIds")
  List<String>? get photoIds {
    final value = _photoIds;
    if (value == null) return null;
    if (_photoIds is EqualUnmodifiableListView) return _photoIds;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(value);
  }

  /// Ид категорий товара
  final List<String>? _categoryIds;

  /// Ид категорий товара
  @override
  @JsonKey(name: "categoryIds")
  List<String>? get categoryIds {
    final value = _categoryIds;
    if (value == null) return null;
    if (_categoryIds is EqualUnmodifiableListView) return _categoryIds;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(value);
  }

  @override
  String toString() {
    return 'GetShopProductsEntitiesResponse(id: $id, name: $name, description: $description, price: $price, photoIds: $photoIds, categoryIds: $categoryIds)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$GetShopProductsEntitiesResp &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.description, description) ||
                other.description == description) &&
            (identical(other.price, price) || other.price == price) &&
            const DeepCollectionEquality().equals(other._photoIds, _photoIds) &&
            const DeepCollectionEquality()
                .equals(other._categoryIds, _categoryIds));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType,
      id,
      name,
      description,
      price,
      const DeepCollectionEquality().hash(_photoIds),
      const DeepCollectionEquality().hash(_categoryIds));

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$GetShopProductsEntitiesRespCopyWith<_$GetShopProductsEntitiesResp>
      get copyWith => __$$GetShopProductsEntitiesRespCopyWithImpl<
          _$GetShopProductsEntitiesResp>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$GetShopProductsEntitiesRespToJson(
      this,
    );
  }
}

abstract class GetShopProductsEntitiesResp
    implements GetShopProductsEntitiesResponse {
  const factory GetShopProductsEntitiesResp(
          {@JsonKey(name: "id") final String? id,
          @JsonKey(name: "name") final String? name,
          @JsonKey(name: "description") final String? description,
          @JsonKey(name: "price") final double? price,
          @JsonKey(name: "photoIds") final List<String>? photoIds,
          @JsonKey(name: "categoryIds") final List<String>? categoryIds}) =
      _$GetShopProductsEntitiesResp;

  factory GetShopProductsEntitiesResp.fromJson(Map<String, dynamic> json) =
      _$GetShopProductsEntitiesResp.fromJson;

  @override

  /// ИД сущности
  @JsonKey(name: "id")
  String? get id;
  @override

  /// Наименование товара
  @JsonKey(name: "name")
  String? get name;
  @override

  /// Описание товара
  @JsonKey(name: "description")
  String? get description;
  @override

  /// Цена товара
  @JsonKey(name: "price")
  double? get price;
  @override

  /// Ид фотографий товара
  @JsonKey(name: "photoIds")
  List<String>? get photoIds;
  @override

  /// Ид категорий товара
  @JsonKey(name: "categoryIds")
  List<String>? get categoryIds;
  @override
  @JsonKey(ignore: true)
  _$$GetShopProductsEntitiesRespCopyWith<_$GetShopProductsEntitiesResp>
      get copyWith => throw _privateConstructorUsedError;
}
