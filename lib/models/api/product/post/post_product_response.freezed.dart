// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'post_product_response.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

PostProductResponse _$PostProductResponseFromJson(Map<String, dynamic> json) {
  return PostProductResp.fromJson(json);
}

/// @nodoc
mixin _$PostProductResponse {
  /// Ид созданной записи
  @JsonKey(name: "id")
  String? get id => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $PostProductResponseCopyWith<PostProductResponse> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $PostProductResponseCopyWith<$Res> {
  factory $PostProductResponseCopyWith(
          PostProductResponse value, $Res Function(PostProductResponse) then) =
      _$PostProductResponseCopyWithImpl<$Res, PostProductResponse>;
  @useResult
  $Res call({@JsonKey(name: "id") String? id});
}

/// @nodoc
class _$PostProductResponseCopyWithImpl<$Res, $Val extends PostProductResponse>
    implements $PostProductResponseCopyWith<$Res> {
  _$PostProductResponseCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = freezed,
  }) {
    return _then(_value.copyWith(
      id: freezed == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String?,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$PostProductRespCopyWith<$Res>
    implements $PostProductResponseCopyWith<$Res> {
  factory _$$PostProductRespCopyWith(
          _$PostProductResp value, $Res Function(_$PostProductResp) then) =
      __$$PostProductRespCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({@JsonKey(name: "id") String? id});
}

/// @nodoc
class __$$PostProductRespCopyWithImpl<$Res>
    extends _$PostProductResponseCopyWithImpl<$Res, _$PostProductResp>
    implements _$$PostProductRespCopyWith<$Res> {
  __$$PostProductRespCopyWithImpl(
      _$PostProductResp _value, $Res Function(_$PostProductResp) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = freezed,
  }) {
    return _then(_$PostProductResp(
      id: freezed == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$PostProductResp implements PostProductResp {
  const _$PostProductResp({@JsonKey(name: "id") this.id});

  factory _$PostProductResp.fromJson(Map<String, dynamic> json) =>
      _$$PostProductRespFromJson(json);

  /// Ид созданной записи
  @override
  @JsonKey(name: "id")
  final String? id;

  @override
  String toString() {
    return 'PostProductResponse(id: $id)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$PostProductResp &&
            (identical(other.id, id) || other.id == id));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, id);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$PostProductRespCopyWith<_$PostProductResp> get copyWith =>
      __$$PostProductRespCopyWithImpl<_$PostProductResp>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$PostProductRespToJson(
      this,
    );
  }
}

abstract class PostProductResp implements PostProductResponse {
  const factory PostProductResp({@JsonKey(name: "id") final String? id}) =
      _$PostProductResp;

  factory PostProductResp.fromJson(Map<String, dynamic> json) =
      _$PostProductResp.fromJson;

  @override

  /// Ид созданной записи
  @JsonKey(name: "id")
  String? get id;
  @override
  @JsonKey(ignore: true)
  _$$PostProductRespCopyWith<_$PostProductResp> get copyWith =>
      throw _privateConstructorUsedError;
}
