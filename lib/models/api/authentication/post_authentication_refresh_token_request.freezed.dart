// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'post_authentication_refresh_token_request.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

PostAuthenticationRefreshTokenRequest
    _$PostAuthenticationRefreshTokenRequestFromJson(Map<String, dynamic> json) {
  return PostAuthenticationRefreshTokenReq.fromJson(json);
}

/// @nodoc
mixin _$PostAuthenticationRefreshTokenRequest {
  /// Access-токен
  @JsonKey(name: "token")
  String? get accessToken => throw _privateConstructorUsedError;

  /// Refresh-токен
  @JsonKey(name: "refreshToken")
  String? get refreshToken => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $PostAuthenticationRefreshTokenRequestCopyWith<
          PostAuthenticationRefreshTokenRequest>
      get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $PostAuthenticationRefreshTokenRequestCopyWith<$Res> {
  factory $PostAuthenticationRefreshTokenRequestCopyWith(
          PostAuthenticationRefreshTokenRequest value,
          $Res Function(PostAuthenticationRefreshTokenRequest) then) =
      _$PostAuthenticationRefreshTokenRequestCopyWithImpl<$Res,
          PostAuthenticationRefreshTokenRequest>;
  @useResult
  $Res call(
      {@JsonKey(name: "token") String? accessToken,
      @JsonKey(name: "refreshToken") String? refreshToken});
}

/// @nodoc
class _$PostAuthenticationRefreshTokenRequestCopyWithImpl<$Res,
        $Val extends PostAuthenticationRefreshTokenRequest>
    implements $PostAuthenticationRefreshTokenRequestCopyWith<$Res> {
  _$PostAuthenticationRefreshTokenRequestCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? accessToken = freezed,
    Object? refreshToken = freezed,
  }) {
    return _then(_value.copyWith(
      accessToken: freezed == accessToken
          ? _value.accessToken
          : accessToken // ignore: cast_nullable_to_non_nullable
              as String?,
      refreshToken: freezed == refreshToken
          ? _value.refreshToken
          : refreshToken // ignore: cast_nullable_to_non_nullable
              as String?,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$PostAuthenticationRefreshTokenReqCopyWith<$Res>
    implements $PostAuthenticationRefreshTokenRequestCopyWith<$Res> {
  factory _$$PostAuthenticationRefreshTokenReqCopyWith(
          _$PostAuthenticationRefreshTokenReq value,
          $Res Function(_$PostAuthenticationRefreshTokenReq) then) =
      __$$PostAuthenticationRefreshTokenReqCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {@JsonKey(name: "token") String? accessToken,
      @JsonKey(name: "refreshToken") String? refreshToken});
}

/// @nodoc
class __$$PostAuthenticationRefreshTokenReqCopyWithImpl<$Res>
    extends _$PostAuthenticationRefreshTokenRequestCopyWithImpl<$Res,
        _$PostAuthenticationRefreshTokenReq>
    implements _$$PostAuthenticationRefreshTokenReqCopyWith<$Res> {
  __$$PostAuthenticationRefreshTokenReqCopyWithImpl(
      _$PostAuthenticationRefreshTokenReq _value,
      $Res Function(_$PostAuthenticationRefreshTokenReq) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? accessToken = freezed,
    Object? refreshToken = freezed,
  }) {
    return _then(_$PostAuthenticationRefreshTokenReq(
      accessToken: freezed == accessToken
          ? _value.accessToken
          : accessToken // ignore: cast_nullable_to_non_nullable
              as String?,
      refreshToken: freezed == refreshToken
          ? _value.refreshToken
          : refreshToken // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$PostAuthenticationRefreshTokenReq
    implements PostAuthenticationRefreshTokenReq {
  const _$PostAuthenticationRefreshTokenReq(
      {@JsonKey(name: "token") this.accessToken,
      @JsonKey(name: "refreshToken") this.refreshToken});

  factory _$PostAuthenticationRefreshTokenReq.fromJson(
          Map<String, dynamic> json) =>
      _$$PostAuthenticationRefreshTokenReqFromJson(json);

  /// Access-токен
  @override
  @JsonKey(name: "token")
  final String? accessToken;

  /// Refresh-токен
  @override
  @JsonKey(name: "refreshToken")
  final String? refreshToken;

  @override
  String toString() {
    return 'PostAuthenticationRefreshTokenRequest(accessToken: $accessToken, refreshToken: $refreshToken)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$PostAuthenticationRefreshTokenReq &&
            (identical(other.accessToken, accessToken) ||
                other.accessToken == accessToken) &&
            (identical(other.refreshToken, refreshToken) ||
                other.refreshToken == refreshToken));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, accessToken, refreshToken);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$PostAuthenticationRefreshTokenReqCopyWith<
          _$PostAuthenticationRefreshTokenReq>
      get copyWith => __$$PostAuthenticationRefreshTokenReqCopyWithImpl<
          _$PostAuthenticationRefreshTokenReq>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$PostAuthenticationRefreshTokenReqToJson(
      this,
    );
  }
}

abstract class PostAuthenticationRefreshTokenReq
    implements PostAuthenticationRefreshTokenRequest {
  const factory PostAuthenticationRefreshTokenReq(
          {@JsonKey(name: "token") final String? accessToken,
          @JsonKey(name: "refreshToken") final String? refreshToken}) =
      _$PostAuthenticationRefreshTokenReq;

  factory PostAuthenticationRefreshTokenReq.fromJson(
      Map<String, dynamic> json) = _$PostAuthenticationRefreshTokenReq.fromJson;

  @override

  /// Access-токен
  @JsonKey(name: "token")
  String? get accessToken;
  @override

  /// Refresh-токен
  @JsonKey(name: "refreshToken")
  String? get refreshToken;
  @override
  @JsonKey(ignore: true)
  _$$PostAuthenticationRefreshTokenReqCopyWith<
          _$PostAuthenticationRefreshTokenReq>
      get copyWith => throw _privateConstructorUsedError;
}
