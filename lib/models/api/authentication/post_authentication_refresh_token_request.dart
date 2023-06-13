import 'package:freezed_annotation/freezed_annotation.dart';

part 'post_authentication_refresh_token_request.g.dart';
part 'post_authentication_refresh_token_request.freezed.dart';

/// Запрос на обновление токена.
@freezed
// ignore_for_file: invalid_annotation_target
class PostAuthenticationRefreshTokenRequest with _$PostAuthenticationRefreshTokenRequest {
  const factory PostAuthenticationRefreshTokenRequest({
    /// Access-токен
    @JsonKey(name: "token") String? accessToken,

    /// Refresh-токен
    @JsonKey(name: "refreshToken") String? refreshToken,
  }) = PostAuthenticationRefreshTokenReq;

  factory PostAuthenticationRefreshTokenRequest.fromJson(Map<String, dynamic> json) =>
      _$PostAuthenticationRefreshTokenRequestFromJson(json);
}
