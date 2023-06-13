import 'package:freezed_annotation/freezed_annotation.dart';

part 'post_authentication_login_request.g.dart';
part 'post_authentication_login_request.freezed.dart';

/// Запрос на логин.
@freezed
// ignore_for_file: invalid_annotation_target
class PostAuthenticationLoginRequest with _$PostAuthenticationLoginRequest {
  const factory PostAuthenticationLoginRequest(
    /// Email
    @JsonKey(name: "email") String? email,

    /// Password
    @JsonKey(name: "password") String? password,
  ) = PostAuthenticationLoginReq;

  factory PostAuthenticationLoginRequest.fromJson(Map<String, dynamic> json) =>
      _$PostAuthenticationLoginRequestFromJson(json);
}
