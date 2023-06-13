// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'post_authentication_login_request.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

PostAuthenticationLoginRequest _$PostAuthenticationLoginRequestFromJson(
    Map<String, dynamic> json) {
  return PostAuthenticationLoginReq.fromJson(json);
}

/// @nodoc
mixin _$PostAuthenticationLoginRequest {
  /// Email
  @JsonKey(name: "email")
  String? get email => throw _privateConstructorUsedError;

  /// Password
  @JsonKey(name: "password")
  String? get password => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $PostAuthenticationLoginRequestCopyWith<PostAuthenticationLoginRequest>
      get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $PostAuthenticationLoginRequestCopyWith<$Res> {
  factory $PostAuthenticationLoginRequestCopyWith(
          PostAuthenticationLoginRequest value,
          $Res Function(PostAuthenticationLoginRequest) then) =
      _$PostAuthenticationLoginRequestCopyWithImpl<$Res,
          PostAuthenticationLoginRequest>;
  @useResult
  $Res call(
      {@JsonKey(name: "email") String? email,
      @JsonKey(name: "password") String? password});
}

/// @nodoc
class _$PostAuthenticationLoginRequestCopyWithImpl<$Res,
        $Val extends PostAuthenticationLoginRequest>
    implements $PostAuthenticationLoginRequestCopyWith<$Res> {
  _$PostAuthenticationLoginRequestCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? email = freezed,
    Object? password = freezed,
  }) {
    return _then(_value.copyWith(
      email: freezed == email
          ? _value.email
          : email // ignore: cast_nullable_to_non_nullable
              as String?,
      password: freezed == password
          ? _value.password
          : password // ignore: cast_nullable_to_non_nullable
              as String?,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$PostAuthenticationLoginReqCopyWith<$Res>
    implements $PostAuthenticationLoginRequestCopyWith<$Res> {
  factory _$$PostAuthenticationLoginReqCopyWith(
          _$PostAuthenticationLoginReq value,
          $Res Function(_$PostAuthenticationLoginReq) then) =
      __$$PostAuthenticationLoginReqCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {@JsonKey(name: "email") String? email,
      @JsonKey(name: "password") String? password});
}

/// @nodoc
class __$$PostAuthenticationLoginReqCopyWithImpl<$Res>
    extends _$PostAuthenticationLoginRequestCopyWithImpl<$Res,
        _$PostAuthenticationLoginReq>
    implements _$$PostAuthenticationLoginReqCopyWith<$Res> {
  __$$PostAuthenticationLoginReqCopyWithImpl(
      _$PostAuthenticationLoginReq _value,
      $Res Function(_$PostAuthenticationLoginReq) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? email = freezed,
    Object? password = freezed,
  }) {
    return _then(_$PostAuthenticationLoginReq(
      freezed == email
          ? _value.email
          : email // ignore: cast_nullable_to_non_nullable
              as String?,
      freezed == password
          ? _value.password
          : password // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$PostAuthenticationLoginReq implements PostAuthenticationLoginReq {
  const _$PostAuthenticationLoginReq(@JsonKey(name: "email") this.email,
      @JsonKey(name: "password") this.password);

  factory _$PostAuthenticationLoginReq.fromJson(Map<String, dynamic> json) =>
      _$$PostAuthenticationLoginReqFromJson(json);

  /// Email
  @override
  @JsonKey(name: "email")
  final String? email;

  /// Password
  @override
  @JsonKey(name: "password")
  final String? password;

  @override
  String toString() {
    return 'PostAuthenticationLoginRequest(email: $email, password: $password)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$PostAuthenticationLoginReq &&
            (identical(other.email, email) || other.email == email) &&
            (identical(other.password, password) ||
                other.password == password));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, email, password);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$PostAuthenticationLoginReqCopyWith<_$PostAuthenticationLoginReq>
      get copyWith => __$$PostAuthenticationLoginReqCopyWithImpl<
          _$PostAuthenticationLoginReq>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$PostAuthenticationLoginReqToJson(
      this,
    );
  }
}

abstract class PostAuthenticationLoginReq
    implements PostAuthenticationLoginRequest {
  const factory PostAuthenticationLoginReq(
          @JsonKey(name: "email") final String? email,
          @JsonKey(name: "password") final String? password) =
      _$PostAuthenticationLoginReq;

  factory PostAuthenticationLoginReq.fromJson(Map<String, dynamic> json) =
      _$PostAuthenticationLoginReq.fromJson;

  @override

  /// Email
  @JsonKey(name: "email")
  String? get email;
  @override

  /// Password
  @JsonKey(name: "password")
  String? get password;
  @override
  @JsonKey(ignore: true)
  _$$PostAuthenticationLoginReqCopyWith<_$PostAuthenticationLoginReq>
      get copyWith => throw _privateConstructorUsedError;
}
