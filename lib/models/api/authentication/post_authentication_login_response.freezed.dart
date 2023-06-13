// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'post_authentication_login_response.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

PostAuthenticationLoginResponse _$PostAuthenticationLoginResponseFromJson(
    Map<String, dynamic> json) {
  return PostAuthenticationLoginResp.fromJson(json);
}

/// @nodoc
mixin _$PostAuthenticationLoginResponse {
  /// Идентификатор пользователя.
  @JsonKey(name: "userId")
  String? get userId => throw _privateConstructorUsedError;

  /// Текст токена.
  @JsonKey(name: "token")
  String? get token => throw _privateConstructorUsedError;

  /// Токен для обновления токена.
  @JsonKey(name: "refreshToken")
  String? get refreshToken => throw _privateConstructorUsedError;

  /// Время создания токена.
  @JsonKey(name: "createdOn")
  String? get createdOn => throw _privateConstructorUsedError;

  /// Тип токена.
  @JsonKey(name: "tokenType")
  String? get tokenType => throw _privateConstructorUsedError;

  /// Идентификатор типа токена.
  @JsonKey(name: "tokenTypeId")
  int? get tokenTypeId => throw _privateConstructorUsedError;

  /// Является ли пользователь владельцем какого-либо магазина
  @JsonKey(name: "isShopOwner")
  bool get isShopOwner => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $PostAuthenticationLoginResponseCopyWith<PostAuthenticationLoginResponse>
      get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $PostAuthenticationLoginResponseCopyWith<$Res> {
  factory $PostAuthenticationLoginResponseCopyWith(
          PostAuthenticationLoginResponse value,
          $Res Function(PostAuthenticationLoginResponse) then) =
      _$PostAuthenticationLoginResponseCopyWithImpl<$Res,
          PostAuthenticationLoginResponse>;
  @useResult
  $Res call(
      {@JsonKey(name: "userId") String? userId,
      @JsonKey(name: "token") String? token,
      @JsonKey(name: "refreshToken") String? refreshToken,
      @JsonKey(name: "createdOn") String? createdOn,
      @JsonKey(name: "tokenType") String? tokenType,
      @JsonKey(name: "tokenTypeId") int? tokenTypeId,
      @JsonKey(name: "isShopOwner") bool isShopOwner});
}

/// @nodoc
class _$PostAuthenticationLoginResponseCopyWithImpl<$Res,
        $Val extends PostAuthenticationLoginResponse>
    implements $PostAuthenticationLoginResponseCopyWith<$Res> {
  _$PostAuthenticationLoginResponseCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? userId = freezed,
    Object? token = freezed,
    Object? refreshToken = freezed,
    Object? createdOn = freezed,
    Object? tokenType = freezed,
    Object? tokenTypeId = freezed,
    Object? isShopOwner = null,
  }) {
    return _then(_value.copyWith(
      userId: freezed == userId
          ? _value.userId
          : userId // ignore: cast_nullable_to_non_nullable
              as String?,
      token: freezed == token
          ? _value.token
          : token // ignore: cast_nullable_to_non_nullable
              as String?,
      refreshToken: freezed == refreshToken
          ? _value.refreshToken
          : refreshToken // ignore: cast_nullable_to_non_nullable
              as String?,
      createdOn: freezed == createdOn
          ? _value.createdOn
          : createdOn // ignore: cast_nullable_to_non_nullable
              as String?,
      tokenType: freezed == tokenType
          ? _value.tokenType
          : tokenType // ignore: cast_nullable_to_non_nullable
              as String?,
      tokenTypeId: freezed == tokenTypeId
          ? _value.tokenTypeId
          : tokenTypeId // ignore: cast_nullable_to_non_nullable
              as int?,
      isShopOwner: null == isShopOwner
          ? _value.isShopOwner
          : isShopOwner // ignore: cast_nullable_to_non_nullable
              as bool,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$PostAuthenticationLoginRespCopyWith<$Res>
    implements $PostAuthenticationLoginResponseCopyWith<$Res> {
  factory _$$PostAuthenticationLoginRespCopyWith(
          _$PostAuthenticationLoginResp value,
          $Res Function(_$PostAuthenticationLoginResp) then) =
      __$$PostAuthenticationLoginRespCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {@JsonKey(name: "userId") String? userId,
      @JsonKey(name: "token") String? token,
      @JsonKey(name: "refreshToken") String? refreshToken,
      @JsonKey(name: "createdOn") String? createdOn,
      @JsonKey(name: "tokenType") String? tokenType,
      @JsonKey(name: "tokenTypeId") int? tokenTypeId,
      @JsonKey(name: "isShopOwner") bool isShopOwner});
}

/// @nodoc
class __$$PostAuthenticationLoginRespCopyWithImpl<$Res>
    extends _$PostAuthenticationLoginResponseCopyWithImpl<$Res,
        _$PostAuthenticationLoginResp>
    implements _$$PostAuthenticationLoginRespCopyWith<$Res> {
  __$$PostAuthenticationLoginRespCopyWithImpl(
      _$PostAuthenticationLoginResp _value,
      $Res Function(_$PostAuthenticationLoginResp) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? userId = freezed,
    Object? token = freezed,
    Object? refreshToken = freezed,
    Object? createdOn = freezed,
    Object? tokenType = freezed,
    Object? tokenTypeId = freezed,
    Object? isShopOwner = null,
  }) {
    return _then(_$PostAuthenticationLoginResp(
      userId: freezed == userId
          ? _value.userId
          : userId // ignore: cast_nullable_to_non_nullable
              as String?,
      token: freezed == token
          ? _value.token
          : token // ignore: cast_nullable_to_non_nullable
              as String?,
      refreshToken: freezed == refreshToken
          ? _value.refreshToken
          : refreshToken // ignore: cast_nullable_to_non_nullable
              as String?,
      createdOn: freezed == createdOn
          ? _value.createdOn
          : createdOn // ignore: cast_nullable_to_non_nullable
              as String?,
      tokenType: freezed == tokenType
          ? _value.tokenType
          : tokenType // ignore: cast_nullable_to_non_nullable
              as String?,
      tokenTypeId: freezed == tokenTypeId
          ? _value.tokenTypeId
          : tokenTypeId // ignore: cast_nullable_to_non_nullable
              as int?,
      isShopOwner: null == isShopOwner
          ? _value.isShopOwner
          : isShopOwner // ignore: cast_nullable_to_non_nullable
              as bool,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$PostAuthenticationLoginResp implements PostAuthenticationLoginResp {
  const _$PostAuthenticationLoginResp(
      {@JsonKey(name: "userId") this.userId,
      @JsonKey(name: "token") this.token,
      @JsonKey(name: "refreshToken") this.refreshToken,
      @JsonKey(name: "createdOn") this.createdOn,
      @JsonKey(name: "tokenType") this.tokenType,
      @JsonKey(name: "tokenTypeId") this.tokenTypeId,
      @JsonKey(name: "isShopOwner") this.isShopOwner = false});

  factory _$PostAuthenticationLoginResp.fromJson(Map<String, dynamic> json) =>
      _$$PostAuthenticationLoginRespFromJson(json);

  /// Идентификатор пользователя.
  @override
  @JsonKey(name: "userId")
  final String? userId;

  /// Текст токена.
  @override
  @JsonKey(name: "token")
  final String? token;

  /// Токен для обновления токена.
  @override
  @JsonKey(name: "refreshToken")
  final String? refreshToken;

  /// Время создания токена.
  @override
  @JsonKey(name: "createdOn")
  final String? createdOn;

  /// Тип токена.
  @override
  @JsonKey(name: "tokenType")
  final String? tokenType;

  /// Идентификатор типа токена.
  @override
  @JsonKey(name: "tokenTypeId")
  final int? tokenTypeId;

  /// Является ли пользователь владельцем какого-либо магазина
  @override
  @JsonKey(name: "isShopOwner")
  final bool isShopOwner;

  @override
  String toString() {
    return 'PostAuthenticationLoginResponse(userId: $userId, token: $token, refreshToken: $refreshToken, createdOn: $createdOn, tokenType: $tokenType, tokenTypeId: $tokenTypeId, isShopOwner: $isShopOwner)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$PostAuthenticationLoginResp &&
            (identical(other.userId, userId) || other.userId == userId) &&
            (identical(other.token, token) || other.token == token) &&
            (identical(other.refreshToken, refreshToken) ||
                other.refreshToken == refreshToken) &&
            (identical(other.createdOn, createdOn) ||
                other.createdOn == createdOn) &&
            (identical(other.tokenType, tokenType) ||
                other.tokenType == tokenType) &&
            (identical(other.tokenTypeId, tokenTypeId) ||
                other.tokenTypeId == tokenTypeId) &&
            (identical(other.isShopOwner, isShopOwner) ||
                other.isShopOwner == isShopOwner));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, userId, token, refreshToken,
      createdOn, tokenType, tokenTypeId, isShopOwner);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$PostAuthenticationLoginRespCopyWith<_$PostAuthenticationLoginResp>
      get copyWith => __$$PostAuthenticationLoginRespCopyWithImpl<
          _$PostAuthenticationLoginResp>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$PostAuthenticationLoginRespToJson(
      this,
    );
  }
}

abstract class PostAuthenticationLoginResp
    implements PostAuthenticationLoginResponse {
  const factory PostAuthenticationLoginResp(
          {@JsonKey(name: "userId") final String? userId,
          @JsonKey(name: "token") final String? token,
          @JsonKey(name: "refreshToken") final String? refreshToken,
          @JsonKey(name: "createdOn") final String? createdOn,
          @JsonKey(name: "tokenType") final String? tokenType,
          @JsonKey(name: "tokenTypeId") final int? tokenTypeId,
          @JsonKey(name: "isShopOwner") final bool isShopOwner}) =
      _$PostAuthenticationLoginResp;

  factory PostAuthenticationLoginResp.fromJson(Map<String, dynamic> json) =
      _$PostAuthenticationLoginResp.fromJson;

  @override

  /// Идентификатор пользователя.
  @JsonKey(name: "userId")
  String? get userId;
  @override

  /// Текст токена.
  @JsonKey(name: "token")
  String? get token;
  @override

  /// Токен для обновления токена.
  @JsonKey(name: "refreshToken")
  String? get refreshToken;
  @override

  /// Время создания токена.
  @JsonKey(name: "createdOn")
  String? get createdOn;
  @override

  /// Тип токена.
  @JsonKey(name: "tokenType")
  String? get tokenType;
  @override

  /// Идентификатор типа токена.
  @JsonKey(name: "tokenTypeId")
  int? get tokenTypeId;
  @override

  /// Является ли пользователь владельцем какого-либо магазина
  @JsonKey(name: "isShopOwner")
  bool get isShopOwner;
  @override
  @JsonKey(ignore: true)
  _$$PostAuthenticationLoginRespCopyWith<_$PostAuthenticationLoginResp>
      get copyWith => throw _privateConstructorUsedError;
}
