// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'post_product_request.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

PostProductRequest _$PostProductRequestFromJson(Map<String, dynamic> json) {
  return PostProductReq.fromJson(json);
}

/// @nodoc
mixin _$PostProductRequest {
  /// Наименование товара
  @JsonKey(name: "name")
  String? get name => throw _privateConstructorUsedError;

  /// Описание товара
  @JsonKey(name: "description")
  String? get description => throw _privateConstructorUsedError;

  /// Цена товара
  @JsonKey(name: "price")
  int? get price => throw _privateConstructorUsedError;

  /// Ид фотографий товара
  @JsonKey(name: "photoIds")
  List<String>? get photoIds => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $PostProductRequestCopyWith<PostProductRequest> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $PostProductRequestCopyWith<$Res> {
  factory $PostProductRequestCopyWith(
          PostProductRequest value, $Res Function(PostProductRequest) then) =
      _$PostProductRequestCopyWithImpl<$Res, PostProductRequest>;
  @useResult
  $Res call(
      {@JsonKey(name: "name") String? name,
      @JsonKey(name: "description") String? description,
      @JsonKey(name: "price") int? price,
      @JsonKey(name: "photoIds") List<String>? photoIds});
}

/// @nodoc
class _$PostProductRequestCopyWithImpl<$Res, $Val extends PostProductRequest>
    implements $PostProductRequestCopyWith<$Res> {
  _$PostProductRequestCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? name = freezed,
    Object? description = freezed,
    Object? price = freezed,
    Object? photoIds = freezed,
  }) {
    return _then(_value.copyWith(
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
              as int?,
      photoIds: freezed == photoIds
          ? _value.photoIds
          : photoIds // ignore: cast_nullable_to_non_nullable
              as List<String>?,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$PostProductReqCopyWith<$Res>
    implements $PostProductRequestCopyWith<$Res> {
  factory _$$PostProductReqCopyWith(
          _$PostProductReq value, $Res Function(_$PostProductReq) then) =
      __$$PostProductReqCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {@JsonKey(name: "name") String? name,
      @JsonKey(name: "description") String? description,
      @JsonKey(name: "price") int? price,
      @JsonKey(name: "photoIds") List<String>? photoIds});
}

/// @nodoc
class __$$PostProductReqCopyWithImpl<$Res>
    extends _$PostProductRequestCopyWithImpl<$Res, _$PostProductReq>
    implements _$$PostProductReqCopyWith<$Res> {
  __$$PostProductReqCopyWithImpl(
      _$PostProductReq _value, $Res Function(_$PostProductReq) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? name = freezed,
    Object? description = freezed,
    Object? price = freezed,
    Object? photoIds = freezed,
  }) {
    return _then(_$PostProductReq(
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
              as int?,
      photoIds: freezed == photoIds
          ? _value._photoIds
          : photoIds // ignore: cast_nullable_to_non_nullable
              as List<String>?,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$PostProductReq implements PostProductReq {
  const _$PostProductReq(
      {@JsonKey(name: "name") this.name,
      @JsonKey(name: "description") this.description,
      @JsonKey(name: "price") this.price,
      @JsonKey(name: "photoIds") final List<String>? photoIds})
      : _photoIds = photoIds;

  factory _$PostProductReq.fromJson(Map<String, dynamic> json) =>
      _$$PostProductReqFromJson(json);

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
  final int? price;

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

  @override
  String toString() {
    return 'PostProductRequest(name: $name, description: $description, price: $price, photoIds: $photoIds)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$PostProductReq &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.description, description) ||
                other.description == description) &&
            (identical(other.price, price) || other.price == price) &&
            const DeepCollectionEquality().equals(other._photoIds, _photoIds));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, name, description, price,
      const DeepCollectionEquality().hash(_photoIds));

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$PostProductReqCopyWith<_$PostProductReq> get copyWith =>
      __$$PostProductReqCopyWithImpl<_$PostProductReq>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$PostProductReqToJson(
      this,
    );
  }
}

abstract class PostProductReq implements PostProductRequest {
  const factory PostProductReq(
          {@JsonKey(name: "name") final String? name,
          @JsonKey(name: "description") final String? description,
          @JsonKey(name: "price") final int? price,
          @JsonKey(name: "photoIds") final List<String>? photoIds}) =
      _$PostProductReq;

  factory PostProductReq.fromJson(Map<String, dynamic> json) =
      _$PostProductReq.fromJson;

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
  int? get price;
  @override

  /// Ид фотографий товара
  @JsonKey(name: "photoIds")
  List<String>? get photoIds;
  @override
  @JsonKey(ignore: true)
  _$$PostProductReqCopyWith<_$PostProductReq> get copyWith =>
      throw _privateConstructorUsedError;
}
